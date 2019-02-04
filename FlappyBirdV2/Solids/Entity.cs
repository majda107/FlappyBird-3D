using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace FlappyBirdV2.Solids
{
    abstract class Entity
    {
        public double x;
        public double y;
        public double z;

        public void moveTo(double newX, double newY, double newZ)
        {
            this.x = newX;
            this.y = newY;
            this.z = newZ;
        }

        public void moveTo(Vector3 newPos)
        {
            this.x = newPos.X;
            this.y = newPos.Y;
            this.z = newPos.Z;
        }

        public Vector3 getSize()
        {
            return new Vector3((float)x, (float)y, (float)z);
        }
        public abstract void collide(Entity e);
    }
}
