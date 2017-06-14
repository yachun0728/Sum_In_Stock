using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Sum_In_Stock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sum_In_Stock.Tests
{
    [TestClass()]
    public class Sum_In_StockTests
    {
        private List<InStockData> _fackData = new List<InStockData>()
        {
            new InStockData(){ Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
            new InStockData(){ Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
            new InStockData(){ Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
            new InStockData(){ Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
            new InStockData(){ Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
            new InStockData(){ Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
            new InStockData(){ Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
            new InStockData(){ Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
            new InStockData(){ Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
            new InStockData(){ Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
            new InStockData(){ Id = 11, Cost = 11, Revenue = 21, SellPrice = 31}
        };

        [TestMethod()]
        public void Count_is_3_Column_is_Cost_and_Return_is_6_15_24_21()
        {
            //arrange
            var getInStock = new GetFackInStock();

            //act
            getInStock.SetFakeData(_fackData);

            List<int> expected = new List<int>() { 6, 15, 24, 15 };
            List<int> actual = getInStock.sumValue(3, "Cost");

            //assert
            CollectionAssert.AreEquivalent(expected, actual);

        }

        [TestMethod()]
        public void Count_is_4_Column_is_Revenue_and_Return_is_50_66_60()
        {
            var getInStock = new GetFackInStock();

            getInStock.SetFakeData(_fackData);

            List<int> expected = new List<int>() { 50, 66, 60 };
            List<int> actual = getInStock.sumValue(4, "Revenue");

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Count_is_0_Column_is_Revenue_and_Return_is_Argument_Exception()
        {
            var getInStock = new GetFackInStock();
            getInStock.SetFakeData(_fackData);
            getInStock.sumValue(0, "Revenue");
            
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Count_is_Negative_1_Column_is_Revenue_and_Return_is_Argument_Exception()
        {
            var getInStock = new GetFackInStock();
            getInStock.SetFakeData(_fackData);
            getInStock.sumValue(-1, "Revenue");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Count_is_3_Column_is_Not_in_DB_and_Return_is_Argument_Exception()
        {
            var getInStock = new GetFackInStock();
            getInStock.SetFakeData(_fackData);
            getInStock.sumValue(-1, "Bonus");
        }
    }

    internal class GetFackInStock : GetInStock
    {
        private List<InStockData> _inStockData ;


        internal void SetFakeData(List<InStockData> fackData)
        {
            _inStockData = fackData;
        }

        protected override List<InStockData> GetData()
        {
            return this._inStockData;
        }
    }
}
