using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Media.Imaging;

namespace WpfWKR3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Draw();
        }

        private readonly List<ModelVisual3D> _models = new List<ModelVisual3D>();

        public ModelVisual3D MyCylinder(Material mat, Point3D Fpoint, Point3D Spoint, double rad) //метод рисования цилиндра
        {
                var cylinder = new Model3DGroup();
                MeshGeometry3D myMeshGeometry3D = new MeshGeometry3D();
                GeometryModel3D GeometryModel = new GeometryModel3D();

                double x = 0, y = 0, z = 0; //координаты наклонной окружнсти
                double xrotOZ = 1, yrotOZ = 1, zrotOZ = 1; //координаты смещения окружнсти при повороте вдоль OZ
                double xrotOX = 1, yrotOX = 1, zrotOX = 1; // координаты смещения окружнсти при повороте вдоль OX
               
                Point3DCollection myPositionCollection = new Point3DCollection(); //коллекция координат вершин
                Int32Collection myTriangleIndicesCollection = new Int32Collection(); //коллекция индексов
                PointCollection myTextureCoordinatesCollection = new PointCollection(); //коллекция координат текстур

                int schet = 0; //счетчик
                var firstPass = true;
                var twoPi = Math.PI * 2;

                int sup = 0;
                if (Fpoint.Y == 0) //Делим почти на ноль 
                { Fpoint.Y = 0.00001;}
                if (Fpoint.Y > 0) //Меняем порядок соединения треугольгиков
                { sup = 1;}
                var alphaOZ = -1 * Math.Atan(Fpoint.X / Fpoint.Y); //угл поворота по OZ
                var alphaOX = -1 * Math.Atan(Fpoint.Z / Fpoint.Y); //угл поворота по OX

                var increment = 0.1d;
                for (double i = 0; i < twoPi + increment; i = i + increment)
                {
                x = rad * Math.Cos(i);
                y = 0;
                z = rad * Math.Sin(i);

                xrotOZ = x * Math.Cos(alphaOZ) - y* Math.Sin(alphaOZ);
                yrotOZ = x * Math.Sin(alphaOZ) + y * Math.Cos(alphaOZ);
                zrotOZ = 0;

                xrotOX = 0;
                yrotOX = z * Math.Sin(alphaOX) + y * Math.Cos(alphaOX);
                zrotOX = z * Math.Cos(alphaOX) - y * Math.Sin(alphaOX);

                if (Fpoint.X != 0 && Fpoint.Z != 0) //поворот вдоль двух осей одноавременно
                {
                    //xrotOZ = x * Math.Cos(alphaOZ) - y * Math.Sin(alphaOZ);
                    //yrotOZ = (x * Math.Sin(alphaOZ) + y * Math.Cos(alphaOZ)) ; // * (Fpoint.X / (Fpoint.X + Fpoint.Z))
                    //zrotOZ = 0;

                    //xrotOX = 0;
                    //yrotOX = (z * Math.Sin(alphaOX) + y * Math.Cos(alphaOX))  ;
                    //zrotOX = z * Math.Cos(alphaOX) - y * Math.Sin(alphaOX);
                }

                if (!firstPass)
                    {
                        myPositionCollection.Add(new Point3D(Spoint.X + xrotOZ + xrotOX, Spoint.Y + yrotOZ + yrotOX, Spoint.Z + zrotOZ + zrotOX)); //точка первой окружности
                        myPositionCollection.Add(new Point3D(Spoint.X + xrotOZ + xrotOX + Fpoint.X, Spoint.Y + yrotOZ + yrotOX + Fpoint.Y, Spoint.Z + zrotOZ + zrotOX + Fpoint.Z)); //точка 2 окружности
                        myTriangleIndicesCollection.Add(0); //треугольник первой окружности
                        myTriangleIndicesCollection.Add(4 + schet * 2 - sup * 2);
                        myTriangleIndicesCollection.Add(2 + schet * 2 + sup * 2);
                        myTriangleIndicesCollection.Add(1); //треугольник 2 окружности
                        myTriangleIndicesCollection.Add(3 + schet * 2 + sup * 2);
                        myTriangleIndicesCollection.Add(5 + schet * 2 - sup * 2);

                        myTriangleIndicesCollection.Add(4 + schet * 2); //стенка цилиндра
                        myTriangleIndicesCollection.Add(3 + schet * 2 - sup);
                        myTriangleIndicesCollection.Add(2 + schet * 2 + sup);
                        myTriangleIndicesCollection.Add(4 + schet * 2);
                        myTriangleIndicesCollection.Add(5 + schet * 2 - sup * 2);
                        myTriangleIndicesCollection.Add(3 + schet * 2 + sup * 2);
                        schet++;
                    
                        myTextureCoordinatesCollection.Add(new Point(0, 0));
                        myTextureCoordinatesCollection.Add(new Point(0, 1));
                        myTextureCoordinatesCollection.Add(new Point(1, 0));
                        myTextureCoordinatesCollection.Add(new Point(1, 1));
                }
                    else
                    {
                        myPositionCollection.Add(new Point3D(Spoint.X, Spoint.Y, Spoint.Z)); //центр первой окружности
                        myPositionCollection.Add(new Point3D(Spoint.X + Fpoint.X, Spoint.Y + Fpoint.Y, Spoint.Z + Fpoint.Z)); //центр 2 окружности
                        myPositionCollection.Add(new Point3D(Spoint.X + xrotOZ + xrotOX, Spoint.Y + yrotOZ + yrotOX, Spoint.Z + zrotOZ + zrotOX)); //точка первой окружности
                        myPositionCollection.Add(new Point3D(Spoint.X + xrotOZ + xrotOX + Fpoint.X, Spoint.Y + yrotOZ + yrotOX + Fpoint.Y, Spoint.Z + zrotOZ + zrotOX + Fpoint.Z)); //точка 2 окружности

                    firstPass = false;
                    }
                }

                myMeshGeometry3D.TextureCoordinates = myTextureCoordinatesCollection;
                myMeshGeometry3D.Positions = myPositionCollection;
                myMeshGeometry3D.TriangleIndices = myTriangleIndicesCollection;
                GeometryModel.Geometry = myMeshGeometry3D;
                GeometryModel.Material = mat;
                cylinder.Children.Add(GeometryModel);
        
                var model = new ModelVisual3D { Content = cylinder };
                return model;
        }
            public void Draw()
        {
            //напрваление бурения
            double[] x = new double[65] { 0, 0, 0, 0, 0, -0.1, -0.2, -0.3, -0.4, -0.5, -0.6, -0.7, -0.8, -0.9, -0.9, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -0.9, -0.9, -0.9, -0.8, -0.8, -0.7, -0.7, -0.6, -0.6, -0.5, -0.5, -0.4, -0.4, -0.3, -0.3, -0.2, -0.2, -0.1, -0.1, 0, 0, 0, 0, 0, -0, -0, -0, -0, 0, 0, 0, 0, 0, -0, -0, -0, -0, -0, 0, 0, };
            //double[] y = new double[8] { -1, -1, -1, -1, -1, -1, -1, -1 };
            //double[] z = new double[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] c = new int[65] { 1, 1, 1, 1, 1, 1, 2, 1, 2, 2, 1, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 4, 4, 3, 3, 4, 4, 4, 3, 4, 3, 4, 4, 3, 3, 4, 3, 3, 3, 3, 3, 4, 4, 9, 9 }; //литология
            //double[] r = new double[8] { 1, 1, 1, 1, 1, 1, 1, 1 }; //диаметр
            double x2 = 0, y2 = 0, z2 = 0; //координаты смещения
            //параметры второй скважины
            //double[] xs2 = new double[8] { 0, 0, 0, 0, 0, 0, 0, 0 }; 
            //double[] ys2 = new double[8] { -1, -1, -1, -1, -1, -1, -1, -1 };
            double[] zs2 = new double[65] { 0, 0, 0, 0, 0, -0.1, -0.2, -0.3, -0.4, -0.5, -0.6, -0.7, -0.8, -0.9, -0.9, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -0.9, -0.9, -0.9, -0.8, -0.8, -0.7, -0.7, -0.6, -0.6, -0.5, -0.5, -0.4, -0.4, -0.3, -0.3, -0.2, -0.2, -0.1, -0.1, 0, 0, 0, 0, 0, -0, -0, -0, -0, 0, 0, 0, 0, 0, -0, -0, -0, -0, -0, 0, 0, };
            int[] cs2 = new int[65] { 1, 1, 1, 1, 1, 1, 2, 1, 2, 2, 1, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 4, 4, 3, 3, 4, 4, 4, 3, 4, 3, 4, 4, 3, 3, 4, 3, 3, 3, 3, 3, 4, 4, 9, 9 }; //литология
            double x2s2 = 2, y2s2 = 0, z2s2 = 2;

            Model3DGroup myModel3DGroup = new Model3DGroup();
            ModelVisual3D myModelVisual3D = new ModelVisual3D();

            PerspectiveCamera myPCamera = new PerspectiveCamera(); //камера
            myPCamera.Position = new Point3D(0, 0, 10);
            myPCamera.LookDirection = new Vector3D(0, 0, -1);
            myPCamera.FieldOfView = 70;
            myViewport3D.Camera = myPCamera;

            DirectionalLight myDirectionalLight = new DirectionalLight(); //освещение
            myDirectionalLight.Color = Colors.White;
            myDirectionalLight.Direction = new Vector3D(-1, -1, -2);
            //myModel3DGroup.Children.Add(myDirectionalLight);
            AmbientLight newLight = new AmbientLight();
            newLight.Color = Colors.White;
            myModel3DGroup.Children.Add(newLight);

            myModelVisual3D.Content = myModel3DGroup; //группа с освещением
            myViewport3D.Children.Add(myModelVisual3D);

            for (int j = 0; j < x.Length; j++) //перебор массивов 
            {  
                DiffuseMaterial myMaterial = new DiffuseMaterial(selectImage(c[j])); //материал
                Point3D Firstpoint = new Point3D(x[j],-1,0);  //направление бурения
                Point3D Secondpoint = new Point3D(x2, y2, z2);  //координата первой окружности

                _models.Add(MyCylinder(myMaterial, Firstpoint, Secondpoint, 1)); //вызываем метод рисования цилиндра и добавляем модель в список
                x2 = x[j] + x2;
                y2 = -1 + y2;
                z2 = 0 + z2;
            }

            x2 = 2; y2 = 0; z2 = 2;
            for (int j = 0; j < x.Length; j++) //перебор массивов 
            {
                x[j] = x[j] * (-1);
                DiffuseMaterial myMaterial = new DiffuseMaterial(selectImage(c[j])); //материал
                Point3D Firstpoint = new Point3D(x[j], -1, 0);  //направление бурения
                Point3D Secondpoint = new Point3D(x2, y2, z2);  //координата первой окружности

                _models.Add(MyCylinder(myMaterial, Firstpoint, Secondpoint, 1)); //вызываем метод рисования цилиндра и добавляем модель в список
                x2 = x[j] + x2;
                y2 = -1 + y2;
                z2 = 0 + z2;
            }

            for (int j = 0; j < 5; j++) //перебор массивов 
            {
                DiffuseMaterial myMaterial = new DiffuseMaterial(selectImage(cs2[j])); //материал
                Point3D Firstpoint = new Point3D(0, -1, zs2[j]);  //направление бурения
                Point3D Secondpoint = new Point3D(x2s2, y2s2, z2s2);  //координата первой окружности

                _models.Add(MyCylinder(myMaterial, Firstpoint, Secondpoint, 1)); //вызываем метод рисования цилиндра и добавляем модель в список
                x2s2 = 0 + x2s2;
                y2s2 = -1 + y2s2;
                z2s2 = zs2[j] + z2s2;
            }

            _models.ForEach(q => myViewport3D.Children.Add(q)); //загружаем модели из списка в окно Viewport3D
        }

        public ImageBrush selectImage (int c) //метод рисования цилиндра
        {
            ImageBrush NImage = new ImageBrush();
            switch (c)
            {
                case 1: NImage.ImageSource = new BitmapImage(new Uri(@"jpg\pesok.jpg", UriKind.Relative)); ; break;
                case 2: NImage.ImageSource = new BitmapImage(new Uri(@"jpg\peschanik.jpg", UriKind.Relative)); ; break;
                case 3: NImage.ImageSource = new BitmapImage(new Uri(@"jpg\alevrolit.jpg", UriKind.Relative)); ; break;
                case 4: NImage.ImageSource = new BitmapImage(new Uri(@"jpg\glina.jpg", UriKind.Relative)); ; break;
                case 5: NImage.ImageSource = new BitmapImage(new Uri(@"jpg\argillit.jpg", UriKind.Relative)); ; break;
                case 6: NImage.ImageSource = new BitmapImage(new Uri(@"jpg\mergel.jpg", UriKind.Relative)); ; break;
                case 7: NImage.ImageSource = new BitmapImage(new Uri(@"jpg\izvetniak.jpg", UriKind.Relative)); ; break;
                case 8: NImage.ImageSource = new BitmapImage(new Uri(@"jpg\dolomit.jpg", UriKind.Relative)); ; break;
                default: NImage.ImageSource = new BitmapImage(new Uri(@"jpg\angidrid.jpg", UriKind.Relative)); ; break;
            }
            
            return NImage;
        }
            private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PerspectiveCamera myPCamera = new PerspectiveCamera(); 
            myPCamera.Position = new Point3D(0, -2 , 2+ slider.Value);
            myPCamera.LookDirection = new Vector3D(0, 0, -1);
            myPCamera.FieldOfView = 70;
            myViewport3D.Camera = myPCamera;
        }

        private void Slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var rotateTransform3D = new RotateTransform3D { CenterX = 0, CenterZ = 0 };
            var axisAngleRotation3D = new AxisAngleRotation3D { Axis = new Vector3D(0, 1, 0), Angle = slider1.Value * 2 };
            rotateTransform3D.Rotation = axisAngleRotation3D;
            var myTransform3DGroup = new Transform3DGroup();
            myTransform3DGroup.Children.Add(rotateTransform3D);

            var rotateTransform3D2 = new RotateTransform3D { CenterX = 0, CenterZ = 0 };
            var axisAngleRotation3D2 = new AxisAngleRotation3D { Axis = new Vector3D(1, 0, 0), Angle = slider2.Value * 2 };
            rotateTransform3D2.Rotation = axisAngleRotation3D2;
            myTransform3DGroup.Children.Add(rotateTransform3D2);
            _models.ForEach(x => x.Transform = myTransform3DGroup);
        }

        private void Slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var rotateTransform3D1 = new RotateTransform3D { CenterX = 0, CenterZ = 0 };
            var axisAngleRotation3D1 = new AxisAngleRotation3D { Axis = new Vector3D(0, 1, 0), Angle = slider1.Value * 2 };
            rotateTransform3D1.Rotation = axisAngleRotation3D1;
            var myTransform3DGroup = new Transform3DGroup();
            myTransform3DGroup.Children.Add(rotateTransform3D1);

            var rotateTransform3D = new RotateTransform3D { CenterX = 0, CenterZ = 0 };
            var axisAngleRotation3D = new AxisAngleRotation3D { Axis = new Vector3D(1, 0, 0), Angle = slider2.Value*2 };
            rotateTransform3D.Rotation = axisAngleRotation3D;
            myTransform3DGroup.Children.Add(rotateTransform3D);
            _models.ForEach(x => x.Transform = myTransform3DGroup);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            slider1.Value = 0;
            slider2.Value = 0;
        }
    }
}
