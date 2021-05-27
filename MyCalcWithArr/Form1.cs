using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalcWithArr
{
    public partial class Form1 : Form
    {
        //
        //  GRISHA
        //
        const int HistorySize = 10;
        string[] _history = new string[HistorySize];
        int _index = 0;   
        


        public Form1()
        {
            _history = new string[HistorySize];
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           

            if (txtFirstNumber.Text == "" || txtSecondNumber.Text == "" )
            {
                MessageBox.Show("Input numbers!");
                return;
            }

            string comboValue = comboBox1.Text;

            double firstNum, secondNum;
            bool canParse1 = Double.TryParse(txtFirstNumber.Text, out firstNum);
            bool canParse2 = Double.TryParse(txtSecondNumber.Text, out secondNum);

            switch (comboBox1.Text)
                {
                        
                    case "+":                     

                        if (!canParse1 || !canParse2)
                        {
                            txtResult.Text = txtFirstNumber.Text + " " + txtSecondNumber.Text;
                            _history[_index] = txtFirstNumber.Text + " " + comboBox1.Text + " " + txtSecondNumber.Text + " = " + txtResult.Text;
                            _index = (int)(_index + 1);
                        return;
                        }                      
                        txtResult.Text = Convert.ToString(firstNum + secondNum);
                        break;

                    case "-":
                        txtResult.Text = Convert.ToString(firstNum - secondNum);
                        break;
                    case "*":
                        txtResult.Text = Convert.ToString(firstNum * secondNum);
                        break;
                    case "/":
                        if (secondNum == 0)
                        {
                            MessageBox.Show("Cannot divide on 0 !");
                        }
                        else
                        {
                            txtResult.Text = Convert.ToString(firstNum / secondNum);

                        }
                        break;
                    case "%":
                        if (secondNum == 0)
                        {
                            MessageBox.Show("Cannot divide on 0 !");
                        }
                        else
                        {
                            txtResult.Text = Convert.ToString(firstNum % secondNum);
                        
                        }
                        break;
                case "":
                    MessageBox.Show("Choose your operation");
                    txtResult.Text = "";
                    break;
                default:
                        txtResult.Text = "Undefined Operation!";
                    break;
                }
            

            if (_index < _history.Length)
            {
                _history[_index] = txtFirstNumber.Text + " " + comboBox1.Text + " " + txtSecondNumber.Text + " = " + txtResult.Text;
                _index = (int)(_index + 1);
                return;
            }
            else
            {

            }



            var firstChar = txtFirstNumber.Text.Substring(0, 1);
            var secondChar = txtSecondNumber.Text.Substring(0, 1);



            if (firstChar == "0" || secondChar == "0")
             {
                 txtResult.Text = "";
                 MessageBox.Show("Number can't start from '0'");
                 return;
             }
             else if (firstChar == ";" || secondChar == ";")
             {
                    txtResult.Text = "";
                    MessageBox.Show("Number can't start from ';'");
                    return;
             }
             else if (firstChar == "," || secondChar == ",")
             {
                 MessageBox.Show("Number can't start from ',' I will add 0.");
                 firstChar.Insert(0, "0,");
                 secondChar.Insert(0, "0,");
                 return;
             }
             
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            txtFirstNumber.Text = "";
            txtSecondNumber.Text = "";
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {

            // Display the content of _history array.
           
            
            historyList.Items.Clear();
            for ( int i = 0; i < _history.Length; i++)
            {
                if(_history[i] == null)
                {
                    return;
                }
                else
                {
                    historyList.Items.Add(_history[i]);
                }
            }
        


        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            historyList.Items.Clear();
        }
    }
}
