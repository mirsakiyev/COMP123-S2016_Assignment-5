using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/**
 * Assignment #5
 * Author : Aslan Mirsakiyev
 * Student ID : 300850326
 * Date : 07.22.2016
 * Submitted to : Tom Tsiliopoulos
 * GitHub link : https://github.com/mirsakiyev/COMP123-S2016_Assignment-5
 *
 */
namespace COMP123_S2016_Assignment_5
{
    /**
    * This class is the driver class for our Program
    * 
    * @class Program
    */
    class Program
    {
        /**
         * The main method for our driver class Program
         *
         * @method Main
         * @param {string[]} args
         */
        static void Main(string[] args)
        {
            Console.WriteLine("1) Display Grades  (Type '1', enter)");
            Console.WriteLine("2) Exit            (Type '2', enter)");

            int userInput = int.Parse(Console.ReadLine());
            Console.WriteLine(userInput);
            Console.Clear();
            if (userInput == 1)
            {
                Console.Clear();
                try
                {
                    List<Student> students = new List<Student>();

                    const string FILENAME = "..\\..\\StudentData.txt";
                    const char DELIM = ',';
                    //const char DELIM_1 = ':';

                    // opening filestream
                    FileStream inFile = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(inFile);

                    // setup variables to temporariliy hold my data
                    string recordString;
                    string[] fields;

                    // read from file and assign the record to recordIN
                    recordString = reader.ReadLine();

                    while (recordString != null)
                    {
                        Student student = new Student();
                        fields = recordString.Split(DELIM);
                        student.LastName = fields[0];
                        student.FirstName = fields[1];
                        student.ID = fields[2];
                        student.Grade = fields[3];
                        students.Add(student);

                        Console.WriteLine("{0} , {1} : {2} , {3}",
                            student.LastName,
                            student.FirstName,
                            student.ID,
                            student.Grade);


                        recordString = reader.ReadLine();
                    }

                    // close streams
                    reader.Close();
                    inFile.Close();
                }
                catch (Exception exception)
                {

                    Console.WriteLine("Error: " + exception.Message);
                }
                Console.WriteLine();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
