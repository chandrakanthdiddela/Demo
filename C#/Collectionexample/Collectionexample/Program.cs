using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Collectionexample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lobjliststr = new List<string>();
            lobjliststr.Add("chandra");
            lobjliststr.Add("babulu");
            lobjliststr.Add("varnit");
            lobjliststr.Add("harini");



            foreach ( var lobjlist in lobjliststr)
                Console.WriteLine(lobjlist);

            Dictionary<int, string> lobjdictstr = new Dictionary<int, string>();
           
            lobjdictstr.Add(4, "harini");
            lobjdictstr.Add(2, "sai");
            lobjdictstr.Add(1, "chandra");
            lobjdictstr.Add(3, "varnit");
            foreach (var lobjdict in lobjdictstr)
            {
                Console.WriteLine((int)lobjdict.Key);
                Console.WriteLine(lobjdict.Value);


            }

           
            foreach( KeyValuePair<int,string > pair  in lobjdictstr)
            {
                Console.Write(pair.Key);
                Console.WriteLine(pair.Value);
            }


            foreach (KeyValuePair<int, string> pair in lobjdictstr)
            {
                Console.Write(pair.Key);
                Console.WriteLine(pair.Value);
            }

            // 
            // Hashtable
            //
           System.Collections.Hashtable lobjHashTable  = new System.Collections.Hashtable();
            lobjHashTable.Add(1,"chandra");
            lobjHashTable.Add(2,"Varnit");
            lobjHashTable.Add(3,"xyz");

            foreach(DictionaryEntry dict in lobjHashTable)
            {
                Console.WriteLine((int)dict.Key);
                Console.WriteLine((string)dict.Value);
            }

            SortedList lobjsort = new SortedList(lobjdictstr);
            foreach (DictionaryEntry  lobj in lobjsort)
            {
                Console.WriteLine(lobj.Key);
                Console.WriteLine(lobj.Value);
            }


            Console.ReadKey();

        }
    }
}
