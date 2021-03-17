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

namespace Calculator
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string new_number;
        string complete_number;
        string old_number;
        string state;
        string answer;
        bool time2;

        public MainWindow()
        {
            
            InitializeComponent();         

        }

        public string change_number(string x) 
        {
            new_number = x;
            complete_number = (complete_number + new_number);

            return complete_number;
        }

        public void transition(string a) 
        {
            if (time2 == false)
            {
                old_number = complete_number;
                complete_number = "";
                PrincipalLabel.Content = "";
                state = a;

            }
            else 
            {
                state = a;
            }
        }

        public bool result_Error(string a, string b) 
        {
            if (a != "")
            {
                if (b != "")
                {
                    return false;
                }
                else
                    return true;
            }

            else
                return true;
        
        }

        public void DEl() 
        {
            complete_number =complete_number.Remove(complete_number.Length - 1, 1);
            PrincipalLabel.Content = complete_number;
        
        }
        
        public void result_(string astate) 
        {
            double answerd;
            if (result_Error(complete_number, old_number) == false)
            {
                switch (astate)
                {

                    case "addition":
                        answerd = double.Parse(complete_number) + double.Parse(old_number);
                        answer = answerd.ToString();
                        second_time();
                        break;
                    case "substraction":
                        answerd = double.Parse(old_number) - double.Parse(complete_number);
                        answer = answerd.ToString();
                        second_time();
                        break;
                    case "multiplication":
                        answerd = double.Parse(complete_number) * double.Parse(old_number);
                        answer = answerd.ToString();
                        second_time();
                        break;
                    case "division":
                        if (double.Parse(old_number) != 0)
                        {
                            answerd = double.Parse(complete_number) / double.Parse(old_number);
                            answer = answerd.ToString();
                            second_time();
                            break;
                        }

                        else
                        {
                            PrincipalLabel.Content = "Error: Cant divide by 0";
                            break;
                        }

                    case "power":
                        answerd = Math.Pow(double.Parse(complete_number), double.Parse(old_number));
                        answer = answerd.ToString();
                        second_time();
                        break;
                    case "root":
                        answerd = Math.Pow(double.Parse(old_number), 1 / double.Parse(complete_number));

                        answer = answerd.ToString();
                        second_time();
                        break;


                }
                PrincipalLabel.Content = answer;
            }

            



        }

        public void second_time() 
        {
            new_number = "";
            complete_number = "";
            old_number = answer.ToString();
            time2 = true;
        
        
        }
               


        //Numbers from 0-9 and "."
        private void Button_Click0(object sender, RoutedEventArgs e)
        {            PrincipalLabel.Content = change_number("0");        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {            PrincipalLabel.Content = change_number("1");        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {            PrincipalLabel.Content = change_number("2");        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {            PrincipalLabel.Content = change_number("3");        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {            PrincipalLabel.Content = change_number("4");        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {            PrincipalLabel.Content = change_number("5");        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {            PrincipalLabel.Content = change_number("6");        }

        private void Button_Click7(object sender, RoutedEventArgs e)
        {            PrincipalLabel.Content = change_number("7");        }

        private void Button_Click8(object sender, RoutedEventArgs e)
        {            PrincipalLabel.Content = change_number("8");        }

        private void Button_Click9(object sender, RoutedEventArgs e)
        {            PrincipalLabel.Content = change_number("9");        }

        private void Button_Click_dot(object sender, RoutedEventArgs e)
        {            PrincipalLabel.Content = change_number(".");        }



        //syntax buttons
        private void Button_Click_AC(object sender, RoutedEventArgs e)
        {
            new_number = "";
            complete_number = "";
            old_number = "";
            PrincipalLabel.Content = "";
            time2 = false;
            answer = "";
        }


        //operations + - / * ** */*

        private void Button_Click_plus(object sender, RoutedEventArgs e)
        {            transition("addition");        }

        private void Button_Click_minus(object sender, RoutedEventArgs e)
        {            transition("substraction");        }

        private void Button_Click_division(object sender, RoutedEventArgs e)
        {            transition("division");        }

        private void Button_Click_power(object sender, RoutedEventArgs e)
        {       transition("power");        }

        private void Button_Click_root(object sender, RoutedEventArgs e)
        {            transition("root");        }

        private void Button_Click_multiplication(object sender, RoutedEventArgs e)
        {            transition("multiplication");        }



        private void Button_Click_equal(object sender, RoutedEventArgs e)
        {
            result_(state);
        }
        private void Button_Click_DEL(object sender, RoutedEventArgs e)
        {
            DEl();
        }

    }
}
