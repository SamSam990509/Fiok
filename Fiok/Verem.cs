using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiok
{
    public class Verem
    {
        Random rnd = new Random();
      public  Stack<Shape> input_shapes= new Stack<Shape>();
      public  Stack<Shape> output_shapes= new Stack<Shape>();

       
        public Verem( int numberOfShapes)
        {
    
            for (int i = 0; i < numberOfShapes; i++)
            {  
                int num = rnd.Next(5);
                Shape shapes = new Shape(num);
                this.input_shapes.Push(shapes);
            }
   
        }
        public Shape PullOneElement()
        {
            if (this.input_shapes.Count > 0)
            {
                return (Shape)this.input_shapes.Pop();
            }
            else
            {
                throw new InvalidOperationException("Stack is empty.");
            }
        }

        public void PushElement(Shape element)
        {
            output_shapes.Push(element);
        }


    }
}
