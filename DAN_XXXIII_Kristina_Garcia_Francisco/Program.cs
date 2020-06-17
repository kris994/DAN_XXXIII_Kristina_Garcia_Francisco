using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace DAN_XXXIII_Kristina_Garcia_Francisco
{
    /// <summary>
    /// The Main program class
    /// </summary>
    class Program
    {
        public static List<Thread> AllThreads = new List<Thread>();
        public static string fileNameT1 = "FileByThread_1.txt";
        public static string fileNameT22 = "FileByThread_22.txt";

        /// <summary>
        /// The main method for the thread task
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MatrixRandomNumber task = new MatrixRandomNumber();

            // Creates threads with the given name and saves it to the list of threads
            for (int i = 1; i < 5; i++)
            {
                string name;
                if (i % 2 == 0)
                {
                    name = "THREAD_" + i + i;
                }
                else
                {
                    name = "THREAD_" + i;
                }

                Thread thread = new Thread(() => task.TaskValues())
                {
                    Name = name,
                    IsBackground = true
                };

                AllThreads.Add(thread);

                Console.WriteLine("Created {0}", thread.Name);
            }

            // Gets threads from the list
            Thread thread1 = AllThreads[0];
            Thread thread22 = AllThreads[1];
            Thread thread3 = AllThreads[2];
            Thread thread44 = AllThreads[3];

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            thread1.Start();
            thread22.Start();
            thread1.Join();
            thread22.Join();

            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0} milliseconds", ts.Milliseconds);
            Console.WriteLine("\nRunTime {0}\n", elapsedTime);

            thread3.Start();
            thread44.Start();
            thread3.Join();
            thread44.Join();

            Console.ReadLine();
        }
    }
}
