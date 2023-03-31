using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
/*Создать базовый класс «Музыкальный инструмент»
и производные классы «Скрипка», «Тромбон», «.Укулеле»,
«Виолончель». С помощью конструктора установить имя
каждого музыкального инструмента и его характеристики.
Реализуйте для каждого из классов методы:
■■ Sound — издает звук музыкального инструмента
(пишем текстом в консоль);
■■ Show — отображает название музыкального инстру-
мента;
■■Desc — отображает описание музыкального инстру-
мента;
■■History — отображает историю создания музыкаль-
ного инструмента.*/

namespace NusicInstrumant
{
    internal class Program
    {
        interface MusicInstrument
        {
            string Name { get; set; } 
            string Describe { get; set; }
            void Sound();
            void Show();
            void DescribeInstrument();
            void HistoryInstrument();


        }
        class Violin : MusicInstrument
        {
            public Violin(string name, string describe)
            {
                Name = name;
                Describe = describe;
            }

            public   string Name { get; set; }
            public  string Describe { get; set; }
            public void Sound()
            {
                Console.WriteLine("Violin :  'High frequency squeak' ...viiiii...");
            
            }
            public void Show()
            { 
            Console.WriteLine(Name);
            }
            public void DescribeInstrument()
            { 
            Console.WriteLine(Describe);
            
            }
            public void HistoryInstrument()
            { 
            Console.WriteLine("Histiry  : "+"Прародителями скрипки были арабский ребаб," +
                " испанская фидель, германская рота, слияние которых и образовало виолу." +
                " Формы скрипки установились к XVI веку. К этому веку и началу XVII века" +
                " относятся известные изготовители скрипок — семейство Амати.");
            
            }
        }
        class Trombone : MusicInstrument 
        {
            public Trombone(string name, string describe)
            {
                Name = name;
                Describe = describe;
            }

            public string Name { get; set; }
            public string Describe { get; set; }
            public void Sound()
            {
                Console.WriteLine("Trombone :  'Low frequency hum' ..VooVooo...");

            }
            public void Show()
            {
                Console.WriteLine(Name);
            }
            public void DescribeInstrument()
            {
                Console.WriteLine(Describe);

            }
            public void HistoryInstrument()
            {
                Console.WriteLine("Histiry  : "+"Появление тромбона относится к XV веку. " +
                    "Принято считать, что непосредственными предшественниками " +
                    "этого инструмента были кулисные трубы, при игре на которых " +
                    "у музыканта была возможность передвигать трубку инструмента," +
                    " таким образом получая хроматический звукоряд.");
            }
        }
        class Ukulele : MusicInstrument
        {
            public Ukulele(string name, string describe)
            {
                Name = name;
                Describe = describe;
            }


            public string Name { get; set; }
            public string Describe { get; set; }
            public void Sound()
            {
                Console.WriteLine("Ukulele :  'High frequency strumming' ...strum-strum...");

            }
            public void Show()
            {
                Console.WriteLine(Name);
            }
            public void DescribeInstrument()
            {
                Console.WriteLine(Describe);

            }
            public void HistoryInstrument()
            {
                Console.WriteLine("Histiry  : "+"Укулеле появилась на Гавайских " +
                    "островах во второй половине XIX века," +
                    " куда её, под названием машети да браса (порт. machete da braça)," +
                    " завезли португальцы с острова Мадейра.");

            }
        }
        class Cello : MusicInstrument 
        {
            public Cello(string name, string describe)
            {
                Name = name;
                Describe = describe;
            }

            public string Name { get; set; }
            public string Describe { get; set; }
            public void Sound()
            {
                Console.WriteLine("Cello :  'Low frequency squeak' ...vooom...." +
                    "...");

            }
            public void Show()
            {
                Console.WriteLine(Name);
            }
            public void DescribeInstrument()
            {
                Console.WriteLine(Describe);

            }
            public void HistoryInstrument()
            {
                Console.WriteLine("Histiry  : " +"Появление виолончели относится к кону XV" +
                    " и началу XVI века в результате длительного развития " +
                    "народных смычковых инструментов. Первоначально она применялась" +
                    " как басовый инструмент в различных ансамблях, для сопровождения " +
                    "пения или исполнения на инструменте более высокого регистра");

            }
        }
        static void Main(string[] args)
        {
            MusicInstrument[] musicInstrument = {new Violin("Violin" , "a bowed stringed instrument having four strings tuned at intervals of a fifth"),
                new Trombone("Trombone" , "a brass instrument consisting of a long cylindrical metal tube"),
                new Ukulele("ukulele", " is a small stringed instrument that originated in Hawai'i"),
                new Cello("Cello" , "The cello properly violoncello is a bowed string instrument of the violin family. Its four strings are usually tuned in perfect fifths") };
            int choice = 1 ;
            do
            {
                Console.WriteLine();
                foreach (var music in musicInstrument)
                {
                    Console.Write(choice++);
                    music.Show();
                }
                Console.WriteLine();
                Console.WriteLine("Choose an instrument : ");
                Console.WriteLine("For exit push 0");
                choice = int.Parse(Console.ReadLine());
                if (choice == 0) return;
                if (choice < 1 || choice > 4) { choice = 1; continue; }
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Name : ");
                Console.ForegroundColor = ConsoleColor.White;
                musicInstrument[choice - 1].Show();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Describe : ");
                Console.ForegroundColor = ConsoleColor.White;
                musicInstrument[choice - 1].DescribeInstrument();
                Console.ForegroundColor = ConsoleColor.White;
                musicInstrument[choice - 1].HistoryInstrument();
                Console.ForegroundColor = ConsoleColor.White;
                musicInstrument[choice - 1].Sound();
                choice = 1;
            }
            while (choice != 0);
        }
    }
}
