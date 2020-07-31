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
    public class RecipeTests
    {
        [TestMethod()]
        public void RecipeTest()
        {
            Ingredient a = new Ingredient("name1", "description1", 123, "gr");
            Ingredient b = new Ingredient("name2", "description2", 456, "kg");
            Recipe food = new Recipe(
                "kabab",
                "charkh karde",
                new Ingredient[] { a, b },
                3,
                "irani",
                new string[] { "irani", "kabab" }
            );
            Assert.AreEqual("kabab", food.Title);
            Assert.AreEqual("charkh karde", food.Instruction);
            Assert.AreEqual("irani", food.Cuisine);
            Assert.AreEqual(3, food.ServingCount);
            Assert.AreEqual("irani", food.Keywords[0]);
            Assert.AreEqual("kabab", food.Keywords[1]);
            Assert.AreEqual("name1", food.Ingredients[0].Name);
            Assert.AreEqual("name2", food.Ingredients[1].Name);
            Assert.AreEqual("description1", food.Ingredients[0].Description);
            Assert.AreEqual("description2", food.Ingredients[1].Description);
            Assert.AreEqual(123, food.Ingredients[0].Quantity);
            Assert.AreEqual(456, food.Ingredients[1].Quantity);
            Assert.AreEqual("gr", food.Ingredients[0].Unit);
            Assert.AreEqual("kg", food.Ingredients[1].Unit);
        }

        [TestMethod()]
        public void RecipeTest1()
        {
            Ingredient a = new Ingredient("name1", "description1", 123, "gr");
            Ingredient b = new Ingredient("name2", "description2", 456, "kg");
            Recipe food = new Recipe(
                "kabab",
                "charkh karde",
                2,
                3,
                "irani",
                new string[] { "irani", "kabab" }
            );
            Assert.AreEqual("kabab", food.Title);
            Assert.AreEqual("charkh karde", food.Instruction);
            Assert.AreEqual("irani", food.Cuisine);
            Assert.AreEqual(3, food.ServingCount);
            Assert.AreEqual("irani", food.Keywords[0]);
            Assert.AreEqual("kabab", food.Keywords[1]);
            Assert.AreEqual(2, food.Ingredientscount);
        }

        [TestMethod()]
        public void AddIngredientTest()
        {
            Recipe food = new Recipe("food", "instruction", new Ingredient[2], 2, "cuisine", new string[] { "keyword1", "keyword2" });
            Ingredient a = new Ingredient("name1", "description1", 123, "gr");
            Ingredient b = new Ingredient("name2", "description2", 456, "kg");
            Ingredient c = new Ingredient("name3", "description3", 789, "kg");
            Assert.IsTrue(food.AddIngredient(a));
            Assert.IsTrue(food.AddIngredient(b));
            Assert.IsFalse(food.AddIngredient(c));
        }

        [TestMethod()]
        public void RemoveIngredientTest()
        {
            Ingredient a = new Ingredient("name1", "description1", 123, "gr");
            Ingredient b = new Ingredient("name2", "description2", 456, "kg");
            Ingredient c = new Ingredient("name3", "description3", 789, "kg");
            Recipe food = new Recipe("food",
                "instruction",
                new Ingredient[] { a, b },
                2,
                "cuisine",
                new string[] { "keyword1", "keyword2" });
            Assert.IsTrue(food.RemoveIngredient(a.Name));
            Assert.IsTrue(food.RemoveIngredient(b.Name));
            Assert.IsFalse(food.RemoveIngredient(c.Name));
        }

        [TestMethod()]
        public void UpdateServingCountTest()
        {
            Ingredient a = new Ingredient("name1", "description1", 123, "gr");
            Ingredient b = new Ingredient("name2", "description2", 456, "kg");
            Recipe food = new Recipe("food",
                "instruction",
                new Ingredient[] { a, b },
                2,
                "cuisine",
                new string[] { "keyword1", "keyword2" });
            food.UpdateServingCount(4);
            Assert.AreEqual(246, a.Quantity);
            Assert.AreEqual(912, b.Quantity);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Ingredient a = new Ingredient("ingredient", "description", 123, "gr");
            Recipe food = new Recipe("recipe",
                "instruction",
                new Ingredient[] { a }, 2,
                "irani",
                new string[] { "irani", "kabab" });
            Assert.AreEqual(food.ToString(), 
                " recipe :\n   Instruction : instruction\n   It's for 2 people.\n   Cuisine : irani");
        }
    }
}