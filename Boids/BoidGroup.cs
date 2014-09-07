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
    public class BoidGroup
    {
        public List<Boid> Boids;

        public float Speed;
        public double Separation;
        public double Sight;

        public BoidGroup(float speed, double separation, double sight)
        {
            this.Speed = speed;
            this.Separation = separation;
            this.Sight = sight;
            this.Boids = new List<Boid>();
        }

        public virtual void Update(double elapsedTime)
        {

            for (int i = 0; i < Boids.Count; i++)
            {
                Boids[i].Update(elapsedTime);
            }
        }

    }
}
