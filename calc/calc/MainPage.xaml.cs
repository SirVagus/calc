using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Xamarin.Forms;

namespace calc
{
    public partial class MainPage : ContentPage
    {
        public char act = ' ';
        public double operand_1 = 0;
        public double operand_2 = 0;
        public int error = 0;
        public int plus_minus = 1;
        
        public MainPage()
        {
            InitializeComponent();
            Output.Text = "0";
        }

        private void OnButtonClicked_backspace(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            // если поле вывода пустое или равно 0 то ничего не делать
            if (Output.Text == "" || Output.Text == "0")
                return;
            // если в поле вывод остался только одна цифра заменить её нулём
            // и сразу выйти
            if (Output.Text.Length == 1)
            {
                Output.Text = "0";
                return;
            }
            // удалить из поле вывода один символ
            Output.Text = Output.Text.Remove(Output.Text.Length - 1, 1);
        }
        private void OnButtonClicked_CE(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            if (act == ' ')
                operand_1 = 0;
            else
                operand_2 = 0;
            Output.Text = "0";
        }
        private void OnButtonClicked_C(object sender, System.EventArgs e)
        {
            Output.Text = "0";
            operand_1 = 0;
            operand_2 = 0;
            error = 0;
            act = ' ';
        }
        private void OnButtonClicked_plus_minus(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            if (Output.Text == "0")
                return;
            if (Regex.IsMatch(Output.Text, "\\-"))
                Output.Text = Output.Text.Remove(0, 1);
            else
                Output.Text = Output.Text.Insert(0, "-");
        }

        private void OnButtonClicked_sqrt(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            // обработка исключений
            // --------------------------------------------------------------------------
            // | d параметр                     | Возвращаемое значение                 |
            // --------------------------------------------------------------------------
            // | Нуль или положительное число   | Положительный квадратный корень из d. |
            // --------------------------------------------------------------------------
            // | Отрицательное число            | NaN                                   |
            // --------------------------------------------------------------------------
            // | Равно NaN                      | NaN                                   |
            // --------------------------------------------------------------------------
            // | Равно PositiveInfinity         | PositiveInfinity                      |
            // --------------------------------------------------------------------------

            if (Double.IsNaN(Math.Sqrt(Convert.ToDouble(Output.Text))))
            {
                Output.Text = "Не допустимая операция";
                error = 1;
                return;
            }
            if (Double.IsPositiveInfinity(Math.Sqrt(Convert.ToDouble(Output.Text))))
            {
                Output.Text = "Не допустимая операция";
                error = 1;
                return;
            }
            Output.Text = Math.Sqrt(Convert.ToDouble(Output.Text)).ToString();
        }
        private void OnButtonClicked_7(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            // если поле вывода = 0, то при нажатии заменить 0 на нажатую цифру 
            if (Output.Text == "0")     
                Output.Text = "7";
            // если же не ноль то просто добавить к текущему значению нажатую цифру
            else
                Output.Text += "7";
        }
        private void OnButtonClicked_8(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            if (Output.Text == "0")     
                Output.Text = "8";
            else
                Output.Text += "8";
        }
        private void OnButtonClicked_9(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            if (Output.Text == "0")     
                Output.Text = "9";
            else
                Output.Text += "9";
        }
        private void OnButtonClicked_div(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            operand_1 = Convert.ToDouble(Output.Text);
            act = '/';
            Output.Text = "0";
        }
        private void OnButtonClicked_procent(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
                return;
            }
            if (operand_1 == 0)
                return;
            operand_2 = Convert.ToDouble(Output.Text);
            switch (act)
            {
                case '+':
                    operand_1 = operand_1 + (operand_1 * operand_2 * 0.01);
                    Output.Text = Convert.ToString(operand_1);
                    break;
                case '-':
                    operand_1 = operand_1 - (operand_1 * operand_2 * 0.01);
                    Output.Text = Convert.ToString(operand_1);
                    break;
                case '*':
                    operand_1 = operand_1 * (operand_1 * operand_2 * 0.01);
                    Output.Text = Convert.ToString(operand_1);
                    break;
                case '/':
                    if (operand_2 == 0)
                    {
                        Output.Text = "Делить на ноль невозможно";
                        error = 1;
                        break;
                    }
                    else
                    {
                        operand_1 = operand_1 / (operand_1 * operand_2 * 0.01);
                        Output.Text = Convert.ToString(operand_1);
                        break;
                    }
            }
            act = ' ';
        }
        private void OnButtonClicked_4(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            if (Output.Text == "0")     
                Output.Text = "4";
            else
                Output.Text += "4";
        }
        private void OnButtonClicked_5(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            if (Output.Text == "0")     
                Output.Text = "5";
            else
                Output.Text += "5";
        }
        private void OnButtonClicked_6(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            if (Output.Text == "0")     
                Output.Text = "6";
            else
                Output.Text += "6";
        }
        private void OnButtonClicked_mul(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            operand_1 = Convert.ToDouble(Output.Text);
            act = '*';
            Output.Text = "0";
        }
        private void OnButtonClicked_one_div_x(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            if (Double.IsInfinity(1 / Convert.ToDouble(Output.Text)))
            {
                Output.Text = "Не допустимая операция";
                error = 1;
                return;
            }
            Output.Text = (1 / Convert.ToDouble(Output.Text)).ToString();
        }
        private void OnButtonClicked_1(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            if (Output.Text == "0")     
                Output.Text = "1";
            else
                Output.Text += "1";
        }
        private void OnButtonClicked_2(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            if (Output.Text == "0")     
                Output.Text = "2";
            else
                Output.Text += "2";
        }
        private void OnButtonClicked_3(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            if (Output.Text == "0")     
                Output.Text = "3";
            else
                Output.Text += "3";
        }
        private void OnButtonClicked_minus(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            operand_1 = Convert.ToDouble(Output.Text);
            act = '-';
            Output.Text = "0";
        }
        private void OnButtonClicked_enter(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
                return;
            }
            operand_2 = Convert.ToDouble(Output.Text);
            switch (act)
            {
                case '+':
                    operand_1 = operand_1 + operand_2;
                    Output.Text = Convert.ToString(operand_1);
                    break;
                case '-':
                    operand_1 = operand_1 - operand_2;
                    Output.Text = Convert.ToString(operand_1);
                    break;
                case '*':
                    operand_1 = operand_1 * operand_2;
                    Output.Text = Convert.ToString(operand_1);
                    break;
                case '/':
                    if (operand_2 == 0)
                    {
                        Output.Text = "Делить на ноль невозможно";
                        error = 1;
                        break;
                    }
                    else
                    {
                        operand_1 = operand_1 / operand_2;
                        Output.Text = Convert.ToString(operand_1);
                        break;
                    }
            }
            act = ' ';
        }
        private void OnButtonClicked_0(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            // если поле = 0 то при нажатии на кнопку 0 второй ноль не ставить
            if (Output.Text != "0")
                Output.Text += "0";
        }
        private void OnButtonClicked_dot(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            // если точка уже есть то её больше не ставить 
            if (Regex.IsMatch(Output.Text, "\\."))    // двойной бекслешь для экранирования
                return;
            else
                Output.Text += ".";
        }
        private void OnButtonClicked_plus(object sender, System.EventArgs e)
        {
            if (error == 1)
            {
                Output.Text = "0";
                error = 0;
            }
            operand_1 = Convert.ToDouble(Output.Text);
            act = '+';
            Output.Text = "0";
        }
    }
}