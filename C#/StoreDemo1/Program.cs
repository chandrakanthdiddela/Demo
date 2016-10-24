using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace StoreDemo1
{
    class Circle 
    {
        public void Draw()
        {
        }
    }

    class Rectangle 
    {
        public void Draw()
        {
        }
    }

    class MyExpandoObject : DynamicObject
    {
        private Dictionary<string, object> dict = new Dictionary<string, object>();

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (dict.ContainsKey(binder.Name)) return false;
            dict[binder.Name] = value;
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (!dict.ContainsKey(binder.Name))
            {
                result = null;
                return false;
            }
            result = dict[binder.Name];
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example 4 - XML 

            // Example 3 
            //dynamic d = new MyExpandoObject();
            //d.X = 10;
            //Console.WriteLine(d.X);

            // Example 2 
            //dynamic d = new ExpandoObject();
            //d.X = 10;
            //Console.WriteLine(d.X);

            // Example 1
            //dynamic shape;
            
            //shape = new Circle();
            //shape.Draw();
         
            //shape = new Rectangle();
            //shape.Draw();
        }
    }
}
