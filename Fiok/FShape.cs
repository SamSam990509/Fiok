using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Fiok
{
    public class FShape
    {
        public Shape shape;
        public bool valid;
        public int i;
        public int j;

        public FShape(Shape shape_ = null, bool valid = false, int i = -1, int j = -1)
        {
            if (shape_ != null)
            {
                this.shape = (Shape)shape_.Clone();
            }
            else
            {
                this.shape = null;
            }

            this.valid = valid;
            this.i = i;
            this.j = j;
        }
    }
    // public class Test
    //{ 
    //   public static void test1()
    //    {
    //        Shape a = new Shape(1);
    //        Console.WriteLine("elszeretnénk rakni:----------");
    //        a.print();
    //        FShape sa = new FShape(a, true, 2, 4);
    //        Console.WriteLine("forgatott:----------");
    //        a.rotate();
    //        a.data[1, 0] = 5;
    //        a.print();
    //        Console.WriteLine("elrakott:----------");
    //        sa.shape.print();
    //        Console.WriteLine("----------");
    //        Console.WriteLine("----------");
    //    }
    //}

}

