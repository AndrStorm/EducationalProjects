using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.Entity;

namespace KVKP3
{
    public partial class Form1 : Form
    {
        //Определяем объект DataSet
        DataSet MyDataSet = new DataSet();

        //Имя каталога открываемого файла БД
        string catName = "";
        //Непосредственное имя самого файла БД
        string fileName = "";
        DataTable data1 = new DataTable();
        DataTable data2 = new DataTable();


        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            using (EmployersContext db = new EmployersContext())
            {

                data1.Reset();
                data1.Columns.Add("ID");
                data1.Columns.Add("Name");
                data1.Columns.Add("CardID");
                data1.Columns.Add("CardActivated");

                foreach (Employer emp in db.Employers.Include(emp=>emp.cards))
                {
                    foreach(Card c in emp.cards)
                    {

                        DataRow dr1 = data1.NewRow();
                        dr1["ID"] = emp.EmployerId;
                        dr1["Name"] = emp.employer_name;
                        dr1["CardID"] = c.CardId;
                        dr1["CardActivated"] = c.card_activated;
                        data1.Rows.Add(dr1);

                    }  
                }
                dataGridView1.DataSource = data1;

            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (data1.Columns.Count>0) MyDataSet.Tables.Add(data1);
            if (data2.Columns.Count > 0) MyDataSet.Tables.Add(data2);

            //Объект документа пдф
            iTextSharp.text.Document doc = new iTextSharp.text.Document();

            //Создаем объект записи пдф-документа в файл
            PdfWriter.GetInstance(doc, new FileStream("pdfTables.pdf", FileMode.Create));

            //Открываем документ
            doc.Open();

            //Определение шрифта необходимо для сохранения кириллического текста
            //Иначе мы не увидим кириллический текст
            //Если мы работаем только с англоязычными текстами, то шрифт можно не указывать
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
            
            //Обход по всем таблицам датасета (хотя в данном случае мы можем опустить
            //Так как в нашей бд только одна таблица)
            for (int i = 0; i < MyDataSet.Tables.Count; i++)
            {
                //Создаем объект таблицы и передаем в нее число столбцов таблицы из нашего датасета
                PdfPTable table = new PdfPTable(MyDataSet.Tables[i].Columns.Count);

                //Добавим в таблицу общий заголовок
                PdfPCell cell = new PdfPCell(new Phrase("БД " + fileName + ", таблица №" + (i + 1), font));

                cell.Colspan = MyDataSet.Tables[i].Columns.Count;
                cell.HorizontalAlignment = 1;
                //Убираем границу первой ячейки, чтобы балы как заголовок
                cell.Border = 0;
                table.AddCell(cell);

                //Сначала добавляем заголовки таблицы
                for (int j = 0; j < MyDataSet.Tables[i].Columns.Count; j++)
                {
                    cell = new PdfPCell(new Phrase(new Phrase(MyDataSet.Tables[i].Columns[j].ColumnName, font)));
                    //Фоновый цвет (необязательно, просто сделаем по красивее)
                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table.AddCell(cell);
                }

                //Добавляем все остальные ячейки
                for (int j = 0; j < MyDataSet.Tables[i].Rows.Count; j++)
                {
                    for (int k = 0; k < MyDataSet.Tables[i].Columns.Count; k++)
                    {
                        table.AddCell(new Phrase(MyDataSet.Tables[i].Rows[j][k].ToString(), font));
                    }
                }
                //Добавляем таблицу в документ
                doc.Add(table);
            }
            //Закрываем документ
            doc.Close();

            MessageBox.Show("Pdf-документ сохранен");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (EmployersContext db = new EmployersContext())
            {
                
                data2.Reset();
                data2.Columns.Add("CardID");
                data2.Columns.Add("OpperationID");
                data2.Columns.Add("Date");
                data2.Columns.Add("Succefull");
                


                foreach (Card c in db.Cards.Include(c => c.opperations))
                {
                    foreach (Opperation o in c.opperations)
                    {
                        DataRow dr1 = data2.NewRow();
                        dr1["CardID"] = c.CardId;
                        dr1["OpperationID"] = o.OpperationId;
                        dr1["Date"] = o.use_date;
                        dr1["Succefull"] = o.used_successfull;
                        data2.Rows.Add(dr1);

                    }
                }
                
                dataGridView1.DataSource = data2;
                

            }
        }
    }
}
