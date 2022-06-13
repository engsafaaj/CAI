using CAI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CAI
{
    public partial class Form1 : Form
    {
        bool st;
        float v1, v2, v3, v4, v5, v6, v7, v8, v9;
        public Form1()
        {
            InitializeComponent();
        }

      

        private async  void btn_predict_Click(object sender, EventArgs e)
        {

            pictureBox1.Visible = true;
            v1 = (float)Convert.ToDouble(textBox1.Text);
            v2 = (float)Convert.ToDouble(textBox2.Text);
            v3 = (float)Convert.ToDouble(textBox3.Text);
            v4 = (float)Convert.ToDouble(textBox4.Text);
            v5 = (float)Convert.ToDouble(textBox5.Text);
            v6 = (float)Convert.ToDouble(textBox6.Text);
            v7 = (float)Convert.ToDouble(textBox7.Text);
            v8 = (float)Convert.ToDouble(textBox8.Text);
            await Task.Run(() => Thread.Sleep(5000));

            var res = await Task.Run(()=> Run());
            if (res == true)
            {
                label19.Text = v9.ToString("#0.00");
            }
            else
            {
                MessageBox.Show("We can not do thats, Please try later");
            }


            pictureBox1.Visible = false;


        }


        private bool Run()
        {
            try
            {
                var sampleData = new MLModel1.ModelInput()
                {
                    Cement =v1,
                    Slag = v2,
                    Flyash = v3,
                    Water = v4,
                    Superplasticizer = v5,
                    Coarseaggregate = v6,
                    Fineaggregate = v7,
                    Age = v8,
                };
                

                //Load model and predict output
                var result = MLModel1.Predict(sampleData);
                v9 = result.Score;
                st = true;

            }
            catch
            {
                st = false;
            }
            return st;
        }
    }
}
