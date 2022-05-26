using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ProjectAlgoo
{
    class Initalize__And__Process__On__Graph
    {
        public Direct_Acyclic_Graph GRAPH;

        public Initalize__And__Process__On__Graph(Direct_Acyclic_Graph data__graph)
        {
            GRAPH = data__graph;

        }
        public bool GRAPH__VALIDATION(Direct_Acyclic_Graph pGraph)
        {
            var ROOTED = CHECK__THE_ROOTE();
            return ROOTED ;
        }
        public bool CHECK__THE_ROOTE() // o(v^2)
        {
            //this lines o(1)
            int __ROOTED = 0;
            int COUNT_OF_ROOT = 0;
            bool __ASSIGNED = false;
            int COUNT = 0;
            var VALUE__OF_KEY = GRAPH.__Graph__.Keys.ElementAt(0);
            int IN_COUNT = 0;
            var PARENT__ = GRAPH[VALUE__OF_KEY].ElementAt(0);

            while (COUNT < GRAPH.__Graph__.Keys.Count()) // o(v^2)
            {
                VALUE__OF_KEY = GRAPH.__Graph__.Keys.ElementAt(COUNT);
                while(IN_COUNT < GRAPH[VALUE__OF_KEY].Count) // o(v)
                {
                    PARENT__ = GRAPH[VALUE__OF_KEY].ElementAt(IN_COUNT);
                    if (GRAPH[PARENT__].Count == 0) //o(1)
                    {
                        if (__ASSIGNED) //o(1)
                        {
                            if (__ROOTED != PARENT__) //o(1)
                            {
                                COUNT_OF_ROOT++;
                                __ROOTED = PARENT__;
                            }
                        }
                        else //o(1)
                        {
                            __ROOTED = PARENT__;
                            COUNT_OF_ROOT++;
                            __ASSIGNED = true;

                        }
                    }
                    IN_COUNT++;
                }
                COUNT++;
            }
            return COUNT_OF_ROOT == 1;
        }


       

        public int GET_SHORTEST_COMMEN_ANCESTPRS(string PN1_, string PN2_, out HashSet<string> LIST_OF_SYNSET) // o(v^2)
        {
            // this lines o(1)
            int FIRST_LOOP = 0;
            int SECOND__LOOP = 0;
            int THIRD__LOOP = 0;
            var GOAL__ = GRAPH.____NOUNS_GRAPH__[PN2_];
            var START__ = GRAPH.____NOUNS_GRAPH__[PN1_];
            var DESTANCE_FROM_START = new Dictionary<int, int>();
            var DESTANT__TO_GOAL = new Dictionary<int, int>();
            var VISITED_DEC_START = new Dictionary<int, bool>();
            var VISITED_DEC_GOAL = new Dictionary<int, bool>();
            var __MINIMAM_DESTANS = int.MaxValue;
            int SHORTEST_COMMEN_ANCESTPRS = 0;
            var QUEUE_OF_NODES = new Queue<KeyValuePair<int, char>>();

            //a char is whether an 's' or an 'g' to see where that node comes from in the current front of the queue 
            do // o(v)
            {
                VISITED_DEC_GOAL.Add(GOAL__.ElementAt(FIRST_LOOP), true);
                QUEUE_OF_NODES.Enqueue(new KeyValuePair<int, char>(GOAL__.ElementAt(FIRST_LOOP), 'g'));
                DESTANT__TO_GOAL.Add(GOAL__.ElementAt(FIRST_LOOP), 0);

                FIRST_LOOP++;
            } while (FIRST_LOOP < GOAL__.Count);
            do // o(v)
            {
                QUEUE_OF_NODES.Enqueue(new KeyValuePair<int, char>(START__.ElementAt(SECOND__LOOP), 's'));
                VISITED_DEC_START.Add(START__.ElementAt(SECOND__LOOP), true);
                DESTANCE_FROM_START.Add(START__.ElementAt(SECOND__LOOP), 0);

                SECOND__LOOP++;
            }while(SECOND__LOOP < START__.Count);

            //traverse the graph !wisely
            while(QUEUE_OF_NODES.Count > 0) // o(v^2)
            {
                var queueFront = QUEUE_OF_NODES.Peek(); //o(1)
                if ((queueFront.Value == 'g' && VISITED_DEC_START.ContainsKey(queueFront.Key)) ||
                    (queueFront.Value == 's' && VISITED_DEC_GOAL.ContainsKey(queueFront.Key))) //o(1)
                {
                    var currentDistance = 0 + DESTANT__TO_GOAL[queueFront.Key] + DESTANCE_FROM_START[queueFront.Key] ;
                     if(currentDistance < __MINIMAM_DESTANS) // o(1)
                    {
                        SHORTEST_COMMEN_ANCESTPRS = QUEUE_OF_NODES.Peek().Key;
                        __MINIMAM_DESTANS = currentDistance;
                    }
                }
             
                for (var i = 0; i < GRAPH[queueFront.Key].Count; i++) // o(v)
                {
                    var node = GRAPH[queueFront.Key].ElementAt(i);

                    if (queueFront.Value == 's') // o(1)
                    {
                        if (!VISITED_DEC_START.ContainsKey(node)) // o(1)
                        {
                                VISITED_DEC_START.Add(node, true);
                                QUEUE_OF_NODES.Enqueue(new KeyValuePair<int, char>(node, 's'));

                                DESTANCE_FROM_START.Add(node, DESTANCE_FROM_START[queueFront.Key] + 1);
                        }
                    }
                    else if (queueFront.Value == 'g') // o(1)
                    {
                        if (!VISITED_DEC_GOAL.ContainsKey(node)) // o(1)
                        {
                                VISITED_DEC_GOAL.Add(node, true);
                                QUEUE_OF_NODES.Enqueue(new KeyValuePair<int, char>(node, 'g'));

                                DESTANT__TO_GOAL.Add(node, DESTANT__TO_GOAL[queueFront.Key] + 1);
                        }
                    }
                }
                QUEUE_OF_NODES.Dequeue();
            }
            LIST_OF_SYNSET = GRAPH.__SYNSET_GRAPH__[SHORTEST_COMMEN_ANCESTPRS];
            return __MINIMAM_DESTANS;
        }

        
    }

}

