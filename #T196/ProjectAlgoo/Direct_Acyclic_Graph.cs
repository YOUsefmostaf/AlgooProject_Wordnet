using System;

using System.Collections.Generic;
using System.Diagnostics;

using System.IO;

using System.Linq;

using System.Text.RegularExpressions;

namespace ProjectAlgoo
{
    class Direct_Acyclic_Graph
    {
        public Dictionary<int, HashSet<int>> __Graph__ = new Dictionary<int, HashSet<int>>();
        public Dictionary<int, HashSet<string>> __SYNSET_GRAPH__ = new Dictionary<int, HashSet<string>>();

        public Dictionary<string, SortedSet<int>> ____NOUNS_GRAPH__ = new Dictionary<string, SortedSet<int>>();


        public Direct_Acyclic_Graph(string Synset__File, string Hypernyms__File)
        {
            
            Initialize__NOUNS__(Synset__File);

            DRAW_GRAPH_HYPERNAMES(Hypernyms__File);
        }
        
        private void Initialize__NOUNS__(string pFilePath) // o(v^2 log(n))
        {
            // this variable o(1)
            var __READER_ = new StreamReader(pFilePath);
            string __LINES;
            string[] DATA__;
            int NOUN__ID;
            //o(v^2 log(n))
            do
            {
                // this line o(1)
                __LINES = __READER_.ReadLine();
                DATA__ = __LINES.Split(",");
                string[] NOUNS__ = DATA__[1].Split(' ');
                int.TryParse(DATA__[0], out NOUN__ID);
                __SYNSET_GRAPH__.Add(NOUN__ID, new HashSet<string>(NOUNS__));

                for (int i = 0; i < NOUNS__.Count(); i++) // o(v log(n))
                {
                    SortedSet<int> nounIds;
                    if (!____NOUNS_GRAPH__.TryGetValue(NOUNS__[i], out nounIds)) //o(1)
                    {
                        nounIds = new SortedSet<int>();
                    }
                    nounIds.Add(NOUN__ID); //o(log(n))
                    if (____NOUNS_GRAPH__.ContainsKey(NOUNS__[i])) // o(1)
                    {
                        ____NOUNS_GRAPH__[NOUNS__[i]] = nounIds;
                    }

                    else // o(1)
                    {
                        ____NOUNS_GRAPH__.Add(NOUNS__[i], nounIds);
                    }


                }

            } while (!__READER_.EndOfStream);
        }

        private void DRAW_GRAPH_HYPERNAMES(string Hypernyms__File) //o(v^2)
        {
            //this lines o(1)
            var __READER_ = new StreamReader(Hypernyms__File);
            string __LINES;
            string[] strs_plit1;
            string CHILD;
            int INT__CHILD;

            do //o(v^2)
            {
                //this lines o(1)
                __LINES = __READER_.ReadLine();
                strs_plit1 = __LINES.Split(',');
                CHILD = strs_plit1[0];
                var LIST_TO_CHILD = new HashSet<int>();
                int i = 1;

                while(i < strs_plit1.Count()) // o(v)
                {
                    LIST_TO_CHILD.Add(int.Parse(strs_plit1[i]));
                    i++;
                }

                INT__CHILD = int.Parse(CHILD); // o(1)
            
                if (!__Graph__.ContainsKey(INT__CHILD)) //o(1)
                {
                    __Graph__.Add(int.Parse(CHILD), LIST_TO_CHILD);
                }
                
            } while (!__READER_.EndOfStream);
            
        }






        public HashSet<int> GET__PARENTS_TO_SPACIFIC_CHILD(int child) //o(1)
        {
            if (__Graph__.ContainsKey(child)) //o(1)
                return __Graph__[child];

            return new HashSet<int>();
        }
        public HashSet<int> this[int key] => GET__PARENTS_TO_SPACIFIC_CHILD(key); //o(1)






    }
}
