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

namespace GenericAI
{
    public class Result
    {
        /// <summary>
        /// The list of states from the beginning to the goal state.
        /// </summary>
        public List<State> States { get; private set; }

        /// <summary>
        /// The list of operations to transform the initial state into the final state.
        /// </summary>
        public List<Operator> Operations { get; private set; }

        /// <summary>
        /// The final State.
        /// </summary>
        public State Goal { get; private set; }

        internal Result(State state)
        {
            States = new List<State>();
            Operations = new List<Operator>();
            Goal = state;

            while (state != null && state.Operator != null)
            {
                Operations.Insert(0, state.Operator);
                States.Insert(0, state);
                state = state.Parent;
            }
        }

    }
}
