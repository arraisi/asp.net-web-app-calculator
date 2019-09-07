using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;

namespace SimpleCalculator
{

    public partial class Default : System.Web.UI.Page
    {
        protected void Button0_Click(object sender, EventArgs e)
        {
            calc_result.Value = calc_result.Value + "0";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            calc_result.Value = calc_result.Value + "1";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            calc_result.Value = calc_result.Value + "2";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            calc_result.Value = calc_result.Value + "3";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            calc_result.Value = calc_result.Value + "4";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            calc_result.Value = calc_result.Value + "5";
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            calc_result.Value = calc_result.Value + "6";
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            calc_result.Value = calc_result.Value + "7";
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            calc_result.Value = calc_result.Value + "8";
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            calc_result.Value = calc_result.Value + "9";
        }

        protected void ButtonBracketsOpen_Click(object sender, EventArgs e)
        {
            calc_result.Value = calc_result.Value + "(";
        }

        protected void ButtonBracketsClose_Click(object sender, EventArgs e)
        {
            calc_result.Value = calc_result.Value + ")";
        }

        protected void ButtonDivide_Click(object sender, EventArgs e)
        {
            calc_result.Value = calc_result.Value + "/";
        }

        protected void ButtonMultiply_Click(object sender, EventArgs e)
        {
            calc_result.Value = calc_result.Value + "x";
        }


        protected void ButtonPlus_Click(object sender, EventArgs e)
        {
            if (calc_result.Value == string.Empty)
            {
                Response.Write("<script>alert('No Value is given.')</script>");
            }
            else
            {
                calc_result.Value = calc_result.Value + "+";
            }

        }

        protected void ButtonMinus_Click(object sender, EventArgs e)
        {
            if (calc_result.Value == string.Empty)
            {
                Response.Write("<script>alert('No Value is given.')</script>");
            }
            else
            {
                calc_result.Value = calc_result.Value + "-";
            }
        }

        protected void ButtonC_Click(object sender, EventArgs e)
        {
            if (calc_result.Value == string.Empty)
            {
                Response.Write("<script>alert('No Value is given.')</script>");
            }
            else
            {
                calc_result.Value = null;
            }
        }

        protected void ButtonCE_Click(object sender, EventArgs e)
        {
            if (calc_result.Value == string.Empty)
            {
                Response.Write("<script>alert('No Value is given.')</script>");
            }
            else
            {
                string CharactersInTextBox = calc_result.Value;
                string FinalCharactersInTextBox = string.Empty;

                for (int i = 0; i < CharactersInTextBox.Length - 1; i++)
                {
                    FinalCharactersInTextBox = FinalCharactersInTextBox + CharactersInTextBox[i];
                }

                calc_result.Value = FinalCharactersInTextBox;
            }

        }

        protected void ButtonEquals_Click(object sender, EventArgs e)
        {
            if (calc_result.Value == string.Empty)
            {
                Response.Write("<script>alert('No Value is given.')</script>");
            }
            else
            {
                double result = RemoveBrackets(calc_result.Value);
                calc_result.Value = Convert.ToString(result);
            }
        }

        private double RemoveBrackets(string textCalculated)
        {
            while (textCalculated.Contains("(") && textCalculated.Contains(")"))
            {
                int openIndex = 0;
                int closeIndex = 0;
                for (int i = 0; i < textCalculated.Length; i++)
                {
                    if (textCalculated[i].Equals('('))
                    {
                        openIndex = i;
                    }
                    if (textCalculated[i].Equals(')'))
                    {
                        closeIndex = i;

                        textCalculated = textCalculated.Remove(openIndex, closeIndex - openIndex + 1).Insert(openIndex, ResolveBrackets(openIndex, closeIndex, textCalculated));
                        break;
                    }
                }
            }
            for (int i = 1; i < textCalculated.Length; i++)
            {
                if (textCalculated[i].Equals('-') && (textCalculated[i - 1].Equals('x') || textCalculated[i - 1].Equals('/')))
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (textCalculated[j].Equals('+'))
                        {
                            StringBuilder _textValue = new StringBuilder(textCalculated);
                            _textValue[j] = '-';
                            textCalculated = _textValue.ToString();
                            textCalculated = textCalculated.Remove(i, 1);
                            break;
                        }
                        else if (textCalculated[j].Equals('-'))
                        {
                            StringBuilder _textValue = new StringBuilder(textCalculated);
                            _textValue[j] = '+';
                            textCalculated = _textValue.ToString();
                            textCalculated = textCalculated.Remove(i, 1);
                            break;
                        }
                    }
                }
            }

            if (textCalculated[0].Equals('-'))
            {
                textCalculated = '0' + textCalculated;
            }

            return Addition(textCalculated);
        }

        private string ResolveBrackets(int openIndex, int closeIndex, string textCalculated)
        {
            double result = Addition(textCalculated.Substring(openIndex + 1, closeIndex - openIndex - 1));
            return Convert.ToString(result);
        }


        private double Addition(string textCalculated)
        {
            String[] textCalculatedArray = textCalculated.Split('+');
            double total = Subtraction(textCalculatedArray[0]);
            for (int i = 1; i < textCalculatedArray.Length; i++)
            {
                total += Subtraction(textCalculatedArray[i]);
            }

            return total;
        }

        private double Subtraction(string textCalculated)
        {
            String[] textCalculatedArray = textCalculated.Split('-');
            double total = Multiplication(textCalculatedArray[0]);
            for (int i = 1; i < textCalculatedArray.Length; i++)
            {
                total -= Multiplication(textCalculatedArray[i]);
            }
            return total;
        }

        private double Multiplication(string textCalculated)
        {
            String[] textCalculatedArray = textCalculated.Split('x');

            double total = Division(textCalculatedArray[0]);
            for (int i = 1; i < textCalculatedArray.Length; i++)
            {
                total *= Division(textCalculatedArray[i]);
            }

            return total;
        }

        private double Division(string textCalculated)
        {
            String[] textCalculatedArray = textCalculated.Split('/');

            double total = Convert.ToDouble(textCalculatedArray[0]);
            for (int i = 1; i < textCalculatedArray.Length; i++)
            {
                total /= Convert.ToDouble(textCalculatedArray[i]);
            }

            return total;
        }
    }
}
