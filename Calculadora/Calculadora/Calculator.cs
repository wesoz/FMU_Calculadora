using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculadora
{
    class Calculator
    {
        static string memoryValue;
        static string value;
        static bool isZero = true;
        static TextBox txtValue;
        static Label lblEquation;
        static string[] validSignals = { "+", "-", "X", "÷", "=" };
        static string signal = null;

        public static void Initialize(TextBox txtValue, Label lblEquation)
        {
            Calculator.txtValue = txtValue;
            Calculator.lblEquation = lblEquation;
        }

        public static void Put(string stringValue)
        {
            double dummy;
            if (double.TryParse(Calculator.value + stringValue, out dummy))
            {
                Calculator.PutNumber(stringValue);
            }
            else if (!Calculator.isZero && Calculator.validSignals.Contains(stringValue))
            {
                if (stringValue == "=")
                {
                    Calculator.ComputeEquals();
                }
                else if (string.IsNullOrWhiteSpace(Calculator.signal))
                {
                    Calculator.PutSignal(stringValue);
                }
                else
                {
                    Calculator.ComputeEquals();
                    Calculator.signal = stringValue;
                }
            }
        }

        private static void ComputeEquals()
        {
            string equation = Calculator.lblEquation.Text;
            Calculator.Clear();
            Calculator.txtValue.Text = new DataTable().Compute(equation, null).ToString();
            Calculator.lblEquation.Text = string.Format("{0} =", equation);
        }

        private static void PutSignal(string stringValue)
        {
            Calculator.signal = stringValue;
            Calculator.lblEquation.Text += string.Format(" {0} ", stringValue);
            Calculator.memoryValue = Calculator.value;
            Calculator.value = "";
            Calculator.isZero = true;
        }

        private static void PutNumber(string stringValue)
        {
            if (isZero)
            {
                Calculator.value = stringValue;
                isZero = false;
            }
            else
            {
                Calculator.value += stringValue;
            }
            Calculator.txtValue.Text = Calculator.value;
            Calculator.lblEquation.Text += stringValue;
        }

        internal static void Clear()
        {
            Calculator.txtValue.Text = "0";
            Calculator.lblEquation.Text = "";
            Calculator.isZero = true;
            Calculator.signal = null;
            Calculator.memoryValue = "";
            Calculator.value = "";
        }
    }
}
