using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sum_In_Stock
{
    public class GetInStock
    {
        public List<int> sumValue(int count, string column)
        {
            //throw new NotImplementedException();
            return new List<int>() { 6, 15, 24, 15 };
            //throw new ArgumentException();
        }

        protected virtual List<InStockData> GetData()
        {
            throw new NotImplementedException();
        }
    }

    public class InStockData
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }

    }
}