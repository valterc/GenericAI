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

namespace GenericAI.Boids
{
    public class BoidEnvironment
    {
        public List<BoidGroup> BoidGroups;

        public BoidEnvironment()
        {
            BoidGroups = new List<BoidGroup>();
        }

        public void Update(double elapsedTime)
        {
            for (int i = 0; i < BoidGroups.Count; i++)
            {
                BoidGroups[i].Update(elapsedTime);
            }

        }

    }
}
