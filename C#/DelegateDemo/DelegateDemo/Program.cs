using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{

    public class Container
    {
        public delegate int CompareItemsCallback(object obj1, object obj2);
        public void Sort(CompareItemsCallback compare)
            {
            // not a real sort, just shows what the
            // inner loop code might do
            int x = 0;
            int y = 1;
            object item1 = m_arr[x];
            object item2 = m_arr[y];
            int order = compare(item1, item2);
            }
   }
            public class Employee
            {
            public Employee(string name, int id)
            {
                m_name = name;
                m_id = id;
           }
                public static int CompareName(object obj1, object obj2)
                {
                Employee emp1 = (Employee) obj1;
                Employee emp2 = (Employee) obj2;
                return(String.Compare(emp1. m_name, emp2. m_name));
                }
public static int CompareId(object obj1, object obj2)
{
Employee emp1 = (Employee) obj1;
Employee emp2 = (Employee) obj2;
if (emp1. m_id > emp2. m_id)
{
return(1);
}
else if (emp1. m_id < emp2. m_id)
{
return(−1);
}
else
{
return(0);
}
}
string m_name;
int m_id;
}
class Test
{
public static void Main()
{
Container employees = new Container();
// create and add some employees here
// create delegate to sort on names, and do the sort
Container.CompareItemsCallback sortByName =
new Container.CompareItemsCallback(Employee.CompareName);
employees.Sort(sortByName);
// employees is now sorted by name
}
}
}
