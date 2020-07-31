using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// کتابچه دستور غذا
    /// </summary>
    public class RecipeBook
    {
        private int Capacity;
        private string Title;
        public Recipe[] Book;

        /// <summary>
        /// ایجاد شیء کتابچه دستور غذا
        /// </summary>
        /// <param name="title">عنوان کتابچه غذا</param>
        /// <param name="capacity">ظرفیت کتابچه</param>
        public RecipeBook(string title, int Capacity)
        {
            this.Capacity = Capacity;
            this.Title = title;
            Book = new Recipe[this.Capacity];
        }
        /// <summary>
        /// اضافه کردن یک دستور پخت جدید
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns>آیا اضافه کردن موفقیت آمیز انجام شد؟</returns>
        public bool Add(Recipe recipe)
        {
            for (int i = 0; i < Book.Length; i++)
            {
                if (Book[i] == null)
                {
                    Book[i] = recipe;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// حذف دستور پخت
        /// </summary>
        /// <param name="recipeTitle">عنوان دستور پخت</param>
        /// <returns>آیا حذف دستور پخت درست انجام شد؟</returns>
        public bool Remove(string recipeTitle)
        {
            for (int i = 0; i < Book.Length; i++)
            {
                if (Book[i] != null && Book[i].Title.Equals(recipeTitle))
                {
                    Book[i] = null;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// پیدا کردن دستور پخت با عنوان
        /// </summary>
        /// <param name="title">عنوان دستور پخت</param>
        /// <returns>شیء دستور پخت</returns>
        public Recipe LookupByTitle(string title)
        {
            for (int i = 0; i < Book.Length; i++)
            {
                if (Book[i] != null && Book[i].Title.Equals(title))
                {
                    return Book[i];
                }
            }
            return null;
        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با کلمه کلیدی
        /// </summary>
        /// <param name="keyword">کلمه کلیدی</param>
        /// <returns>دستور غذاهای دارای کلمه کلیدی</returns>
        public Recipe[] LookupByKeyword(string keyword)
        {
            LinkedList<Recipe> results = new LinkedList<Recipe>();
            for (int i = 0; i < Book.Length; i++)
            {
                if (Book[i] != null)
                {
                    for (int k = 0; k < Book[i].Keywords.Length; k++)
                    {
                        if (Book[i].Keywords[k].Equals(keyword))
                        {
                            results.AddLast(Book[i]);
                        }
                    }
                }
            }
            return results.ToArray();
        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با سبک پخت
        /// </summary>
        /// <param name="cuisine">سبک پخت</param>
        /// <returns>لیست دستور غذاهای سبک پخت داده شده</returns>
        public Recipe[] LookupByCuisine(string cuisine)
        {
            LinkedList<Recipe> results = new LinkedList<Recipe>();
            for (int i = 0; i < Book.Length; i++)
            {
                if (Book[i] != null && Book[i].Cuisine.Equals(cuisine))
                {
                    results.AddLast(Book[i]);
                }
            }
            return results.ToArray();
        }

        /// <summary>
        /// نمایش اطلاعات مربوط به یک غذا
        /// </summary>
        /// <param name="food">نام غذا</param>
        public void ShowDetails(Recipe food)
        {
            Console.WriteLine($"{food.ToString()}");
            Console.WriteLine("   Ingredients :");
            for (int j = 0; j < food.Ingredients.Length; j++)
            {
                Console.WriteLine($"     {food.Ingredients[j].ToString()}");
            }
            Console.WriteLine("   Keywords :");
            for (int k = 0; k < food.Keywords.Length; k++)
            {
                Console.WriteLine($"     {food.Keywords[k]}");
            }
        }

        /// <summary>
        /// ظرفیت کتابچه غذا
        /// </summary>
        public int TempCapacity
        {
            get
            {
                return Capacity;
            }
            private set
            {
                Capacity = value;
            }
        }

        /// <summary>
        /// عنوان کتابچه غذا
        /// </summary>
        public string TempTitle
        {
            get
            {
                return Title;
            }
            private set
            {
                Title = value;
            }
        }
    }
}
