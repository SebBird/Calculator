using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        string input = "";
        int firstNumber = 0;
        int secondNumber = 0;
        char operation;

        public Calculator()
        {
            InitializeComponent();

        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            RefreshText(input, 0);
            input += 0;
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            RefreshText(input, 1);
            input += 1;
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            RefreshText(input, 2);
            input += 2;
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            RefreshText(input, 3);
            input += 3;
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            RefreshText(input, 4);
            input += 4;
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            RefreshText(input, 5);
            input += 5;
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            RefreshText(input, 6);
            input += 6;
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            RefreshText(input, 7);
            input += 7;
        }

        private void eightButon_Click(object sender, EventArgs e)
        {
            RefreshText(input, 8);
            input += 8;
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            RefreshText(input, 9);
            input += 9;
        }

        private void subtractButton_Click(object sender, EventArgs e)
        {
            if (!IsInputBlank(input))
            {
                if (firstNumber == 0)
                {
                    firstNumber = Convert.ToInt32(input);
                }
                else
                {
                    secondNumber = Convert.ToInt32(input);
                    firstNumber = Calculate(firstNumber, secondNumber, operation);
                    secondNumber = 0;
                }
            }
            input = "";
            operation = '-';
            resultText.Text = "-";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!IsInputBlank(input))
            {
                if (firstNumber == 0)
                {
                    firstNumber = Convert.ToInt32(input);
                }
                else
                {
                    secondNumber = Convert.ToInt32(input);
                    firstNumber = Calculate(firstNumber, secondNumber, operation);
                    secondNumber = 0;
                }
            }
            if (input == "")
            {
            }

            input = "";
            operation = '+';
            resultText.Text = "+";
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            if (!IsInputBlank(input))
            {
                if (firstNumber == 0)
                {
                    firstNumber = Convert.ToInt32(input);
                }
                else
                {
                    secondNumber = Convert.ToInt32(input);
                    firstNumber = Calculate(firstNumber, secondNumber, operation);
                    secondNumber = 0;
                }
            }

            input = "";
            operation = '*';
            resultText.Text = "x";
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            //Check if input is blank, if it isn't run the 'if' block
            if (!IsInputBlank(input))
            {
                if (firstNumber == 0)
                {
                    //If firstNumber hasn't been set, use the input to set it
                    firstNumber = Convert.ToInt32(input);
                }
                else
                {
                    //If firstNumber has been set, use it to set secondNumber. Then calculate the sum and set it firstNumber, and secondNumber back to 0 so that operations can continue.
                    secondNumber = Convert.ToInt32(input);
                    firstNumber = Calculate(firstNumber, secondNumber, operation);
                    secondNumber = 0;
                }
            }

            input = "";
            operation = '/';
            resultText.Text = "/";
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            //Check whether input is blank, as the Calculate method will not work without. If input is blank, then set it to zero to allow the user to continue with multisum operations
            int result = IsInputBlank(input) ? 0 : EqualSum(input, firstNumber, secondNumber, operation);

            firstNumber = result;
            secondNumber = 0;
            input = "";
            operation = ' ';
            resultText.Text = Convert.ToString(result);

        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            //Completely clears the calculator back to start-up conditions
            input = "";
            firstNumber = 0;
            secondNumber = 0;
            operation = ' ';
            resultText.Text = "";
        }

        private void clearInputButton_Click(object sender, EventArgs e)
        {
            //Clears the current input by the user without clearing the operator/first number
            input = "";
            resultText.Text = "";
        }

        private static int Calculate (int first, int second, char operation)
        {
            //Set the default result to zero, so that a value is always returned
            int intresult = 0;

            //Check the operator that has been entered and use this to calculate the appropriate sum
            switch(operation)
            {
                case '-':
                    intresult = first - second;
                    return intresult;

                case '+':
                    intresult = first + second;
                    return intresult;

                case '*':
                    intresult = first * second;
                    return intresult;

                case '/':
                    if (second == 0)
                    {
                        //Dividing by zero will crash the program, so throw an error box when the user attempts this and divide by 1 instead to prevent crash
                        MessageBox.Show("Cannot divide by zero!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        second = 1;
                        intresult = first / second;
                        return intresult;
                    }
                    intresult = first / second;
                    return intresult;
            }

            return intresult;
        }

        private void RefreshText (string input, int number)
        {
            resultText.Text = input;
            resultText.Text += number;
        }

        private static bool IsInputBlank (string input)
        {
            if (input == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int EqualSum (string input, int firstNum, int secondNum, char operation)
        {
            if (firstNum == 0)
            {
                firstNum = Convert.ToInt32(input);
            }
            else if (secondNum == 0)
            {
                secondNum = Convert.ToInt32(input);
            }
            else
            {
                firstNum = Calculate(firstNum, secondNum, operation);
                secondNum = Convert.ToInt32(input);
            }

            int result = Calculate(firstNum, secondNum, operation);
            return result;
        }
    }
}
