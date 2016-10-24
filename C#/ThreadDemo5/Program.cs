using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo5
{
    class Drawing
    {
        private int[] arr = new int[10];

        public void Start() // called in the MT
        {
            Task t1 = Task.Factory.StartNew(Fill);
            Task t2 = Task.Factory.StartNew(Draw);
            Task t3 = Task.Factory.StartNew(Save);

            //t1.Wait(); // for MT to wait
            //t2.Wait(); // for MT to wait
            //t3.Wait(); // for MT to wait
        }

        public AutoResetEvent ar = new AutoResetEvent(false /* non-set state*/);
        private ManualResetEvent mr = new ManualResetEvent(false /* non-set state*/);

        private int testNumber = 1;

        //object o1 = new object();
        //object o2 = new object();
        private ReaderWriterLock rw = new ReaderWriterLock();

        public void Fill()
        {
            while (true)
            {
                // Wait
                ar.WaitOne(); // this can make the calling thread on the event object if the 
                                       // event object is in NON-SET state. When event object goes to SET-state
                                       // it makes thread comes OUT of WAIT state.
                // Becuase it is an Auto Reset Event, after thread comes out of Wait state
                // the event object resets to NON-SET state, so that if the thread calls WaitOne
                // it should go to the WAIT state

                //lock (o1)
                //{
                //    lock (o2)
                //    {
                
                rw.AcquireWriterLock(Timeout.Infinite);
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = testNumber;
                }
                rw.ReleaseWriterLock();

                //    }
                //}

                // Signal Draw and Save to draw and save the data respectively
                mr.Set();

                testNumber++;
            }
        }

        public void Draw()
        {
            while (true)
            {
                mr.WaitOne(); // this can make the calling thread on the event object if the 
                // event object is in NON-SET state. When event object goes to SET-state
                // it makes thread comes OUT of WAIT state.
                // Becuase it is an Manual Reset Event, after thread comes out of Wait state
                // the event object DOESN'T reset to NON-SET state. 
                // hence the thread when calls WaitOne next time will NOT go to WAIT state
                // hence manually reset the event.
                mr.Reset();

                //lock (o1)
                //{
                rw.AcquireReaderLock(Timeout.Infinite);
                for (int i = 0; i < arr.Length; i++)
                    {
                        Console.WriteLine("{0}: {1}", (i + 1), arr[i]);
                        Thread.SpinWait(90000000);
                    }
                rw.ReleaseReaderLock();
                //}
            }
        }

        public void Save()
        {
            mr.WaitOne();
            mr.Reset();

            while (true)
            {
                //lock (o2)
                //{
                rw.AcquireReaderLock(Timeout.Infinite);
                using (StreamWriter writer = new StreamWriter("data.txt"))
                    {
                        for (int i = 0; i < arr.Length; i++)
                        {
                            writer.Write(arr[i].ToString());
                            Thread.SpinWait(90000000);
                        }
                    }
                rw.ReleaseReaderLock();
                //}
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Drawing d = new Drawing();
            d.Start();

            while (true) // execute in MT
            {
                Console.ReadLine();
                d.ar.Set(); // makes the event object go to SET state (Signalling the thread)
            }
        }
    }
}
