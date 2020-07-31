using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// دستور پخت 
    /// </summary>
    public class Recipe
    {

        private string title;
        private string instruction;
        private int servingcount;
        private string cuisine;
        private string[] keywords;
        
        /// <summary>
        /// ایجاد دستور پخت جدید
        /// </summary>
        /// <param name="title">عنوان</param>
        /// <param name="instructions">دستورات</param>
        /// <param name="ingredients">لیست مواد مورد نیاز</param>
        /// <param name="servingCount">تعداد افراد</param>
        /// <param name="cuisine">سبک غذا</param>
        /// <param name="keywords">کلمات کلیدی</param>
        public Recipe(string title, string instructions, Ingredient[] ingredients, int servingCount, string cuisine, string[] keywords)
        {
            this.title = title;
            this.instruction = instructions;
            this.Ingredients = ingredients;
            this.servingcount = servingCount;
            this.cuisine = cuisine;
            this.keywords = keywords;
        }

        /// <summary>
        /// ایجاد شئ دستور پخت جدید
        /// </summary>
        /// <param name="title">عنوان</param>
        /// <param name="instructions">دستورات</param>
        /// <param name="ingredientCount">تعداد مواد مورد نیاز</param>
        /// <param name="servingCount">تعداد افراد</param>
        /// <param name="cuisine">سبک غذا</param>
        /// <param name="keywords">کلمات کلیدی</param>
        public Recipe(string title, string instructions, int ingredientCount, int servingCount, string cuisine, string[] keywords)
        {
            this.title = title;
            this.instruction = instructions;
            this.Ingredientscount = ingredientCount;
            this.servingcount = servingCount;
            this.cuisine = cuisine;
            this.keywords = keywords;
        }

        /// <summary>
        /// اضافه کردن ماده اولیه 
        /// </summary>
        /// <param name="ingredient">ماده اولیه</param>
        /// <returns>عمل اضافه کردن موفقیت آمیز انجام شد یا خیر. در صورت تکمیل ظرفیت مقدار برگشتی "خیر" میباشد.</returns>
        public bool AddIngredient(Ingredient ingredient)
        {
            for (int i = 0; i < Ingredients.Length  || i < this.Ingredientscount ; i++)
            {
                if (Ingredients[i] == null)
                {
                    Ingredients[i] = ingredient;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// حذف تمام مواد اولیه که با نام ورودی تطبیق میکند
        /// </summary>
        /// <param name="name">نام ماده اولیه برای حذف</param>
        /// <returns>آیا حداقل یک ماده اولیه حذف شد؟</returns>
        public bool RemoveIngredient(string name)
        {
            for (int i = 0; i < Ingredients.Length || i < Ingredientscount; i++)
            {
                if (Ingredients[i] != null)
                {
                    if (Ingredients[i].Name.Equals(name))
                    {
                        Ingredients[i] = null;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// بروز کردن تعداد افرادی که این دستور غذا برای آن تعداد مناسب است
        /// مقادیر مواد اولیه به نسبت لازم اضافه میشود
        /// </summary>
        /// <param name="newServingCount">تعداد افراد جدید</param>
        public void UpdateServingCount(int newServingCount)
        {
            for (int i = 0; i < this.Ingredients.Length; i++)
            {
                this.Ingredients[i].Quantity = this.Ingredients[i].Quantity * newServingCount / this.servingcount;
            }
            this.servingcount = newServingCount;
        }

        /// <summary>
        /// فیلد پیشتیبان برای Ingredients.
        /// </summary>
        private Ingredient[] _Ingredients;

        /// <summary>
        /// مواد اولیه
        /// </summary>
        public Ingredient[] Ingredients {
            get
            {
                return _Ingredients;
            }
            private set
            {
                _Ingredients = value;
            }
        }

        /// <summary>
        /// عنوان غذا
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
            private set
            {
                title = value;
            }
        }

        /// <summary>
        /// دستور پخت غذا
        /// </summary>
        public string Instruction
        {
            get
            {
                return instruction;
            }
            private set
            {
                instruction = value;
            }
        }

        /// <summary>
        /// تعداد افرادی که این غذا را میتوان برای آنها تهیه کرد
        /// </summary>
        public int ServingCount
        {
            get
            {
                return servingcount;
            }
            private set
            {
                servingcount = value;
            }
        }

        /// <summary>
        /// سبک غذا
        /// </summary>
        public string Cuisine
        {
            get
            {
                return cuisine;
            }
            private set
            {
                cuisine = value;
            }
        }

        /// <summary>
        /// کلمات کلیدی غذا
        /// </summary>
        public string[] Keywords
        {
            get
            {
                return keywords;
            }
            private set
            {
                keywords = value;
            }
        }

        /// <summary>
        /// فیلد پیشتیبان برای Ingredientscount.
        /// </summary>
        private int _Ingredientscount;

        /// <summary>
        /// تعداد ingredients
        /// </summary>
        public int Ingredientscount
        {
            get
            {
                return _Ingredientscount;
            }
            set
            {
                _Ingredientscount = value;
            }
        }

        public override string ToString()
        {
            return $" {title} :\n   Instruction : {instruction}\n   It's for {servingcount} people.\n   Cuisine : {cuisine}";
        }
    }
}      