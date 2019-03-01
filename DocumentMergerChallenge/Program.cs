using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Merger
{
    class Program
    {
        static void Main(string[] args)
        {
            bool firstValid = true;
            Console.WriteLine("Document Merger");
            while (firstValid)
            {
                try
                {
                    string firstInput;
                    Console.Write("\nEnter first file name\n");
                    firstInput = Console.ReadLine();

                    string firstTxt = firstInput + ".txt";

                    string path = Directory.GetCurrentDirectory();

                    StreamReader sr = new StreamReader(firstTxt);
                    Console.WriteLine("Successfully found");
                    string firstLine = sr.ReadLine();
                    Console.WriteLine(firstLine);
                    sr.Close();
                    firstValid = false;
                    bool secValid = true;
                    while (secValid)
                    {
                        try
                        {
                            string secInput;
                            Console.Write("Enter second file name\n");
                            secInput = Console.ReadLine();

                            string secTxt = secInput + ".txt";

                            StreamReader sr2 = new StreamReader(secTxt);
                            Console.WriteLine("Successfully found");
                            string secLine = sr2.ReadLine();
                            sr2.Close();
                            secValid = false;

                            string mergedFile = firstInput + secInput + ".txt";
                            StreamWriter sw = new StreamWriter(mergedFile);
                            sw.WriteLine(firstLine);
                            sw.WriteLine(secLine);
                            sw.Close();

                            int count = 0;
                            StreamReader sr3 = new StreamReader(mergedFile);
                            foreach (char c in mergedFile)
                            {
                                count++;
                            }
                            Console.WriteLine("{0} was successfully saved. The document contains {1} characters.", mergedFile, count);
                            Console.WriteLine("Would you like to merge another file? (Y/N)");
                            ConsoleKeyInfo mg = Console.ReadKey();
                            firstValid = (mg.Key == ConsoleKey.Y);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: " + e.Message);
                            secValid = true;
                            continue;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    firstValid = true;
                    continue;
                }
            }while (firstValid);
            Console.ReadLine();
        }
    }
}
