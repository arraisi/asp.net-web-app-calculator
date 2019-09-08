using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Collections;

namespace SimpleCalculator
{

    public partial class Default : System.Web.UI.Page
    {
        protected void Button0_Click(object sender, EventArgs e)
        {
            calculationText.Value += "0";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            calculationText.Value += "1";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            calculationText.Value += "2";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            calculationText.Value += "3";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            calculationText.Value += "4";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            calculationText.Value += "5";
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            calculationText.Value += "6";
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            calculationText.Value += "7";
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            calculationText.Value += "8";
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            calculationText.Value += "9";
        }

        protected void ButtonBracketsOpen_Click(object sender, EventArgs e)
        {
            calculationText.Value += "(";
        }

        protected void ButtonBracketsClose_Click(object sender, EventArgs e)
        {
            calculationText.Value += ")";
        }

        protected void ButtonDivide_Click(object sender, EventArgs e)
        {
            calculationText.Value += "/";
        }

        protected void ButtonMultiply_Click(object sender, EventArgs e)
        {
            calculationText.Value += "x";
        }


        protected void ButtonPlus_Click(object sender, EventArgs e)
        {
            if (calculationText.Value == string.Empty)
            {
                Response.Write("<script>alert('No Value is given.')</script>");
            }
            else
            {
                calculationText.Value += "+";
            }

        }

        protected void ButtonMinus_Click(object sender, EventArgs e)
        {
            if (calculationText.Value == string.Empty)
            {
                Response.Write("<script>alert('No Value is given.')</script>");
            }
            else
            {
                calculationText.Value += "-";
            }
        }

        protected void ButtonC_Click(object sender, EventArgs e)
        {
            if (calculationText.Value == string.Empty)
            {
                Response.Write("<script>alert('No Value is given.')</script>");
            }
            else
            {
                calculationText.Value = null;
            }
        }

        protected void ButtonCE_Click(object sender, EventArgs e)
        {
            if (calculationText.Value == string.Empty)
            {
                Response.Write("<script>alert('No Value is given.')</script>");
            }
            else
            {
                string CharactersInTextBox = calculationText.Value;
                string FinalCharactersInTextBox = string.Empty;

                for (int i = 0; i < CharactersInTextBox.Length - 1; i++)
                {
                    FinalCharactersInTextBox = FinalCharactersInTextBox + CharactersInTextBox[i];
                }

                calculationText.Value = FinalCharactersInTextBox;
            }

        }

        protected void ButtonEquals_Click(object sender, EventArgs e)
        {
            if (calculationText.Value == string.Empty)
            {
                Response.Write("<script>alert('No Value is given.')</script>");
            }
            else
            {
                double result = RemoveBrackets(calculationText.Value);
                calculationText.Value = Convert.ToString(result);
            }
        }

        private double RemoveBrackets(string calculatedText)
        {
            while (calculatedText.Contains("(") && calculatedText.Contains(")"))
            {
                int openIndex = 0;
                int closeIndex = 0;
                for (int i = 0; i < calculatedText.Length; i++)
                {
                    if (calculatedText[i].Equals('('))
                    {
                        openIndex = i;
                    }
                    if (calculatedText[i].Equals(')'))
                    {
                        closeIndex = i;

                        calculatedText = calculatedText.Remove(openIndex, closeIndex - openIndex + 1).Insert(openIndex, ResolveBrackets(openIndex, closeIndex, calculatedText));
                        break;
                    }
                }
            }

            for (int i = 1; i < calculatedText.Length; i++)
            {
                if (calculatedText[i].Equals('-') && (calculatedText[i - 1].Equals('x') || calculatedText[i - 1].Equals('/')))
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (calculatedText[j].Equals('+'))
                        {
                            StringBuilder _textValue = new StringBuilder(calculatedText);
                            _textValue[j] = '-';
                            calculatedText = _textValue.ToString();
                            calculatedText = calculatedText.Remove(i, 1);
                            break;
                        }
                        else if (calculatedText[j].Equals('-'))
                        {
                            StringBuilder _textValue = new StringBuilder(calculatedText);
                            _textValue[j] = '+';
                            calculatedText = _textValue.ToString();
                            calculatedText = calculatedText.Remove(i, 1);
                            break;
                        }
                    }
                }
            }


            for (int i = 2; i < calculatedText.Length; i++)
            {
                if (calculatedText[i].Equals('-') && (calculatedText[i-1].Equals('+')|| calculatedText[i - 1].Equals('x') || calculatedText[i - 1].Equals('/')))
                {
                    for (int j = i-1; j >= 0; j--)
                    {
                        if (calculatedText[j].Equals('+'))
                        {
                            StringBuilder _textValue = new StringBuilder(calculatedText);
                            _textValue[j] = '-';
                            calculatedText = _textValue.ToString();
                            calculatedText = calculatedText.Remove(i, 1);
                            break;
                        } else {
                            calculatedText = calculatedText.Remove(i, 1);
                            StringBuilder _textValue = new StringBuilder(calculatedText);
                            _textValue.Insert(0, '-');
                            calculatedText = _textValue.ToString();
                            break;
                        }
                    }
                }
            }

            if (calculatedText[0].Equals('-'))
            {
                calculatedText = '0' + calculatedText;
            }

            return Addition(calculatedText);
        }

        private string ResolveBrackets(int openIndex, int closeIndex, string calculatedText)
        {
            double result = Addition(calculatedText.Substring(openIndex + 1, closeIndex - openIndex - 1));
            return Convert.ToString(result);
        }


        private double Addition(string calculatedText)
        {
            String[] calculatedTextArray = calculatedText.Split('+');
            double total = Subtraction(calculatedTextArray[0]);
            for (int i = 1; i < calculatedTextArray.Length; i++)
            {
                total += Subtraction(calculatedTextArray[i]);
            }

            return total;
        }

        private double Subtraction(string calculatedText)
        {
            string[] calculatedTextArray = calculatedText.Split('-');
            if(calculatedTextArray.Length == 2 && calculatedTextArray[0] == string.Empty)
            {
                return Convert.ToDouble("-" + calculatedTextArray[1]);
            }
            double total = Multiplication(calculatedTextArray[0]);
            for (int i = 1; i < calculatedTextArray.Length; i++)
            {
                total -= Multiplication(calculatedTextArray[i]);
            }
            return total;
        }

        private double Multiplication(string calculatedText)
        {
            String[] calculatedTextArray = calculatedText.Split('x');

            double total = Division(calculatedTextArray[0]);
            for (int i = 1; i < calculatedTextArray.Length; i++)
            {
                total *= Division(calculatedTextArray[i]);
            }

            return total;
        }

        private double Division(string calculatedText)
        {
            String[] calculatedTextArray = calculatedText.Split('/');

            double total = Convert.ToDouble(calculatedTextArray[0]);
            for (int i = 1; i < calculatedTextArray.Length; i++)
            {
                total /= Convert.ToDouble(calculatedTextArray[i]);
            }

            return total;
        }
    }
}
