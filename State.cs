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
    public abstract class State : IEquatable<State>
    {
        public virtual Operator Operator { get; set; }
        public virtual State Parent { get; set; }
        internal virtual int CostFromBeginning { get; set; }
        internal virtual int EstimatedTotalCost { get; set; }

        /// <summary>
        /// Create a copy of the current state. Make sure that the current state or any of its children is not ReferenceEqual to the copy or its children.
        /// </summary>
        /// <returns>The new state</returns>
        public abstract State Copy();
        public abstract bool Equals(State other);
        public abstract bool IsGoal();
        public virtual bool IgnoreStateAndChilds()
        {
            return false;
        }

    }
}
