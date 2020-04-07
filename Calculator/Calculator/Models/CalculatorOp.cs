using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class CalculatorOp
    {
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public double Total { get; set; }        

        public CalculatorOp() { }

        public CalculatorOp(double num1, double num2)
        {
            Num1 = num1;
            Num2 = num2;
            Total = 0;
        }
        
        public double Resultado(double x, double y, string acao)
        {
            if(acao == "+")
            {
                return Total = x + y;
            }
            if(acao == "-")
            {
                return Total = x - y;
            }
            if (acao == "*")
            {
                return Total = x * y;
            }
            if (acao == "/")
            {
                return Total = x / y;
            }

            return Total = 0;            
        }

    }
}
