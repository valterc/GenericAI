//----------------------------------------------------------------
//
//  Copyright (c) 2014 All Rights Reserved
//  Valter Costa
//
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericAI.Collections
{
    internal class PriorityStateQueue
    {
        private List<State> list;
        private Dictionary<int, int> priorityIndexer;

        public int Count
        {
            get
            {
                return list.Count;
            }
        }
        public bool IsEmpty
        {
            get
            {
                return list.Count == 0;
            }
        }

        public PriorityStateQueue()
        {
            this.priorityIndexer = new Dictionary<int, int>();
            this.list = new List<State>();
        }

        public PriorityStateQueue(int capacity)
        {
            this.priorityIndexer = new Dictionary<int, int>();
            this.list = new List<State>(capacity);
        }

        /// <summary>
        /// Add a State to the corresponding position on the Queue
        /// </summary>
        /// <param name="state">The state object to add</param>
        public void Push(State state)
        {
            int cost = state.EstimatedTotalCost;
            int index = priorityIndexer.Where(kv => kv.Key < cost).Sum(kv => kv.Value);

            if (priorityIndexer.ContainsKey(cost))
            {
                priorityIndexer[cost]++;
            }
            else
            {
                priorityIndexer.Add(cost, 1);
            }

            list.Insert(index, state);
        }

        /// <summary>
        /// Returns the first item on the Queue or null if the queue is empty
        /// </summary>
        /// <returns>First State or null</returns>
        public State Peek()
        {
            if (list.Count > 0)
            {
                return list[0];
            }

            return default(State);
        }

        /// <summary>
        /// Returns and removes the first item on the Queue or returns null if the queue is empty
        /// </summary>
        /// <returns>First State or null</returns>
        public State Pop()
        {
            if (list.Count == 0)
            {
                return default(State);
            }

            State state = list[0];
            list.Remove(state);

            int cost = state.EstimatedTotalCost;
            priorityIndexer[cost]--;

            return state;
        }

        /// <summary>
        /// Clears all the items on the Queue
        /// </summary>
        public void Clear()
        {
            list.Clear();
            priorityIndexer.Clear();
        }

        /// <summary>
        /// Checks if a State is on the this queue.
        /// </summary>
        /// <param name="state">The state to check</param>
        /// <returns>True if the state is in the queue, False otherwise</returns>
        public bool Contains(State state)
        {
            return list.Contains(state);
        }

        /// <summary>
        /// Finds a State in the queue that Equals anothe state.
        /// </summary>
        /// <param name="state">The state to match</param>
        /// <returns>The similar state</returns>
        public State GetSimilar(State state)
        {
            int index = list.IndexOf(state);
            if (index != -1)
            {
                return list[index];
            }

            return default(State);
        }

        /// <summary>
        /// Removes a State from the queue.
        /// </summary>
        /// <param name="state">The state to remove</param>
        public void Remove(State state)
        {
            State s = GetSimilar(state);
            if (s != default(State))
            {
                list.Remove(s);
                int cost = state.EstimatedTotalCost;
                priorityIndexer[cost]--;
            }
        }

    }
}
