using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            int RecipeBookCapacity = 20;
            RecipeBook fromMom = new RecipeBook("دستور پخت های مادر", RecipeBookCapacity);

            ConsoleKeyInfo cki;
            do
            {

                Console.WriteLine($"Press N(ew), D(el), S(earch)or L(ist)");
                cki = Console.ReadKey();
                Console.WriteLine();
                switch (cki.Key)
                {
                    case ConsoleKey.N:

                        Console.WriteLine("New Recipe");
                        Console.WriteLine("Enter the title :");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter the instruction :");
                        string recInstruction = Console.ReadLine();
                        Console.WriteLine("Enter the number of ingredients :");
                        int ingredientCount = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the the number of people that this food can feed :");
                        int serCount = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the cuisine :");
                        string cuisine = Console.ReadLine();
                        Console.WriteLine("Enter the keywords and separate them with ',' :");
                        string[] keywords = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        Recipe food = new Recipe(title, recInstruction, new Ingredient[ingredientCount], serCount, cuisine, keywords);
                        food.Ingredientscount = ingredientCount;
                        for (int i = 0; i < ingredientCount; i++)
                        {
                            Console.WriteLine($"ingredient {i + 1} of {ingredientCount} : ");
                            Console.WriteLine("Enter the name : ");
                            string ingName = Console.ReadLine();
                            Console.WriteLine("Enter the description : ");
                            string description = Console.ReadLine();
                            Console.WriteLine("Enter the quantity : ");
                            double quanty = double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the unit :");
                            string unit = Console.ReadLine();
                            Ingredient ing = new Ingredient(ingName, description, quanty, unit);

                            if (food.AddIngredient(ing))
                            {
                                Console.WriteLine("Ingredient added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("You can't add new ingredient anymore.");
                            }
                        }
                        if (fromMom.Add(food))
                        {
                            RecipeBookCapacity--;
                            Console.WriteLine("This recipe added successfully.");
                            Console.WriteLine($"{RecipeBookCapacity} capacity remaining.");
                        }
                        else
                        {
                            Console.WriteLine("You can't add new recipe anymore.");
                        }
                        break;

                    case ConsoleKey.D:

                        Console.WriteLine("Delete Recipe");
                        Console.WriteLine("Enter the title of recipe that you want to delete :");
                        string name = Console.ReadLine();
                        if (fromMom.Remove(name))
                        {
                            Console.WriteLine("Recipe deleted successfully.");
                        }
                        else
                        { 
                            Console.WriteLine("Nothing deleted.");
                        }
                        break;

                    case ConsoleKey.S:

                        string answer;
                        string SearchWay;
                        Console.WriteLine("Search Recipe");
                        Console.WriteLine("How do you want to find your recipe('t' for title, 'c' for cuisine, 'k' for keyword) :");
                        bool loop = true;
                        do
                        {
                            SearchWay = Console.ReadLine();
                            if (SearchWay == "t")
                            {
                                Console.WriteLine("Enter the title :");
                                answer = Console.ReadLine();
                                Recipe resault = fromMom.LookupByTitle(answer);
                                if (resault != null)
                                {
                                    fromMom.ShowDetails(fromMom.LookupByTitle(answer));
                                }
                                else
                                {
                                    Console.WriteLine("There is not any recipes with the title that you enter.");
                                }
                                loop = false;
                            }
                            else if (SearchWay == "c")
                            {
                                Console.WriteLine("Enter the cuisine :");
                                answer = Console.ReadLine();
                                Recipe[] array = new Recipe[1];
                                array = fromMom.LookupByCuisine(answer);
                                if (array != null)
                                {
                                    for (int i = 0; i < array.Length; i++)
                                    {
                                        fromMom.ShowDetails(array[i]);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("There is not any recipes with the cuisine that you enter.");
                                }
                                loop = false;
                            }
                            else if (SearchWay == "k")
                            {
                                Console.WriteLine("Enter the keyword :");
                                answer = Console.ReadLine();
                                Recipe[] array = new Recipe[1];
                                array = fromMom.LookupByKeyword(answer);
                                if (array != null)
                                {
                                    for (int i = 0; i < array.Length; i++)
                                    {
                                        fromMom.ShowDetails(array[i]);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("There is not any recipes with the keyword that you enter.");
                                }
                                loop = false;
                            }
                            else
                            {
                                Console.WriteLine("invalid key!! Enter another kay :");
                            }
                        }
                        while (loop == true);
                        break;

                    case ConsoleKey.L:

                        Console.WriteLine("List Recipes");
                        for (int i = 0; i < fromMom.Book.Length; i++)
                        {
                            if (fromMom.Book[i] != null)
                            {
                                Console.WriteLine($"recipe {i + 1} : {fromMom.Book[i].Title}");
                            }
                            else if (i == 0)
                            {
                                Console.WriteLine("You didn't add any recipes yet.");
                            }
                        }
                        break;

                    case ConsoleKey.Escape:

                        Console.WriteLine("Esc");
                        break;

                    default:

                        Console.WriteLine($"Invalid Key: {cki.KeyChar}");
                        break;
                }

                Console.WriteLine("Press any key to continue, Esc to exit");
                cki = Console.ReadKey();
                Console.Clear();
            }
            while (cki.Key != ConsoleKey.Escape);
        }        
    }
}
