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
    public abstract class Boid
    {
        protected static Random random = new Random();
        public BoidGroup Group;

        public Boid(BoidGroup group)
        {
            this.Group = group;
        }

        public abstract void Update(double elapsedTime);
        public abstract void UpdateBehaviour(double elapsedTime);

    }
}
