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
        public string RangeString { get { return Range; } }
        protected string Range = ""; // Область значений
        public string DomainString { get { return Domain; } }
        protected string Domain = ""; // Область определения
        public abstract double? GetX(double y);
        public abstract double? GetY(double x);
    }
}
