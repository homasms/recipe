using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Tests
{
    [TestClass()]
    public class IngredientTests
    {
        [TestMethod()]
        public void IngredientTest()
        {
            Ingredient a = new Ingredient("name1", "description1", 123, "gr");
            Ingredient b = new Ingredient("name2", "description2", 456, "kg");
            Assert.IsTrue(a.Name == "name1");
            Assert.IsTrue(b.Name == "name2");
            Assert.IsTrue(a.Description == "description1");
            Assert.IsTrue(b.Description == "description2");
            Assert.IsTrue(a.Quantity == 123);
            Assert.IsTrue(b.Quantity == 456);
            Assert.IsTrue(a.Unit == "gr");
            Assert.IsTrue(b.Unit == "kg");
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Ingredient a = new Ingredient("name1", "description1", 123, "gr");
            Assert.IsTrue(a.ToString() == "name1 :\t123 gr - description1");
        }
    }
}