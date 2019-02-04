using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlappyBirdV2.Solids;

namespace FlappyBirdV2
{
    class Bird : Cube
    {
        public double gravity { get; private set; }
        public double velocity { get; private set; }
        public Bird(double x, double y, double z, double size, float[] color) : base(x, y, z, size, color)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.size = size;
            this.color = color;

            gravity = 0.7;
            velocity = y;
        }

        public void moveUp()
        {
            velocity += gravity * 3;
        }

        public void update()
        {
            velocity += -1 * (gravity);
            this.y = velocity;

            if (this.y <= -30)
            {
                this.y = -30;
                velocity = this.y;
            }

            if (this.y >= 30)
            {
                this.y = 30;
                velocity = this.y;
            }
        }

        public void pipeCollide(Pipe pipe)
        {
            this.collide(pipe.bottomPart);
            this.collide(pipe.topPart);
        }
    }
}
