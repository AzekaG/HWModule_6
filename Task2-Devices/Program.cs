using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Devices
{
    internal class Program
    {





      abstract  class Devices
        {
            public abstract string Describe { get; set; }
            public abstract string Name { get; set; }
            abstract public void Sound();
            abstract public void Show();
            abstract public void Desc();
        }
        class Kettle : Devices
        {
            public Kettle(double сapacity, string name, string describe)
            {
                Сapacity = сapacity;
                Name = name;
                Describe = describe;
            }

            public double Сapacity { get;set; }
            public override string Name { get; set; }
            public override string Describe { get; set; }
            public override void Sound() { Console.WriteLine("The kettle boils...pffff...."); }
            public override void Show() { Console.WriteLine(Name + " " + Сapacity + " l."); }
            public override void Desc() { Console.WriteLine(Describe); }

        }
        class MicroWawe : Devices
        {
            public MicroWawe(string model, string name, string describe)
            {
                Model = model;
                Name = name;
                Describe = describe;
            }

            public string Model { get; set; }
            public override string Name { get; set; }
            public override string Describe { get; set; }
            public override void Sound() { Console.WriteLine("The microWawe working....vjjjjjj"); }
            public override void Show() { Console.WriteLine(Name + " mod. "+ Model); }
            public override void Desc() { Console.WriteLine(Describe); }

        }
        class Automobile : Devices
        {
            public Automobile(string brand, string name, string describe)
            {
                Brand = brand;
                Name = name;
                Describe = describe;
            }

            public string Brand { get;set; }
            public override string Name { get; set; }
            public override string Describe { get; set; }
            public override void Sound() { Console.WriteLine("The Automobile running...trrrrrr...."); }
            public override void Show() { Console.WriteLine(Name + " " + Brand); }
            public override void Desc() { Console.WriteLine(Describe); }

        }




        static void Main(string[] args)
        {


            Devices[] devices = { new Kettle(2.2, "Kettle", "for HomeUse"), new MicroWawe("st-07612", "Microwawe", " +Grill"), new Automobile("Renault", "Auto", "Sedan") };
            foreach (var device in devices)
            {
                device.Show();
                device.Desc();
                device.Sound();
                Console.WriteLine();

            }

        }
    }
}
