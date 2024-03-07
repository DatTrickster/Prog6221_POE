

namespace RecipieAppPoe
{
    using System;
    using System.Text;
    using MyNamespace;


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Welcome!!!");

            RecipEntry();
        }

        static void RecipEntry()
        {
            Console.ResetColor();

            Console.WriteLine("Enter number for items needed");
            int countForItems = Convert.ToInt32(Console.ReadLine()); // Read user input for the count
            ItemsToBeUsed[] ItemsArray = new ItemsToBeUsed[countForItems];

            Console.Beep();
            string confirmAllocation;
            bool Confirmed = false;
            Console.WriteLine(countForItems + " slots have been created. Confirm if it is correct (y/n)");

            do
            {
                confirmAllocation = Console.ReadLine();

                if (confirmAllocation == "y")
                {
                    Console.WriteLine("Thank you for confirming.");
                    Console.WriteLine(ItemsArray.Length + " slots set");
                    Confirmed = true;
                    Console.Beep();
                }
                else if (confirmAllocation == "n")
                {
                    Console.WriteLine("Please re-enter the allocation count:");
                    // Update countForItems based on user input
                    countForItems = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(countForItems + " slots have been created. Confirm if it is correct (y/n)");
                }
            } while (!Confirmed);

            for (int i = 0; i < countForItems; i++)
            {
                Console.WriteLine("Enter name of Ingredient:");
                string IngredianName = Console.ReadLine();
                Console.WriteLine("Enter Quantity needed:");
                double AmountRequired = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Measurement used:");
                string UnitOfMeasurement = Console.ReadLine();
                Console.WriteLine("Enter a description:");
                string description = Console.ReadLine();

                ItemsArray[i] = new ItemsToBeUsed()
                {
                    NameOfIngrediant = IngredianName,
                    Quantity = AmountRequired,
                    DescriptionOfItem = description,
                    UnitOfmeasurement = UnitOfMeasurement
                };
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Original Recipie:");

            StringBuilder output = new StringBuilder();
            foreach (var item in ItemsArray)
            {
                output.AppendLine($"Name of Ingredient: {item.NameOfIngrediant}\n   Quantity: {item.Quantity} {item.UnitOfmeasurement} \n Description:{item.DescriptionOfItem} \n");
            }
            Console.WriteLine(output.ToString());

            // Provide options for duplicating with different quantities
            Console.WriteLine("Do you want to duplicate the recipe?");
            Console.WriteLine("1. Duplicate with quantities multiplied by 0.5");
            Console.WriteLine("2. Duplicate with quantities multiplied by 2");
            Console.WriteLine("3. Duplicate with quantities multiplied by 3");
            Console.WriteLine("Enter your choice (1/2/3):");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    PrintDuplicateRecipe("Duplicate Recipie (0.5x Quantity):", ItemsArray, 0.5);
                    break;
                case 2:
                    PrintDuplicateRecipe("Duplicate Recipie (2x Quantity):", ItemsArray, 2);
                    break;
                case 3:
                    PrintDuplicateRecipe("Duplicate Recipie (3x Quantity):", ItemsArray, 3);
                    break;
                default:
                    Console.WriteLine("Invalid option selected.");
                    break;
            }
        }



        static void PrintDuplicateRecipe(string header, ItemsToBeUsed[] originalArray, double multiplier)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(header);

            StringBuilder output = new StringBuilder();
            foreach (var item in originalArray)
            {
                output.AppendLine($"Name of Ingredient: {item.NameOfIngrediant}\n   Quantity: {item.Quantity * multiplier} {item.UnitOfmeasurement} \n Description:{item.DescriptionOfItem} \n");
            }
            Console.WriteLine(output.ToString());
        }
    }
}






