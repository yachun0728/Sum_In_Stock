using System;
using System.Collections.Generic;

namespace In_Stock_Calculator
{
    public class InStockCalculator
    {
        public List<int> SumValue(int count, string column)
        {
            throw new NotImplementedException();
            //return new List<int>() { 6, 15, 24, 15 };
            //throw new ArgumentException();
        }

        protected virtual List<InStock> GetData()
        {
            throw new NotImplementedException();
        }
    }

    public class InStock
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }

    }
}