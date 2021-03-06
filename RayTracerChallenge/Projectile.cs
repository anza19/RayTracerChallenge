using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerChallenge
{
    public class Projectile
    {
        public Point position;
        public Vector velocity;

        public Projectile() { }
        public Projectile(Point position, Vector velocity)
        {
            this.position = position;
            this.velocity = velocity;
        }

        //this method returns a new projectile
        //representing a given projectile after a unit of time has passed
        public Projectile Tick(Environment env, Projectile proj)
        {
            //this method returns the new position and velocity of a projectile after a unit of time has passed
            
            //new position after a tick has passed
            //formula: position = proj.position + proj.velocity
            Point newPosition = position.PointVectorAddition(proj.position, proj.velocity);

            //new velocity after a tick has passed
            //formula: velocity = proj.velocity + env.gravity + env.wind
            Vector tempVelocity = velocity.VectorAddition(proj.velocity, env.gravity);
            Vector newVelocity = velocity.VectorAddition(tempVelocity, env.wind);

            //returning the new position and velocity of the projectile after a tick has passed
            return new Projectile(newPosition, newVelocity);
        }
    }
}
