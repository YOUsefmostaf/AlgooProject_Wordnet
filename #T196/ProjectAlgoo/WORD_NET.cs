using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace ProjectAlgoo
{
    class WORD_NET
    {
        private Initalize__And__Process__On__Graph DATA__PROC;

        private Direct_Acyclic_Graph GRAPH___DATA;

        public WORD_NET(string graphInputFile, string synsetsFile)
        {
            GRAPH___DATA = new Direct_Acyclic_Graph(synsetsFile, graphInputFile);
            DATA__PROC = new Initalize__And__Process__On__Graph(GRAPH___DATA);
        }
        public int GetSca(string s1, string s2, out HashSet<string> scList) // o(v^2)
        {
            return DATA__PROC.GET_SHORTEST_COMMEN_ANCESTPRS(s1, s2, out scList); // o(v^2)
        }
         int SemanticRelation(string s1, string s2)// o(v^2)
        {
            HashSet<string> n;
            return GetSca(s1, s2, out n);// o(v^2)
        }
         public string PRINT__OUTCAST__NOUN(List<string> NOUNS)// o(v^4)
        {
            //this lines o(1)
            int MAX = 0; 
            string OUTCAST__ = "all equal";
            var COMPARSION = true;

            for(int v = 0;v< NOUNS.Count();v++) // o(v^4)
            {
                int SUM = 0;
                for(int j=0;j< NOUNS.Count();j++) // o(v^3)
                {
                    SUM += SemanticRelation(NOUNS[v], NOUNS[j]); // o(v^2)
                }
                if (!COMPARSION) // o(1)
                {
                    if (SUM >= MAX) // o(1)
                    {
                        MAX = SUM;
                        OUTCAST__ = NOUNS[v];
                    }
                }
                else // o(1)
                {
                    MAX = SUM;
                    COMPARSION = false;
                    OUTCAST__ = NOUNS[v];
                }
            }
            return OUTCAST__;
        }
    }
}
