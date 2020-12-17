using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CalculatorCSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool canAdd = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Character(object sender, RoutedEventArgs e)
        {
            if (canAdd == false)
            {
                Results.Text = "";
                canAdd = true;
            }
            var charToBeInsert = (sender as Button).Content.ToString();
            if (charToBeInsert == "+" || charToBeInsert == "-" || charToBeInsert == "*" || charToBeInsert == "/")
            {
                if (string.IsNullOrEmpty(Results.Text))
                    return;
                string lastChar = Results.Text.ToString().Substring(Results.Text.ToString().Length-1, 1);
                if (lastChar == "+" || lastChar == "-" || lastChar == "*" || lastChar == "/")
                    return;
            }
            Results.Text += charToBeInsert;

        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            Results.Text = "";
        }

        private void RemoveLastChar(object sender, RoutedEventArgs e)
        {
            var operation = Results.Text;          
            Results.Text = operation.Remove(operation.Length - 1); 
        }     
        

        private void Result(object sender, RoutedEventArgs e)
        {
            int calcRes = 0;

            var res = Results.Text;
            if (string.IsNullOrEmpty(res))
                return;
            if (res.EndsWith('+') || res.EndsWith('-') || res.EndsWith('*') || res.EndsWith('/'))
            {
                MessageBox.Show("Type one more number");
                return;
            }    
            var number = res.Split('+','/','*','-');
            var operatorsSplit = res.Split('1', '2', '3', '4', '5', '6', '7', '8', '9', '0');
            var operators = new List<String>();

            if (number.Length > 1)
            {
                foreach (var op in operatorsSplit)
                {
                    if (op != "")
                        operators.Add(op);
                }

                calcRes = int.Parse(number[0]);
                for (int i = 1; i < operators.Count + 1; i++)
                {
                    switch (operators[i - 1])
                    {
                        case "+":
                            calcRes += int.Parse(number[i]);
                            break;
                        case "-":
                            calcRes -= int.Parse(number[i]);
                            break;
                        case "*":
                            calcRes *= int.Parse(number[i]);
                            break;
                        case "/":
                            calcRes /= int.Parse(number[i]);
                            break;
                    }
                }
            }
            else
            {
                calcRes = int.Parse(Results.Text);
            }


            canAdd = false;
            Results.Text = calcRes.ToString();
        }
    }
}
