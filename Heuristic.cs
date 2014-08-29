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
    public abstract class Heuristic
    {
        public abstract int EstimateCostToGoal(State current);
        public abstract int CostBetweenStates(State state0, State state1);
    }
}
