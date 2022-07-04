using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearFunctions
{
    internal abstract class Function
    {
        public string FormulaString { get { return Formula; } }
        protected string Formula = "";
        public abstract double GetX(double y);
        public abstract double GetY(double x);
    }
}
