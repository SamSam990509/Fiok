using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fiok
{
     class Program
    {
        static void Main(string[] args)
        {
            
            Fild f = new Fild();
            Fild fild = new Fild();

            Console.WriteLine("Irj be egy pozitiv egesz szamot(WS):");
            //int shape_number=int.Parse(Console.ReadLine());
            int shape_number = Beolvas.Beolvas_();
            Verem verem = new Verem(shape_number);
            bool isNatrural = (shape_number >= 0);
            if (isNatrural)
            {
                f.walking_solver(verem);
            }
            else
            {
                Console.WriteLine("Nem jo számot adtál meg!");
                throw new Exception("Nem jo számot adtál meg!");
                
            }
           //Console.ReadKey();
           

            

            Console.WriteLine("Irj be egy pozitiv egesz szamot(FS):");
           // int shape_number2 = int.Parse(Console.ReadLine());
           
            Verem verem2 = new Verem(shape_number);

            bool isNatrural2 = (shape_number >= 0);
            if (isNatrural2)
            {
                fild.flying_solver(verem2);
            }
            else 
            {

                Console.WriteLine("Nem jo számot adtál meg!");
                throw new Exception("Nem jo számot adtál meg!");

            }



            if (verem.output_shapes.Count < 3)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Missed item number(WS):{verem.output_shapes.Count}");
            if (verem.output_shapes.Count < 3)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Missed item number(FS):{verem2.output_shapes.Count}");

            Console.ReadKey();
        }
    }
}
