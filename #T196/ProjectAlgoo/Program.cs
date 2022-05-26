using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ProjectAlgoo
{
    class Program
    {
        static void Main(string[] args)
        {
            //path of each file 
            string[] lines1 = System.IO.File.ReadAllLines("Testcases/Sample/Case1/Input/3RelationsQueries.txt");
            //string[] lines2 = System.IO.File.ReadAllLines("Testcases/Sample/Case2/Input/4OutcastQueries.txt");
            WORD_NET DataGraph = new WORD_NET("Testcases/Sample/Case1/Input/2hypernyms.txt", "Testcases/Sample/Case1/Input/1synsets.txt");
            string[] output_relation = new string[lines1.Length];//read relation file line by line in output_relation array
           // string[] output_outcast = new string[lines2.Length];//read outcast file line by line in output_outcast array
            // next four variable o(1)
            HashSet<String> hs;
            string[] strs_plit1; 
            int output;
            string concatenate_result;

            for (int i = 1; i< lines1.Length;i++) // o(v^3)
            {
                concatenate_result = "";
                strs_plit1 = lines1[i].Split(",");
                output = DataGraph.GetSca(strs_plit1[0], strs_plit1[1], out hs);// o(v^2)
                concatenate_result += output + ","  ;
                foreach (var x in hs) // o(v)
                {
                    concatenate_result += x;
                }
                output_relation[i - 1] = concatenate_result;
            }
            


            File.WriteAllLines("output/relation_output.txt", output_relation);


            /*
            string[] strs_plit2;
            for (int i = 1; i < lines2.Length; i++)
            {
                List<string> list_for_outcast = new List<string>();


                strs_plit2 = lines2[i].Split(",");

                foreach (var x in strs_plit2)
                {
                    list_for_outcast.Add(x);
                }
                output_outcast[i-1] = DataGraph.PRINT__OUTCAST__NOUN(list_for_outcast);
            }

            File.WriteAllLines("output/outcast_output.txt", output_outcast);
            */

        }
    }
}
