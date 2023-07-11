using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Fiok
{
    public class Shape : ICloneable
    {

       int értek = 4;
       public int[,] data;
       public string szin;
        public Shape() { }
        public Shape(int ID) 
        {
            if (ID == 0) 
            {
               this.data = new int[3, 2]//Z

                {
                     { 0, 1 },
                     { 1, 1 },
                     { 1, 0 }
                };
                this.szin = "sárga";
            }
            if (ID == 1) 
            {
               this.data= new int[3, 2]//L
                {
                      { 2, 0 },
                      { 2, 0 },
                      { 2, 2 }
                };
                this.szin = "kék";
            }
            if (ID == 2) 
            {
               this.data = new int[2, 2]//[]

                 {
                     { 3, 3 },
                     { 3, 3 },
                     
                 };
                this.szin = "piros";
            }
            if (ID == 3) 
            {
              this.data = new int[3, 2]//T
                   {
                     { 0, 4 },
                     { 4, 4 },
                     { 0, 4 }
                   };
                this.szin = "zold";
            }
            if (ID == 4) 
            {
                this.data = new int[4, 1]//|
                {
                    { 5 },
                    { 5 },
                    { 5 },
                    { 5 }
                };
                this.szin = "lila";
            }

        }
        public object Clone()
        {
            Shape clone= new Shape();
            clone.data= this.data;
            clone.szin= this.szin;
            return clone;

        }

        public void print() 
        {
            string s = "";
            for (int i = 0; i < W; i++) 
            {
                s = "";
                for (int j = 0; j < H; j++) 
                {
                    s += $"{data[i, j]} ";   
                }
                Console.WriteLine(s);
            }
             
        }

        public void rotate()
        {
            int rows = this.data.GetLength(0);
            int cols = this.data.GetLength(1);
            int[,] rotatedShape = new int[cols, rows];

            // Transpose the original shape
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    rotatedShape[j, i] = this.data[i, j];
                }
            }

            // Reverse the rows of the transposed shape
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows / 2; j++)
                {
                    int temp = rotatedShape[i, j];
                    rotatedShape[i, j] = rotatedShape[i, rows - j - 1];
                    rotatedShape[i, rows - j - 1] = temp;
                }
            }
            this.data = rotatedShape;

            
        }

        public int W 
        {
            get 
            {
                return this.data.GetLength(0);
            }
        }
        public int H 
        {
            get
            {
                return this.data.GetLength(1);
            }
        }
    }

   
}
