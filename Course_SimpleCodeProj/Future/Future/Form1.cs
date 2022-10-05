using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Configuration;
using Newtonsoft.Json;

namespace Future
{
    public partial class Form1 : Form
    {
        private const string APP_NAME = "Predictor";
        private readonly string PREDICTION_CONFIG_PATH = $"{Environment.CurrentDirectory}\\predictionConfig.json";
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = APP_NAME;
        }

        private async void buttonPredict_MouseClick(object sender, MouseEventArgs e)
        {
            buttonPredict.Enabled = false;
            
            //string[] stringArray = GetPredictionsAppSet();
            string[] stringArray = GetPredictionsJson(PREDICTION_CONFIG_PATH);

            await Task.Run(() =>
            {
                for (int i = 1; i <= 100; i++)
                {
                    Invoke(new Action(() =>
                    {
                        MoveProgressBar(i);
                        Text = $"{progressBar1.Value}%";
                    }));

                    Thread.Sleep(20);
                }
            });

            MessageBox.Show(stringArray[random.Next(stringArray.Length)]);

            Text = APP_NAME;
            progressBar1.Value = 0;
            
            buttonPredict.Enabled = true;
            
        }

        private void MoveProgressBar (int i)
        {
            progressBar1.Maximum += 1;
            progressBar1.Value = i + 1;

            progressBar1.Value = i;
            progressBar1.Maximum -= 1;

        }

        private string[] GetPredictionsAppSet()
        {
            string[] predictions = ConfigurationManager.AppSettings["strArray"].Split('$');
            return predictions;
        }

        private string[] GetPredictionsJson(string config)
        {
            string[] predictions = null;

            try
            {
                var data = File.ReadAllText(config,Encoding.UTF8);
                predictions = JsonConvert.DeserializeObject<string[]>(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (predictions ==null)
                {
                    Close();
                }
                else if(predictions.Length==0)
                {
                    MessageBox.Show("Нету предсказаний");
                }
            }
            return predictions;
        }
    }
}
