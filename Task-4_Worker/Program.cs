using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_Worker
{


    
    internal class Program
    {


        abstract class Worker
        {
          public string Name { get; set; }
          abstract public void Print();
        }


        class President : Worker
        {
            public new string Name { get; set; }
            public override void Print() { Console.WriteLine("i'm a " + Name); }
        }
        class Security : Worker
        {
            public new string Name { get; set; }
            public override void Print() { Console.WriteLine("i'm a " + Name); }
        }
        class Manager : Worker
        {
            public new string Name { get; set; }
            public override void Print() { Console.WriteLine("i'm a " + Name); }
        }
        class Engineer : Worker
        {
            public new string Name { get; set; }
            public override void Print() { Console.WriteLine("i'm a " + Name); }
        }



        static void Main(string[] args)
        {
            Worker[] worker = { new President() { Name = "President"}, new Security() { Name = "Security" }, new Manager() { Name = "Manager" }, new Engineer() { Name = "Engineer" } } ;

            foreach (var work in worker) 
            {
             work.Print();
            }

        }
        
    }
}
