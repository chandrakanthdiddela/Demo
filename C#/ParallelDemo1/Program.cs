using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelDemo1
{
    class Program
    {
        private static EmployeeList employeeData;

        static void Main(string[] args)
        {
            employeeData = new EmployeeList();

            Console.WriteLine("Payroll process started at {0}", DateTime.Now);
            var sw = Stopwatch.StartNew();

            // Methods to call

            //Ex1Task1_ParallelizeLongRunningService();
            //Ex1Task1_WalkTree();

            Ex2Task1_NativeParallelTasks();

            Console.WriteLine("Payroll finished at {0} and took {1}",
                                  DateTime.Now, sw.Elapsed.TotalSeconds);

            Console.WriteLine();
            Console.ReadLine();
        }

        private static void Ex2Task1_NativeParallelTasks()
        {
            Task task1 = Task.Factory.StartNew(delegate
                                { PayrollServices.GetPayrollDeduction(employeeData[0]); });
            Task task2 = Task.Factory.StartNew(delegate
                                { PayrollServices.GetPayrollDeduction(employeeData[1]); });
            Task task3 = Task.Factory.StartNew(delegate
                                { PayrollServices.GetPayrollDeduction(employeeData[2]); });
            Task task4 = Task.Factory.StartNew(delegate
                                { PayrollServices.GetPayrollDeduction(employeeData[3]); });
            Task task5 = Task.Factory.StartNew(delegate
                                { PayrollServices.GetPayrollDeduction(employeeData[4]); });
            
            Task.WaitAll(task1, task2, task3);

            //task1.Wait();
            //task2.Wait();
            //task3.Wait();
        }

        private static void Ex1Task1_WalkTree()
        {
            EmployeeHierarchy employeeHierarchy = new EmployeeHierarchy();
            WalkTree(employeeHierarchy);
        }

        private static void WalkTree(Tree<Employee> node)
        {
            if (node == null)
                return;

            if (node.Data != null)
            {
                Employee emp = node.Data;
                Console.WriteLine("Starting process for employee id {0}",
                    emp.EmployeeID);
                decimal span = PayrollServices.GetPayrollDeduction(emp);
                Console.WriteLine("Completed process for employee id {0}",
                    emp.EmployeeID);
                Console.WriteLine();
            }

            Parallel.Invoke(delegate { WalkTree(node.Left); }, delegate { WalkTree(node.Right); });

            //WalkTree(node.Left);
            //WalkTree(node.Right);
        }



        private static void Ex1Task1_ParallelizeLongRunningService()
        {
            Console.WriteLine("Non-parallelized for loop");

            //for (int i = 0; i < employeeData.Count; i++)
            Parallel.For ( 0, employeeData.Count, ( i ) => {
                    Console.WriteLine("Starting process for employee id {0}",
                        employeeData[i].EmployeeID);
                    decimal span =
                        PayrollServices.GetPayrollDeduction(employeeData[i]);
                    Console.WriteLine("Completed process for employee id {0}" +
                        "process took {1} seconds",
                        employeeData[i].EmployeeID, span);
                    Console.WriteLine();
            } ) ;
        }

    }

}
