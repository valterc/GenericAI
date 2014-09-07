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
    public class Boid2D : Boid
    {
        public new BoidGroup2D Group;
        public Vector2 Position;
        public Vector2 Offset;
        public double Size;
        private Vector2 moveOffset;

        public Boid2D(BoidGroup2D group, Vector2 Position, double size)
            : base(group)
        {
            this.Group = group;
            this.Position = Position;
            this.Size = size;

            Group.Boids.Add(this);
        }

        public override void Update(double elapsedTime)
        {
            HandleEdgeCollisions();
            NormalizeOffset();
            Position += Offset;

            if (Offset == Vector2.Zero)
            {
                if (random.Next(100) < 20 || moveOffset == Vector2.Zero)
                {
                    moveOffset.X += random.Next((int)-Group.Speed, (int)Group.Speed);
                    moveOffset.Y += random.Next((int)-Group.Speed, (int)Group.Speed);
                }

                float offsetLength = moveOffset.Length();
                if (offsetLength > Group.Speed)
                {
                    moveOffset = moveOffset * Group.Speed / offsetLength;
                }

                Position += moveOffset;
            }

        }

        public override void UpdateBehaviour(double elapsedTime)
        {
            for (int i = 0; i < Group.Boids.Count; i++)
            {
                if (Group.Boids[i] == this) continue;

                float distance = Vector2.Distance(Position, Group.Boids[i].Position);

                if (distance < Group.Separation)
                {
                    Offset += Position - Group.Boids[i].Position;
                }
                else if (distance < Group.Sight)
                {
                    Offset += (Group.Boids[i].Position - Position) * 0.025f;
                }

                if (distance < Group.Sight)
                {
                    Offset += Group.Boids[i].Offset * 0.5f;
                }
            }
        }

        private void HandleEdgeCollisions()
        {
            //Left and top
            if (Position.X < Group.Border.Left)
            {
                Offset.X += Group.Border.Left - Position.X;
            }

            if (Position.Y < Group.Border.Top)
            {
                Offset.Y += Group.Border.Top - Position.Y;
            }

            //Right and bottom
            if (Position.X > Group.Border.Width)
            {
                Offset.X += Group.Border.Width - Position.X;
            }

            if (Position.Y > Group.Border.Height)
            {
                Offset.Y += Group.Border.Height - Position.Y;
            }
        }

        protected void NormalizeOffset()
        {
            float offsetLength = Offset.Length();

            if (offsetLength > Group.Speed)
            {
                Offset = Offset * Group.Speed / offsetLength;
            }
        }

    }
}
