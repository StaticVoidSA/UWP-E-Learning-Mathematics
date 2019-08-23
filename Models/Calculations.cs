using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Maths_Quiz_New.Models
{
    public class Calculations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Sub(int a, int b)
        {
            return a - b;
        }

        public int Div(int a, int b)
        {
            return a / b;
        }

        public int Mul(int a, int b)
        {
            return a * b; 
        }
        
        public int Rem(int a, int b)
        {
            return a % b;
        }
    }
}
