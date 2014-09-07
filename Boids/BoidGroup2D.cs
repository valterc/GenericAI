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
    class BoidGroup2D : BoidGroup
    {
        public new List<Boid2D> Boids;
        public Rectangle Border;

        public BoidGroup2D(float speed, double separation, double sight, Rectangle border)
            : base(speed, separation, sight)
        {
            this.Border = border;
            this.Boids = new List<Boid2D>();
        }

        public override void Update(double elapsedTime)
        {
            for (int i = 0; i < Boids.Count; i++)
            {
                Boids[i].Update(elapsedTime);
            }
        }

    }
}
