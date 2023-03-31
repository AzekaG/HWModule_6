using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Task1_Money
{

    /*Запрограммируйте класс Money (объект класса оперирует одной валютой) для работы с деньгами.
В классе должны быть предусмотрены поле для хранения целой части денег (доллары, евро, гривны и т.д.) и поле
для хранения копеек (центы, евроценты, копейки и т.д.).
Реализовать методы для вывода суммы на экран, задания значений для частей.
На базе класса Money создать класс Product для работы
с продуктом или товаром. Реализовать метод, позволяющий уменьшить цену на заданное число.
Для каждого из классов реализовать необходимые
методы и поля.*/
    internal class Program
    {
        enum Currency { Dol, Euro, Grn }
        class Money
        {


            int pennies;
            public int Pennies
            {
                get { return pennies; }
                set
                {
                    pennies = value;
                    cash = wholePart + pennies;

                }
            }

            int wholePart;
            public int WholePart
            {
                get { return wholePart; }
                set
                {
                    wholePart = value;
                    cash = value + pennies;
                }

            }



            double cash;

            public double Cash
            {
                get { return cash; }

                set
                {
                    cash = value; wholePart = (int)Math.Truncate(this.Cash);
                    pennies = (int)((cash - wholePart) * 100);
                }
            }
            public Currency currency { get; set; }
            public void OutputCash()
            {
                Console.WriteLine(cash + " " + currency);

            }
            public static Money operator +(Money a, double b)
            {

                return new Money() { Cash = a.cash + b };
            }

            public static Money operator -(Money a, double b)
            {

                if (a.cash >= b) return new Money() { Cash = a.cash - b };
                else return new Money() { Cash = 0 };
            }




        }

        class Product
        {
            double cost;
            Money costProduct = new Money();
            public string Name { get; set; }

            public Money Cost
            {
                get
                { return costProduct; }
                set
                {
                    costProduct = value;
                    cost = costProduct.Cash;
                }
            }
            public double CostProduct { get; set; }
            public Product(string name, double cost)
            {
                costProduct.Cash = cost;
                Name = name;
            }
            public void Output()
            {
                Console.Write("Name : " + Name + "   Cost for 1 : ");
                Cost.OutputCash();

            }
            public void Discont(double a)
            {
                Cost.Cash -= a;
            }
            public void ChangeCurrency(int a)
            {
                Cost.currency = (Currency)a;
            }
        }

        class InterfaceClient

        {
                Product[] products; 
                public InterfaceClient(Product[] products)
                {

                    this.products = products;
                }
                public Product[] Products { get; set; }
                public int Menu()
                {
                int i;
                do
                {
                    
                    Console.Clear();
                    Console.WriteLine("Choose an action : ");
                        Console.WriteLine("1:Show Products\n" +
                                          "2:Add new Products\n" +
                                          "3:Change Price  of Products\n" +
                                          "4:Reduce a Price of product\n" +
                                          "5: Choose a currency for Price\n"+
                                          "0 : Exit");
                        i = int.Parse(Console.ReadLine());
                        if (i < 0 || i > 5) Console.WriteLine("incorrect choice , try again");
                    if (i == 0) System.Environment.Exit(1);
                    
                    } while (i < 0 || i > 5);
                    return i;
                }
                public void Menu_2(int i)
                {
               
                    switch (i)
                    {
                        case 1:
                            {
                            
                                Console.Clear();
                                foreach (Product product in products)
                                {
                                
                                    product.Output();
                                }
                            Console.WriteLine("0 : Back");
                            Console.ReadKey();  
                           
                        }

                            break;
                        case 2:
                            {
                                Console.Clear();
                                string name;
                                double price;
                                Console.WriteLine("Enter a name of New Product");
                                name = Console.ReadLine();
                                Console.WriteLine("Enter a Price of Product");
                                price = double.Parse(Console.ReadLine());
                                Product prod = new Product(name, price);
                            Product[] Res = new Product[products.Length + 1];
                            products.CopyTo(Res, 0);
                            Res[Res.Length - 1] = prod;
                            products = Res;
                            Console.WriteLine("0 : Back");
                            Console.ReadKey(false);


                        }

                            break;
                        case 3:
                            {
                            int temp = 1;
                                Console.Clear();
                                Console.WriteLine("Choose a Product for changing price : ");
                                int choice = 0;
                                foreach (Product product in products)
                                {
                                Console.Write(temp++ + " : ");
                                product.Output();
                                }
                                choice = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter a new Price : ");
                                products[choice - 1].Cost.Cash = double.Parse(Console.ReadLine());
                                Console.WriteLine();
                            temp = 1;
                            foreach (Product product in products)
                                {
                                Console.Write(temp++ + " : ");
                                product.Output();
                            }
                            Console.WriteLine("0 : Back");
                            Console.ReadKey(false);

                        }

                            break;
                        case 4:
                            {
                                Console.Clear();
                                Console.WriteLine("Choose a Product for changing price : ");
                                int choice = 0;
                                foreach (Product product in products)
                                {
                                    product.Output();
                                }
                                choice = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter a value : ");
                                products[choice - 1].Cost.Cash -= double.Parse(Console.ReadLine());
                                Console.WriteLine();
                                foreach (Product product in products)
                                {
                                    product.Output();
                                }
                            Console.WriteLine("0 : Back");
                            Console.ReadKey(false);

                        }

                            break;
                        case 5:
                            {
                                Console.Clear();
                                Console.WriteLine("Choose a currency  : \n" +
                                    "1: Dol\n" +
                                    "2: Euro\n" +
                                    "3: Grn\n");
                                int choice = int.Parse(Console.ReadLine());
                                foreach (Product product in products)
                                {
                                    product.ChangeCurrency(choice - 1);
                                 }
                           
                            
                        }
                        Console.WriteLine("0 : Back");
                        Console.ReadKey(false);
                        break;
                    default: break;
                       
                    }
                
                }

            }
        

    





        static void Main(string[] args)
        {




            Product[] Products = { new Product("Honey", 50), new Product("Beer", 18), new Product("Pizza", 24.5) };
            InterfaceClient IE = new InterfaceClient(Products);
            int i;
            do
            {
                i = IE.Menu();
                IE.Menu_2(i);
            }
            while (i != 0);









            }

    } }
