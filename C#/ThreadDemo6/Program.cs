using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo6
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = Task.Factory.StartNew(F1);

            // Read the data from File
            FileStream stream = new FileStream("filename.extension",FileMode.Open, FileAccess.Read);
            byte[] arr =new byte[1000];
            // if the file is located on another machine, then IOCompletionPort will be 
            // used to perform this operation and not the thread. But if the file located 
            // on the same machine then the thread is used.
            stream.BeginRead(arr, 0, arr.Length, new AsyncCallback(OnReadComplete), stream);
            //stream.BeginRead(arr, 0, arr.Length, new AsyncCallback(result =>
            //    {
            //        int bytesReadCount = stream.EndRead(result);
            //        stream.Close();
            //    }), null);

            SqlConnection connection = new SqlConnection("connectionString");
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from table";
            connection.Open();
            command.BeginExecuteReader(result =>
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                    }
                }, null);
        }

        // this gets called on the thread
        private static void OnReadComplete(IAsyncResult result)
        {
            FileStream stream = result.AsyncState as FileStream;
            int bytesReadCount= stream.EndRead(result);
            stream.Close();
        }

        static void F1()
        {
            // Executable code that work in memory data
        }
    }
}


