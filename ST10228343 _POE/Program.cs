using System.Xml.Linq;

namespace RecipeAppPoe
{
    using MyNamespace; // Importing custom namespace
    using System;
    using System.Text;
    // start of the method
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowMainMenu(); // Show the main menu to start or exit the application
        }

        static void ShowMainMenu()
        {
            bool exitRequested = false;
            do
            {
                Console.WriteLine("Welcome to the Recipe Application!");
                Console.WriteLine("1. Start");
                Console.WriteLine("2. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunRecipeApp(); // If user chooses to start, run the recipe app
                        break;
                    case "2":
                        Console.WriteLine("Exiting the application...");
                        exitRequested = true; // If user chooses to exit, set exitRequested to true
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                        break;
                }

            } while (!exitRequested); // Continue showing the main menu until exit is requested
        }

        static void RunRecipeApp()
        {
            Console.ForegroundColor = ConsoleColor.Magenta; // Set console color
            Console.WriteLine("Welcome!!!");

            bool exitRequested = false;
            do
            {
                RecipEntry(); // Call method for recipe entry

                Console.WriteLine("Do you want to exit the application? (yes/no)");
                string exitChoice = Console.ReadLine().ToLower(); // Prompt user for exit confirmation
                if (exitChoice == "yes" || exitChoice == "y") // Check if user wants to exit
                {
                    exitRequested = true;
                }
            } while (!exitRequested); // Continue loop until exit is requested
        }

        static void RecipEntry()
        {
            Console.ResetColor(); // Reset console color

            Console.WriteLine("Enter number for items needed");
            int countForItems = 0;
            bool validCount = false;
            do
            {
                try
                {
                    countForItems = Convert.ToInt32(Console.ReadLine()); // Read user input for the count of items needed
                    if (countForItems <= 0)
                    {
                        Console.WriteLine("Please enter a positive integer value for the number of items needed."); // Validate input
                    }
                    else
                    {
                        validCount = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer value."); // Handle format exception
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Input value is too large. Please enter a smaller value."); // Handle overflow exception
                }
            } while (!validCount);

            ItemsToBeUsed[] originalItemsArray = new ItemsToBeUsed[countForItems]; // Initialize array for original items

            Console.Beep(); // Emit a beep sound
            string confirmAllocation;
            bool confirmed = false;
            Console.WriteLine($"{countForItems} slots have been created. Confirm if it is correct (y/n)"); // Confirm allocation with user

            do
            {
                confirmAllocation = Console.ReadLine(); // Read user input for confirmation

                if (confirmAllocation == "y")
                {
                    Console.WriteLine("Thank you for confirming."); // Confirm allocation
                    Console.WriteLine($"{originalItemsArray.Length} slots set");
                    confirmed = true;
                    Console.Beep();
                }
                else if (confirmAllocation == "n")
                {
                    Console.WriteLine("Please re-enter the allocation count:"); // Request re-entry of count
                    validCount = false;
                    do
                    {
                        try
                        {
                            countForItems = Convert.ToInt32(Console.ReadLine()); // Read user input for count again
                            if (countForItems <= 0)
                            {
                                Console.WriteLine("Please enter a positive integer value for the number of items needed."); // Validate input
                            }
                            else
                            {
                                validCount = true;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer value."); // Handle format exception
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Input value is too large. Please enter a smaller value."); // Handle overflow exception
                        }
                    } while (!validCount);
                    originalItemsArray = new ItemsToBeUsed[countForItems]; // Re-initialize array with new count/
                    Console.WriteLine($"{countForItems} slots have been created. Confirm if it is correct (y/n)"); // Confirm new allocation
                }
            } while (!confirmed); // Continue loop until confirmed

            for (int i = 0; i < countForItems; i++)
            {
                Console.WriteLine("Enter name of Ingredient:");
                string IngredianName = Console.ReadLine(); // Read name of ingredient
                Console.WriteLine("Enter Quantity needed:");
                double AmountRequired = 0;
                bool validQuantity = false;
                do
                {
                    try
                    {
                        AmountRequired = Convert.ToDouble(Console.ReadLine()); // Read quantity required
                        if (AmountRequired <= 0)
                        {
                            Console.WriteLine("Please enter a positive value for the quantity needed."); // Validate input
                        }
                        else
                        {
                            validQuantity = true;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number."); // Handle format exception
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Input value is too large. Please enter a smaller value."); // Handle overflow exception
                    }
                } while (!validQuantity);
                Console.WriteLine("Enter Measurement used:");
                string UnitOfMeasurement = Console.ReadLine(); // Read unit of measurement
                Console.WriteLine("Enter a description:");
                string description = Console.ReadLine(); // Read description

                originalItemsArray[i] = new ItemsToBeUsed() // Create new item object and add to array
                {
                    NameOfIngrediant = IngredianName,
                    Quantity = AmountRequired,
                    DescriptionOfItem = description,
                    UnitOfmeasurement = UnitOfMeasurement
                };
            }

            Console.ForegroundColor = ConsoleColor.Blue; // Set console foreground color to blue
            Console.WriteLine("Original Recipe:"); // Print original recipe header

            PrintRecipe(originalItemsArray); // Print original recipe

            // Provide options for duplicating with different quantities
            bool revertToOriginal = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green; // Set console foreground color
                Console.WriteLine("1. Duplicate with quantities multiplied by 0.5");
                Console.WriteLine("2. Duplicate with quantities multiplied by 2");
                Console.WriteLine("3. Duplicate with quantities multiplied by 3");
                Console.WriteLine("4. Revert to Original Recipe");
                Console.WriteLine("5. Exit Application");
                Console.ResetColor(); // Reset console color
                Console.WriteLine("Enter your choice (1/2/3/4/5):"); // Prompt user for choice

                int option = 0;
                bool validOption = false;
                do
                {
                    try
                    {
                        option = Convert.ToInt32(Console.ReadLine()); // Read user input for option
                        if (option < 1 || option > 5)
                        {
                            Console.WriteLine("Invalid option. Please enter a number between 1 and 5."); // Validate input
                        }
                        else
                        {
                            validOption = true;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number."); // Handle format exception
                    }
                } while (!validOption);

                switch (option)
                {
                    case 1:
                        DuplicateRecipeAndPrint(originalItemsArray, 0.5); // Duplicate recipe with quantities multiplied by 0.5
                        break;
                    case 2:
                        DuplicateRecipeAndPrint(originalItemsArray, 2); // Duplicate recipe with quantities multiplied by 2
                        break;
                    case 3:
                        DuplicateRecipeAndPrint(originalItemsArray, 3); // Duplicate recipe with quantities multiplied by 3
                        break;
                    case 4:
                        if (revertToOriginal)
                        {
                            Console.WriteLine("Already reverted to Original Recipe."); // Inform user if already reverted
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue; // Set console foreground color to blue
                            PrintRecipe(originalItemsArray); // Print original recipe again
                            revertToOriginal = true;
                        }
                        break;
                    case 5:
                        Console.WriteLine("Exiting the application..."); // Exit application
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option selected."); // Handle invalid option
                        break;
                }
            } while (true); // Loop indefinitely until exit
        }

        //https://www.w3schools.com/cs/index.php
 

        static void PrintRecipe(ItemsToBeUsed[] recipe)
        {
            Console.WriteLine("+-------------------------+-------------------------+-------------------------+-------------------------+");
            Console.WriteLine("|      Name of Ingredient |             Quantity    |      Unit of Measurement|          Description     |");
            Console.WriteLine("+-------------------------+-------------------------+-------------------------+-------------------------+");
            foreach (var item in recipe)
            {
                Console.WriteLine($"|{item.NameOfIngrediant.PadRight(25)}|{item.Quantity.ToString().PadRight(25)}|{item.UnitOfmeasurement.PadRight(25)}|{item.DescriptionOfItem.PadRight(25)}|");
            }
            Console.WriteLine("+-------------------------+-------------------------+-------------------------+-------------------------+");
        }

        static void DuplicateRecipeAndPrint(ItemsToBeUsed[] originalRecipe, double multiplier)
        {
            Console.WriteLine($"\n[Duplicated Recipe ({multiplier}x Quantity)]\n"); // Print duplicate recipe header

            ItemsToBeUsed[] duplicatedRecipe = new ItemsToBeUsed[originalRecipe.Length]; // Initialize array for duplicated recipe
            for (int i = 0; i < originalRecipe.Length; i++)
            {
                duplicatedRecipe[i] = new ItemsToBeUsed() // Create duplicated item objects with modified quantities
                {
                    NameOfIngrediant = originalRecipe[i].NameOfIngrediant,
                    Quantity = originalRecipe[i].Quantity * multiplier,
                    DescriptionOfItem = originalRecipe[i].DescriptionOfItem,
                    UnitOfmeasurement = originalRecipe[i].UnitOfmeasurement
                };
            }

            PrintRecipe(duplicatedRecipe); // Print duplicated recipe
        }
    }
}


/*
 * https://www.w3schools.com/cs/cs_booleans.php
 * https://www.w3schools.com/cs/index.php
 * https://www.w3schools.com/cs/cs_break.php
 * https://www.w3schools.com/cs/cs_oop.php
 */
