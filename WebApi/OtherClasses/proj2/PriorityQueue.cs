using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.OtherClasses.proj2
{
    public class PriorityQueue
    {
        /* Priority Queue Doesn't exsit in C# but it does have a sorted set/dictionary
         * Since it can't accept duplicate keys (how the set get sorted)
         * going to add a queue to that list that way if there is the same priority 
         * it adds it to the list
         */

        private SortedDictionary<int, Queue<string>> pq = new SortedDictionary<int, Queue<string>>();

        //Enqueue Method
        public void Enqueue(int priority, string item) {
            try {
                pq.Add(priority, new Queue<string>());
                pq[priority].Enqueue(item);
            }
            catch {
                pq[priority].Enqueue(item);
            }
        }

        //Dequeue Method
        public SortedDictionary<int,Queue<string>> Dequeue() {
            if(pq.Count == 0) {
                return pq;
            }
            else {
                if (pq.First().Value.Count() > 1) {
                    pq.First().Value.Dequeue();
                }
                else {
                    pq.Remove(pq.First().Key);
                }
                return pq;
            }
        }

        //goes (walks) through the list
        public List<string> Walk() {
            List<string> list = new List<string>();
            foreach(var x in pq) {
                foreach ( var y in x.Value) {
                    list.Add(y);
                }
            }
            return list;
        }
         
    }
}