using Colors.Net;
using Colors.Net.StringColorExtensions;
using SQL_Project_Products;
using System.Diagnostics;
using Dapper;
using System.Data;
IProductRepository productRepository = new ProductRepository();


bool exit = false;
try
{
    while (!exit)
    {



        Console.Clear();
        ColoredConsole.WriteLine("-------------------------Product Manager------------------------".DarkYellow());
        Console.WriteLine("---1.Add Product ");
        Console.WriteLine("---2.Info Product ");
        Console.WriteLine("---3.Show All Products ");
        Console.WriteLine("---4.Remove Product ");
        Console.WriteLine("---5.Change Product ");
        Console.WriteLine("---6.Exit ");
        Console.Write("---Choose Your Option :");
        int Choice = Convert.ToInt32(Console.ReadLine());

        ColoredConsole.WriteLine("-------------------------------------------------------------------------".DarkMagenta());



        switch (Choice)
        {
            case 1:
                try
                {
                    ColoredConsole.Write("Enter Name Product : ".DarkGray());
                    string name = Console.ReadLine();
                    ColoredConsole.Write("Enter category your product :".DarkGray());
                    int categoryId = Convert.ToInt32(Console.ReadLine());
                    if (categoryId > 4)
                    {
                        ColoredConsole.WriteLine("Just 4 Category in Shop".Red());
                    }
                    ColoredConsole.Write("Enter Price Product :".DarkGray());
                    int price = Convert.ToInt32(Console.ReadLine());
                    if (price < 1)
                    {
                        ColoredConsole.WriteLine("Price cant Zero".DarkRed());
                    }
                    else
                    {
                        var product = new Products()

                        {
                            Name = name,
                            CategoryId = categoryId,
                            Price = price,
                        };

                        if (product is null)
                        {
                            ColoredConsole.WriteLine("You Cant Add This Information For New Product".DarkRed());
                        }
                        else
                        {
                            productRepository.Add(product);
                            ColoredConsole.WriteLine("Add Product SuccessFully ".DarkGreen());
                        }
                    }
                }
                catch (Exception ex)
                {
                    ColoredConsole.WriteLine($"Error:{ex.Message} ".Red());
                }
                Console.ReadKey();

                break;

            case 2:
                try
                {
                    ColoredConsole.Write("Enter Name Product : ".DarkGray());
                    string input = Console.ReadLine();
                    var result = productRepository.Get(input);
                    if (result is null)
                    {
                        ColoredConsole.WriteLine("Product Not found ".Red());
                    }
                    else
                    {
                        ColoredConsole.WriteLine($" Name = {result.Name}\n CategoryId = {result.CategoryId}\n Price = {result.Price}".DarkCyan());
                    }

                }
                catch (FormatException f)
                {
                    ColoredConsole.WriteLine($"Error:{f.Message} ".Red());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error : {ex.Message}");
                }


                Console.ReadKey();
                break;

            case 3:

                var products = productRepository.GetAll();
                foreach (var item in products)
                {
                    ColoredConsole.WriteLine($" | Name = {item.Name} , CategoryId = {item.CategoryId} , Price = {item.Price} |".DarkYellow());
                    ColoredConsole.WriteLine("-------------------------------------------------------------".DarkGray());

                }


                Console.ReadKey();

                break;

            case 4:
                try
                {
                    ColoredConsole.Write("Enter Name Product : ".Red());
                    string delete = Console.ReadLine();
                    var remove = productRepository.Get(delete);
                    if (remove is null)
                    {
                        ColoredConsole.WriteLine("Product Not Found in Shop".DarkRed());
                    }
                    else
                    {
                        productRepository.Delete(delete);
                        ColoredConsole.WriteLine("Product Deleted".DarkGreen());
                    }
                }
                catch (FormatException f)
                {
                    ColoredConsole.WriteLine($"Error:{f.Message} ".Red());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error : {ex.Message}");
                }

                Console.ReadKey();
                break;

            case 5:
                try
                {
                    ColoredConsole.Write("Enter Name Product For Update : ".DarkYellow());
                    string update = Console.ReadLine();
                    var edit = productRepository.Get(update);
                    if (edit is null)
                    {

                        ColoredConsole.WriteLine("Product Not Found in Shop".Red());

                    }
                    else
                    {
                        ColoredConsole.Write("Enter New Name :".Yellow());
                        string updateN = Console.ReadLine();
                        if (updateN is null)
                        {
                            ColoredConsole.WriteLine("Product Not Found in Shop".Red());
                        }

                        Console.Write("Enter Category Id Your Product :");
                        int updateC = Convert.ToInt32(Console.ReadLine());

                        if (updateC > 4)
                        {
                            ColoredConsole.WriteLine("Just 4 Category in Shop Choose number Under 5".Red());
                        }
                        Console.Write("Enter Price Your Product :");
                        int updateP = Convert.ToInt32(Console.ReadLine());

                        edit.Id = edit.Id;
                        edit.Name = updateN;
                        edit.CategoryId = updateC;
                        edit.Price = updateP;

                        productRepository.Update(edit);
                        ColoredConsole.WriteLine("Product Updated".DarkGreen());
                    }
                    
                }
                catch (FormatException f)
                {
                    ColoredConsole.WriteLine($"Error:{f.Message} ".Red());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error : {ex.Message}");
                }

                Console.ReadKey();
                break;

            case 6:
                exit = true;
                ColoredConsole.WriteLine("-------------------------- Exit ----------------------".DarkRed());
                break;

        }
    }
}
catch (FormatException f)
{
    ColoredConsole.WriteLine($"Error:{f.Message} ".Red());

}
catch (Exception ex)
{
    Console.WriteLine($"Error : {ex.Message}");
}
