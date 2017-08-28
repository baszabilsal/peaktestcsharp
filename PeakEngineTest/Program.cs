using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace PeakEngineTest
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var inputdata = "start";

            // loop while if want exit loop type "exit"
            while (inputdata.ToLower() != "exit") {
                Console.WriteLine("Please type function and input :");
                //input data
                inputdata = Console.ReadLine();
             
                //check input 
                if (inputdata.Split(' ').Count() > 1) {
                    //run program
                    Run(inputdata);
                }
                else
                {
                    Console.WriteLine("Error no input and Error function name please type :");
                    Console.WriteLine("-list function");
                }
            }
            
        }
        private static void Run(string functionandinput) {
            //seperate data
            string[] inputdata2 = functionandinput.Split(' ');
            // run in prime_factor function
            if (inputdata2[0].ToLower() == "prime_factors")
            {
                int numberinput = 0;
                try
                {
                    Primefactor fn = new Primefactor();
                    //number input
                    numberinput = Convert.ToInt32(inputdata2[1]);
                    // run function to find prime factors
                    List<int> output = fn.PrimefactorCal(numberinput);
                    // Show output
                    Console.WriteLine("Prime factors is :");
                    string stringoutput = "";
                    foreach (var dm in output)
                    {
                        stringoutput += dm + " ";
                    }
                    Console.WriteLine(stringoutput);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error input data");
                }
            }
            // run in count_palindrom function
            else if (inputdata2[0].ToLower() == "count_palindrome")
            {
                List<string> datainput = new List<string>();
                string filefullpath = inputdata2[1];
                string filewithlocalpath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + filefullpath;
                //read file in path
                if (File.Exists(filefullpath))
                {
                    datainput = File.ReadAllLines(filefullpath).ToList();
                }
                //read file with local path
                else if (File.Exists(filewithlocalpath)) {
                   
                    datainput = File.ReadAllLines(filewithlocalpath).ToList();
                }
                else {
                    Console.WriteLine("input file not exits");
                }
                Palindrome pd = new Palindrome();
                //check empty file
                if (datainput.Count() > 0)
                {
                    //count palindrome format
                   int countpalindrome =  pd.Countpalindrome(datainput);
                    // print to console
                        Console.WriteLine("Number of Palindrome format :");
                        Console.WriteLine(countpalindrome);
      
                }
                else {
                    Console.WriteLine("empty file");
                }

            }
            // list function name
            else if (functionandinput == "-list function")
            {
                Console.WriteLine("Function name below :");
                Console.WriteLine("prime_factors");
                Console.WriteLine("count_palindrome");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Error function name please type :");
                Console.WriteLine("-list function");
            }
        }
    }
   
}
