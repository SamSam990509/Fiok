using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Fiok
{
    public class Fild
    {

        public int[,] Fdata;
        public  int FW;
        public int FH;
        public void flying_solver(Verem verem) 
        {
            while (verem.input_shapes.Count > 0)
            {


                Shape X = verem.PullOneElement();


                FShape best_position = new FShape();
                FShape current_position;
                //verem = f.flying_solver(verem);
                for (int j = 0; j < FH; j++)
                {
                    for (int i = 0; i < FW; i++)
                    {

                        current_position = calculate_fshape(i, j, X);
                        if (current_position.valid)
                        {
                            best_position = new FShape(X, true, i, j);
                        }
                    }
                }
                if (best_position.valid)
                {
                    upload(best_position);
                }
                else
                {
                    verem.PushElement(X);
                }
               print_colors();
               System.Threading.Thread.Sleep(1000);
               Console.Clear();
            }
            
             
                
        }
        public void walking_solver(Verem verem)
        {
            while (verem.input_shapes.Count > 0)
            {


                Shape X = verem.PullOneElement();


                FShape best_position = new FShape();
                FShape current_position;
                for (int j = 0; (j < (FH-X.H+1)); j++)
                {
                    bool ok = true;
                    for (int i = 0; (i < (FW-X.W+1) ) && ok; i++)
                    {

                        current_position = calculate_fshape(i, j, X);
                        if (current_position.valid)
                        {
                            best_position = new FShape(X, true, i, j);
                        }
                        else
                        {
                            ok = false;
                        }
                    }
                }
                if (best_position.valid)
                {
                    upload(best_position);
                }
                else
                {
                    verem.PushElement(X);
                }
                print_colors();
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }

        }
        public bool crass(Shape a, int i, int j) 
        {
            bool safe = true;

            if ((a.W+i > FW) || (a.H+j > FH)) 
            {
                safe = false;
            }
            int H = 0;
            
            while ((H < a.H) && safe) 
            {
                int W = 0;
                while ((W < a.W) && safe)
                {

                    //if ((a.data[W, H] + Fdata[i + W, j + H]) <2)
                    if (a.data[W, H]==0 || Fdata[i + W, j + H]==0)
                    {
                        W++;
                    }
                   // else if (a.data[W, H] + Fdata[i + W, j + H] == 2) 
                    else
                    { 
                        safe = false;
                    }

                }
                H++;
               
            }
            return safe;
        }
        public void print()
        {
            string s = "";
            for (int i = 0; i < FW; i++)
            {
                s = "";
                for (int j = 0; j < FH; j++)
                {
                    s += $"{Fdata[i, j]} ";
                }
                Console.WriteLine(s);
            }

        }

        public void print_colors()
        {
            for (int i = 0; i < FW; i++)
            {
                for (int j = 0; j < FH; j++)
                {
                   if (Fdata[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("██");
                    }
                   else if (Fdata[i, j] == 2)
                   {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("██");
                   }
                   else if (Fdata[i, j] == 3)
                   {
                       Console.ForegroundColor = ConsoleColor.Blue;
                       Console.Write("██");
                   }
                   else if (Fdata[i, j] == 4)
                   {
                       Console.ForegroundColor = ConsoleColor.Cyan;
                       Console.Write("██");
                   }
                    else if (Fdata[i, j] == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("██");
                    }
                    else
                    { 
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("██");
                    }

                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        public void upload(FShape fs) 
        {
            int i=fs.i; 
            int j=fs.j;
            for (int w = 0; w < fs.shape.W; w++) 
            {
                for (int h = 0; h < fs.shape.H; h++) 
                {
                  Fdata[i + w, j + h] = fs.shape.data[w, h]+Fdata[i+w,j+h];
                    
                }
            }
            
        }
        public bool LastTrueAction(int i , int j,Shape X, int RotateN=3)
        {
            while (crass(X, i, j) == false && RotateN > 0)
            {
                X.rotate();
                RotateN--;

            }

            return crass(X, i, j);
        }
        public FShape calculate_fshape(int i, int j, Shape X) 
        {
                FShape ret=new FShape();
                bool CurrentResult = LastTrueAction(i,j,X);
                if (CurrentResult)
                {
                   
                    ret=new FShape(X,true,i,j);
                }
                return ret;
        }
        public Fild() 
        {
            this.Fdata =new int[20, 10]
      {
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0}
      };
            this.FH= Fdata.GetLength(1);
            this.FW = Fdata.GetLength(0);
        }
    }
}
