using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;


namespace WpfWKR3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            triangle();
        }
        
        Model3DGroup myModel3DGroup = new Model3DGroup();
        GeometryModel3D myGeometryModel = new GeometryModel3D();
        ModelVisual3D myModelVisual3D = new ModelVisual3D();

        public void triangle()
        {
            double[] x = new double[4] { 0, 1, 0, 0 };
            double[] y = new double[4] { -1, -1, -1, -1 };
            double[] z = new double[4] { 0, 0, -1, 0 };
            double[] h = new double[4] { 2, 2, 2, 2 };
            double[] c = new double[4] { 1, 1, 1, 1 };
            double[] r = new double[4] { 2, 2, 2, 2 };
            double x2=0, y2=0, z2=0;
            Vector3D V = new Vector3D(x[0], y[0], z[0]);
            Vector3D R = new Vector3D(0,0,0);

            // Declare scene objects.
            //Viewport3D myViewport3D = new Viewport3D();

            // camera.
            PerspectiveCamera myPCamera = new PerspectiveCamera();
            // Specify where in the 3D scene the camera is.
            myPCamera.Position = new Point3D(0, -3, 10);
            // Specify the direction that the camera is pointing.
            myPCamera.LookDirection = new Vector3D(0, 0, -1);
            // Define camera's horizontal field of view in degrees.
            myPCamera.FieldOfView = 60;
            // Asign the camera to the viewport
            myViewport3D.Camera = myPCamera;

            // lights.
            DirectionalLight myDirectionalLight = new DirectionalLight();
            myDirectionalLight.Color = Colors.White;
            myDirectionalLight.Direction = new Vector3D(-1, -1, -2);
            myModel3DGroup.Children.Add(myDirectionalLight);
            AmbientLight MyAmb = new AmbientLight();
            MyAmb.Color = Colors.White;
            //myModel3DGroup.Children.Add(MyAmb);

            // The geometry specifes the shape of the 3D plane.
            MeshGeometry3D myMeshGeometry3D = new MeshGeometry3D();

            // Create a collection of normal vectors for the MeshGeometry3D.
            //Vector3DCollection myNormalCollection = new Vector3DCollection();
            //myNormalCollection.Add(new Vector3D(0, 0, 1));
            //myNormalCollection.Add(new Vector3D(0, 0, 1));
            //myNormalCollection.Add(new Vector3D(0, 0, 1));
            //myMeshGeometry3D.Normals = myNormalCollection;

            // Create a collection of vertex positions for the MeshGeometry3D.
            Point3DCollection myPositionCollection = new Point3DCollection();
            // Create a collection of triangle indices for the MeshGeometry3D.
            Int32Collection myTriangleIndicesCollection = new Int32Collection();

            if (V.Y == 0)
            {
                R.Y = 1;
                R.X = ((-1) * V.Y * R.Y) / V.X;
            }
            else
            {
                R.X = 1;
                R.Y = ((-1) * V.X * R.X) / V.Y;
            }
            double alpha = Math.Atan(R.Y/R.X);
            myPositionCollection.Add(new Point3D((-1 * r[0] / 2) * (R.X / (R.X + R.Y)), (-1 * r[0] / 2) * (R.Y / (R.X + R.Y)), 0));
            myPositionCollection.Add(new Point3D((r[0] / 2) * (R.X / (R.X + R.Y)), (r[0] / 2) * (R.Y / (R.X + R.Y)), 0));
            myPositionCollection.Add(new Point3D((-1 * r[0] / 2) * (R.X / (R.X + R.Y)) + x[0] * h[0], (-1 * r[0] / 2) * (R.Y / (R.X + R.Y)) + y[0] * h[0], z[0] * h[0]));
            myPositionCollection.Add(new Point3D((r[0] / 2) * (R.X / (R.X + R.Y)) + x[0] * h[0], (r[0] / 2) * (R.Y / (R.X + R.Y)) + y[0] * h[0], z[0] * h[0]));
            x2 = x[0] * h[0];
            y2 = y[0] * h[0];
            z2 = z[0] * h[0];

            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(3);

            for (int i = 1; i < 4; i++)
            {
                V.X = x[i];
                V.Y = y[i];
                V.Z = z[i];
                if (V.Y == 0)
                {
                    R.Y = 1;
                    R.X = ((-1) * V.Y * R.Y) / V.X;
                }
                else
                {
                    R.X = 1;
                    R.Y = ((-1) * V.X * R.X) / V.Y;
                }
                alpha = Math.Atan(R.Y / R.X);
                myPositionCollection.Add(new Point3D((-1 * r[i] / 2) * (R.X * Math.Cos(alpha)) +x2, (-1 * r[i] / 2) * (R.Y * Math.Sin(alpha)) +y2, z2));
                myPositionCollection.Add(new Point3D((r[i] / 2) * (R.X * Math.Cos(alpha)) +x2, (r[i] / 2) * (R.Y * Math.Sin(alpha)) +y2, z2));
                myPositionCollection.Add(new Point3D((-1 * r[i] / 2) * (R.X * Math.Cos(alpha)) + x[i] * h[i]+x2, (-1 * r[i] / 2) * (R.Y * Math.Sin(alpha)) + y[i] * h[i]+y2, z[i] * h[i]+z2));
                myPositionCollection.Add(new Point3D((r[i] / 2) * (R.X * Math.Cos(alpha)) + x[i] * h[i]+x2, (r[i] / 2) * (R.Y * Math.Sin(alpha)) + y[i] * h[i]+y2, z[i] * h[i]+z2));

                x2 = x[i] * h[i] + x2;
                y2 = y[i] * h[i] + y2;
                z2 = z[i] * h[i] + z2;

                myTriangleIndicesCollection.Add(0 + i * 4);
                myTriangleIndicesCollection.Add(2 + i * 4);
                myTriangleIndicesCollection.Add(1 + i * 4);
                myTriangleIndicesCollection.Add(1 + i * 4);
                myTriangleIndicesCollection.Add(2 + i * 4);
                myTriangleIndicesCollection.Add(3 + i * 4);

                

            }
            myMeshGeometry3D.Positions = myPositionCollection;
            myMeshGeometry3D.TriangleIndices = myTriangleIndicesCollection;

            // Apply the mesh to the geometry model.
            myGeometryModel.Geometry = myMeshGeometry3D;

            // Create a horizontal linear gradient with four stops.
            SolidColorBrush MyBrush = new SolidColorBrush(Colors.Red);

            // Define material and apply to the mesh geometries.
            DiffuseMaterial myMaterial = new DiffuseMaterial(MyBrush);
            myGeometryModel.Material = myMaterial;

            // Add the geometry model to the model group.
            myModel3DGroup.Children.Add(myGeometryModel);
            // Add the group of models to the ModelVisual3d.
            myModelVisual3D.Content = myModel3DGroup;
            //
            myViewport3D.Children.Add(myModelVisual3D);
            // Apply the viewport to the page so it will be rendered.
            //this.Content = myViewport3D;
        }

        //RotateTransform3D myRotateTransform3D = new RotateTransform3D();
        // Vector3D MyVektor = new Vector3D(0,0,0);
        Transform3DGroup myTransform3DGroup = new Transform3DGroup();
        

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            ScaleTransform3D myScale = new ScaleTransform3D(slider.Value/10, slider.Value / 10, slider.Value / 10);
            myGeometryModel.Transform = myScale;

            //myTransform3DGroup.Children.Add(myScale);
            //myGeometryModel.Transform = myTransform3DGroup;

        }

        private void Slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // rendering the 3D object rotated.
            RotateTransform3D myRotateTransform3D = new RotateTransform3D();
            //MyVektor.Y = MyVektor.Y + 3;
            AxisAngleRotation3D myAxisAngleRotation3d = new AxisAngleRotation3D();
            // myAxisAngleRotation3d.Axis = MyVektor;
            myAxisAngleRotation3d.Axis = new Vector3D(0, 1, 0);
            myAxisAngleRotation3d.Angle = slider1.Value;
            myRotateTransform3D.Rotation = myAxisAngleRotation3d;

            //myTransform3DGroup.Children.Add(myRotateTransform3D);
            //myGeometryModel.Transform = myTransform3DGroup;
            myGeometryModel.Transform = myRotateTransform3D;
        }

        private void Slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // rendering the 3D object rotated.
            RotateTransform3D myRotateTransform3D = new RotateTransform3D();
            //MyVektor.X = MyVektor.X + 1;
            AxisAngleRotation3D myAxisAngleRotation3d = new AxisAngleRotation3D();
            //myAxisAngleRotation3d.Axis = MyVektor;
            myAxisAngleRotation3d.Axis = new Vector3D(1, 0, 0);
            myAxisAngleRotation3d.Angle = slider2.Value;
            myRotateTransform3D.Rotation = myAxisAngleRotation3d;

            //myTransform3DGroup.Children.Add(myRotateTransform3D);
            //myGeometryModel.Transform = myTransform3DGroup;
            myGeometryModel.Transform = myRotateTransform3D;
        }
    }
}
