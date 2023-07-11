using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiok
{
    class Beolvas
    {
        public static int Beolvas_()
        {
            string filePath = @"C:\Users\misi1\OneDrive\Asztali gép\WS.txt";

            if (File.Exists(filePath))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string line = sr.ReadLine();

                        if (int.TryParse(line, out int number))
                        {
                            return number;
                        }
                        else
                        {
                            Console.WriteLine("Invalid integer: " + line);
                            throw new Exception();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error reading the file: " + e.Message);
                    throw new Exception();
                }
            }
            else
            {
                Console.WriteLine("The file does not exist.");
                throw new Exception();
            }
        }

    }
}
