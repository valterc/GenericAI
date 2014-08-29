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
    public class ResultEventArgs : EventArgs
    {
        public Result Result { get; internal set; }
        public Exception Error { get; internal set; }

        internal ResultEventArgs(Exception error)
        {
            this.Error = error;
        }

        internal ResultEventArgs(Result result)
        {
            this.Result = result;
        }

    }
}
