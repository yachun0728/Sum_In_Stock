using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace In_Stock_Calculator.Tests
{
    [TestClass()]
    public class In_Stock_CalculatorTests
    {
        private List<InStock> _instocks = new List<InStock>()
        {
            new InStock(){ Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
            new InStock(){ Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
            new InStock(){ Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
            new InStock(){ Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
            new InStock(){ Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
            new InStock(){ Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
            new InStock(){ Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
            new InStock(){ Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
            new InStock(){ Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
            new InStock(){ Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
            new InStock(){ Id = 11, Cost = 11, Revenue = 21, SellPrice = 31}
        };

        [TestMethod()]
        public void Count_is_3_Column_is_Cost_and_Return_is_6_15_24_21()
        {
            var getInStock = new FackInStockCalculator();

            getInStock.SetFakeData(_instocks);

            List<int> expected = new List<int>() { 6, 15, 24, 15 };
            List<int> actual = getInStock.SumValue(3, "Cost");

            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void Count_is_4_Column_is_Revenue_and_Return_is_50_66_60()
        {
            var getInStock = new FackInStockCalculator();

            getInStock.SetFakeData(_instocks);

            List<int> expected = new List<int>() { 50, 66, 60 };
            List<int> actual = getInStock.SumValue(4, "Revenue");

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Count_is_0_Column_is_Revenue_and_Return_is_Argument_Exception()
        {
            var getInStock = new FackInStockCalculator();
            getInStock.SetFakeData(_instocks);
            getInStock.SumValue(0, "Revenue");
            
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Count_is_Negative_1_Column_is_Revenue_and_Return_is_Argument_Exception()
        {
            var getInStock = new FackInStockCalculator();
            getInStock.SetFakeData(_instocks);
            getInStock.SumValue(-1, "Revenue");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Count_is_3_Column_is_Not_in_DB_and_Return_is_Argument_Exception()
        {
            var getInStock = new FackInStockCalculator();
            getInStock.SetFakeData(_instocks);
            getInStock.SumValue(-1, "Bonus");
        }
    }

    internal class FackInStockCalculator : InStockCalculator
    {
        private List<InStock> _inStockData ;


        internal void SetFakeData(List<InStock> fackData)
        {
            _inStockData = fackData;
        }

        protected override List<InStock> GetData()
        {
            return this._inStockData;
        }
    }
}
