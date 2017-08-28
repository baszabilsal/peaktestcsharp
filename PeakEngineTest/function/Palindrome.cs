using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeakEngineTest
{
    class Palindrome : PalindromeInterface
    {
        public int Countpalindrome(List<string> stringdata) {
            int count = 0;
            // loop count find palindrome format
            foreach (var dummystring in stringdata) {
                //choose only english char
                var processstring = removestring(dummystring);
                //check if data don't empty
                if (!String.IsNullOrEmpty(processstring)) {
                    //process pelidrome check return boolean
                    if (checkpelidrome(processstring))
                    {
                        count++;
                    }
                }
            }
            // return number of count
            return count;
        }
        private string removestring(string data) {
            byte[] bytedata = Encoding.ASCII.GetBytes(data);
            // englist char in ASCII A-Z (65-90) a-z (97-122)
            byte[] byteoutput =  bytedata.Where(x => (x >= 65 && x <= 90)||(x >= 97 && x <= 122)).ToArray();
            string stringoutput = System.Text.Encoding.UTF8.GetString(byteoutput);
            // return string in lower
            return stringoutput.ToLower();
        }
        private bool checkpelidrome(string data)
        {
           
            bool check = true;
            //encode to byte 
            // englist char in ASCII A-Z (65-90) a-z (97-122)
            byte[] bytedata = Encoding.ASCII.GetBytes(data);
            
            // match first and last 
            int numberofbyte = bytedata.Count();
            // fix bug 21082017 error when have 1 char
            if (numberofbyte == 1)
            {
                check = false;
            }
            else
            {
                for (int i = 0; i <= numberofbyte / 2; i++)
                {
                    // first time when don't match check = false
                    if (bytedata[i] != bytedata[numberofbyte - (i + 1)])
                    {
                        check = false;
                    }
                }
            }
            return check;
        }
    }
}
