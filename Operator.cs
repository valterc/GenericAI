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
    public abstract class Operator
    {
        public static Operator None
        {
            get
            {
                return default(Operator);
            }
        }

        public abstract State Apply(State state);
    }
}
