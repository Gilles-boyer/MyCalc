using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalc
{
    class Operation
    {
        double result;

        /// <summary>
        /// Take String -> Convert to -> return Double
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static double ConvertStringToDouble(string number)
        {
            if(number.Contains("."))
            {
                number = number.Replace(".", ",");
            }
            return Convert.ToDouble(number);
        }

        /// <summary>
        /// Take number A and number B and perform operation 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="NumberA"></param>
        /// <param name="NumberB"></param>
        /// <returns>Result operation in String</returns>
        public string ToDoOperation( string NumberA, string NumberB = "0", string operation = "+")
        {
            double a = ConvertStringToDouble(NumberA);
            double b = ConvertStringToDouble(NumberB);

            result = operation switch
            {
                "+" when operation == "+" => a + b,
                "-" when operation == "-" => a - b,
                "*" when operation == "*" => a * b,
                "/" when operation == "/" => a / b,
                _ => a + b,
            };
            return ConvertDoubleToString(result);
        }

        /// <summary>
        /// Take Double -> Convert to -> return String for print
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static string ConvertDoubleToString(double number)
        {
            string result = number.ToString();

            if(result.Contains(","))
            {
                result = result.Replace(",", ".");
            }
            return result;
        }
    }
}
