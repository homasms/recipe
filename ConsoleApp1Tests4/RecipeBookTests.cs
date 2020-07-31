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
    public class RecipeBookTests
    {
        [TestMethod()]
        public void RecipeBookTest()
        {
            RecipeBook book = new RecipeBook("recipeBook", 10);
            Assert.AreEqual("recipeBook", book.TempTitle);
            Assert.AreEqual(10, book.TempCapacity);
        }

        [TestMethod()]
        public void AddTest()
        {
            Ingredient a = new Ingredient("name1", "description1", 123, "gr");
            Ingredient b = new Ingredient("name2", "description2", 456, "kg");
            Recipe food = new Recipe(
                "kabab",
                "charkh karde",
                new Ingredient[] { a },
                3,
                "irani",
                new string[] { "irani", "kabab" }
            );
            Recipe food1 = new Recipe(
                "joje",
                "kabab karde",
                new Ingredient[] { b },
                2,
                "irani",
                new string[] { "irani", "joje" }
            );
            RecipeBook book = new RecipeBook("recipeBook", 1);
            Assert.IsTrue(book.Add(food));
            Assert.IsFalse(book.Add(food1));

        }

        [TestMethod()]
        public void RemoveTest()
        {
            Ingredient a = new Ingredient("name1", "description1", 123, "gr");
            Ingredient b = new Ingredient("name2", "description2", 456, "kg");
            Recipe food = new Recipe(
                "kabab",
                "charkh karde",
                new Ingredient[] { a },
                3,
                "irani",
                new string[] { "irani", "kabab" }
            );
            Recipe food1 = new Recipe(
                "joje",
                "kabab karde",
                new Ingredient[] { b },
                2,
                "irani",
                new string[] { "irani", "joje" }
            );
            RecipeBook book = new RecipeBook("recipeBook", 1);
            book.Add(food);
            Assert.IsTrue(book.Remove("kabab"));
            Assert.IsFalse(book.Remove("joje"));
        }

        [TestMethod()]
        public void LookupByTitleTest()
        {
            Ingredient a = new Ingredient("name1", "description1", 123, "gr");
            Ingredient b = new Ingredient("name2", "description2", 456, "kg");
            Recipe food = new Recipe(
                "kabab",
                "charkh karde",
                new Ingredient[] { a },
                3,
                "irani",
                new string[] { "irani", "kabab" }
            );
            Recipe food1 = new Recipe(
                "joje",
                "kabab karde",
                new Ingredient[] { b },
                2,
                "irani",
                new string[] { "irani", "joje" }
            );
            RecipeBook book = new RecipeBook("recipeBook", 2);
            book.Add(food);
            book.Add(food1);
            Assert.AreEqual(food, book.LookupByTitle(food.Title));
        }

        [TestMethod()]
        public void LookupByKeywordTest()
        {
            Ingredient a = new Ingredient("name1", "description1", 123, "gr");
            Ingredient b = new Ingredient("name2", "description2", 456, "kg");
            Recipe food = new Recipe(
                "kabab",
                "charkh karde",
                new Ingredient[] { a },
                3,
                "irani",
                new string[] { "irani", "kabab" }
            );
            Recipe food1 = new Recipe(
                "joje",
                "kabab karde",
                new Ingredient[] { b },
                2,
                "irani",
                new string[] { "irani", "joje" }
            );
            RecipeBook book = new RecipeBook("recipeBook", 2);
            book.Add(food);
            book.Add(food1);
            Assert.IsTrue(new Recipe[] { food }.SequenceEqual(book.LookupByKeyword("kabab")));
        }

        [TestMethod()]
        public void LookupByCuisineTest()
        {
            Ingredient a = new Ingredient("name1", "description1", 123, "gr");
            Ingredient b = new Ingredient("name2", "description2", 456, "kg");
            Recipe food = new Recipe(
                "kabab",
                "charkh karde",
                new Ingredient[] { a },
                3,
                "irani",
                new string[] { "irani", "kabab" }
            );
            Recipe food1 = new Recipe(
                "joje",
                "kabab karde",
                new Ingredient[] { b },
                2,
                "irani",
                new string[] { "irani", "joje" }
            );
            RecipeBook book = new RecipeBook("recipeBook", 2);
            book.Add(food);
            book.Add(food1);
            Assert.IsTrue(new Recipe[] { food, food1 }.SequenceEqual(book.LookupByCuisine("irani")));
        }
    }
}