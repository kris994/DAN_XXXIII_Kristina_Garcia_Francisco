using System;
using System.IO;
using System.Threading;

namespace DAN_XXXIII_Kristina_Garcia_Francisco
{
    /// <summary>
    /// The thread task class that works with matrix and random values
    /// </summary>
    class MatrixRandomNumber
    {
        /// <summary>
        /// Checks for thread names before assigning the correct methods to it
        /// </summary>
        public void TaskValues()
        {
            if (Thread.CurrentThread.Name == "THREAD_1")
            {
                MakeMatrix();
            }

            else if (Thread.CurrentThread.Name == "THREAD_22")
            {
                RandomNumber();
            }

            else if (Thread.CurrentThread.Name == "THREAD_3")
            {
                PrintConsole();
            }

            else if (Thread.CurrentThread.Name == "THREAD_44")
            {
                CountOddNumbers();
            }
        }

        /// <summary>
        /// Creates a unit matrix and saves it to the file
        /// </summary>
        public void MakeMatrix()
        {
            // Deletes the file before updating
            if (File.Exists(Program.fileNameT1))
            {
                File.Delete(Program.fileNameT1);
            }

            using (StreamWriter streamWriter = new StreamWriter(Program.fileNameT1))
            {
                string text;
                for (int row = 0; row < 100; row++)
                {
                    for (int col = 0; col < 100; col++)
                    {
                        // Checking if row is equal to column  
                        if (row == col)
                        {
                            text = "1";
                            streamWriter.Write(text);
                        }
                        else
                        {
                            text = "0";
                            streamWriter.Write(text);
                        }

                        if (col == 99)
                        {
                            streamWriter.WriteLine();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Generates a random odd number between 0 and 10000 and saves it to the file
        /// </summary>
        public void RandomNumber()
        {
            Random rnd = new Random();

            // Deletes the file before updating
            if (File.Exists(Program.fileNameT22))
            {
                File.Delete(Program.fileNameT22);
            }

            using (StreamWriter streamWriter = new StreamWriter(Program.fileNameT22))
            {
                for (int i = 0; i < 1000; i++)
                {
                    int num = rnd.Next(0, 10001);
                    if (num % 2 == 0)
                    {
                        i--;
                    }
                    else
                    {
                        streamWriter.WriteLine(num.ToString());
                    }
                    if (i == 999)
                    {
                        streamWriter.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Prints the values of the matrix file to the console
        /// </summary>
        public void PrintConsole()
        {
            if (File.Exists(Program.fileNameT1))
            {
                string line;

                StreamReader file = new StreamReader(Program.fileNameT1);
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                file.Close();
            }
        }

        /// <summary>
        /// Counts all random generated numbers from the file
        /// </summary>
        public void CountOddNumbers()
        {
            if (File.Exists(Program.fileNameT22))
            {
                string line;
                int number;
                int totalOddValue = 0;

                StreamReader file = new StreamReader(Program.fileNameT22);
                while ((line = file.ReadLine()) != null)
                {
                    number = int.Parse(line);
                    totalOddValue = totalOddValue + number;
                }

                Console.WriteLine("\nTotal odd value is: {0}\n", totalOddValue);

                file.Close();
            }
        }
    }
}
