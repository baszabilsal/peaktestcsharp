using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeakEngineTest
{
    public class Primefactor : PrimefactorInterface
    {
        private List<int> output = new List<int>();
        private int Findprime(int numinput)
        {
            // set dummynumber numberinput device 2 because for fast calculator
            int dummynum = numinput / 2;
            // loop for finding number and store prime factor in variable
            for (int primeval = 2; primeval <= dummynum + 1; primeval++)
            {

                if (numinput % primeval == 0)
                {
                    try
                    {
                        this.output.Add(primeval);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error when store number :" + ex);
                    }
                    int valueremain = numinput / primeval;
                    return valueremain;
                }

                else
                {
                    //add last number 
                    if (dummynum == primeval)
                    {
                        output.Add(numinput);
                    }
                }
            }
            return 0;

        }
        public List<int> PrimefactorCal(int num)
        {
            //if num less than 0
            if (num < 0)
            {
                int numforloop = num * -1;
                int countcheckwhenloopinfini = 0;
                //while loop stop when numforloop store in output and numforloop == 0 and stop when checkloop more than numforloop
                while (numforloop != 0 && countcheckwhenloopinfini <= numforloop)
                {
                    numforloop = Findprime(numforloop);
                    //forcheck infini loop
                    countcheckwhenloopinfini++;
                };
                output.Add(-1);
            }
            // if num more than 0
            else if (num > 0)
            {
                int numforloop = num;
                int countcheckwhenloopinfini = 0;
                //while loop stop when numforloop store in output and numforloop == 0 and stop when checkloop more than numforloop
                while (numforloop != 0 && countcheckwhenloopinfini <= numforloop)
                {
                    numforloop = Findprime(numforloop);
                    //forcheck infini loop
                    countcheckwhenloopinfini++;
                };
            }
            return output.Distinct().OrderBy(x => x).ToList();
        }

    }
}
