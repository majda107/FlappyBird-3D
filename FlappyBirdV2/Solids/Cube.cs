using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace FlappyBirdV2.Solids
{
    class Cube : Entity
    {
        public double size { get; set; }
        public float[] color { get; set; }
        public Cube(double x, double y, double z, double size, float[] color)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.size = size;
            this.color = color;
        }
        public override void collide(Entity e)
        {
            if(e is Block)
            {
                Block block = e as Block;
                double x1 = -(size / 2) + x;
                double x2 = (size / 2) + x;
                double x3 = -(block.sizex / 2) + block.x;
                double x4 = (block.sizex / 2) + block.x;

                double y1 = -(size / 2) + y;
                double y2 = (size / 2) + y;
                double y3 = -(block.sizey / 2) + block.y;
                double y4 = (block.sizey / 2) + block.y;

                double z1 = -(size / 2) + z;
                double z2 = (size / 2) + z;
                double z3 = -(block.sizez / 2) + block.z;
                double z4 = (block.sizez / 2) + block.z;

                //NOTE: could be written on one line, keeping it itemized for possible future debugging

                if ((x2 > x3 && x1 < x4) && (y2 > y3 && y1 < y4) && (z2 > z3 && z1 < z4))
                {
                    Console.WriteLine("Collision!");
                }
            }
        }

        public void draw()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(color[0], color[1], color[2]);

            //front
            GL.Normal3(0.0, 0.0, 1.0);
            GL.Vertex3(-(size / 2) + x, -(size / 2) + y, (size / 2) + z); //left bottom
            GL.Vertex3((size / 2) + x, -(size / 2) + y, (size / 2) + z); // right bottom
            GL.Vertex3((size / 2) + x, (size / 2) + y, (size / 2) + z); // top right
            GL.Vertex3(-(size / 2) + x, (size / 2) + y, (size / 2) + z); // top left

            //left
            GL.Normal3(-1.0, 0.0, 0.0);
            GL.Vertex3(-(size / 2) + x, -(size / 2) + y, -(size / 2) + z);
            GL.Vertex3(-(size / 2) + x, -(size / 2) + y, (size / 2) + z);
            GL.Vertex3(-(size / 2) + x, (size / 2) + y, (size / 2) + z);
            GL.Vertex3(-(size / 2) + x, (size / 2) + y, -(size / 2) + z);

            //right
            GL.Normal3(1.0, 0.0, 0.0);
            GL.Vertex3((size / 2) + x, -(size / 2) + y, -(size / 2) + z);
            GL.Vertex3((size / 2) + x, -(size / 2) + y, (size / 2) + z);
            GL.Vertex3((size / 2) + x, (size / 2) + y, (size / 2) + z);
            GL.Vertex3((size / 2) + x, (size / 2) + y, -(size / 2) + z);

            //back
            GL.Normal3(0.0, 0.0, -1.0);
            GL.Vertex3(-(size / 2) + x, -(size / 2) + y, -(size / 2) + z);
            GL.Vertex3((size / 2) + x, -(size / 2) + y, -(size / 2) + z);
            GL.Vertex3((size / 2) + x, (size / 2) + y, -(size / 2) + z);
            GL.Vertex3(-(size / 2) + x, (size / 2) + y, -(size / 2) + z);

            //top
            GL.Normal3(0.0, 1.0, 0.0);
            GL.Vertex3(-(size / 2) + x, (size / 2) + y, (size / 2) + z);
            GL.Vertex3((size / 2) + x, (size / 2) + y, (size / 2) + z);
            GL.Vertex3((size / 2) + x, (size / 2) + y, -(size / 2) + z);
            GL.Vertex3(-(size / 2) + x, (size / 2) + y, -(size / 2) + z);

            //bottom
            GL.Normal3(0.0, -1.0, 0.0);
            GL.Vertex3(-(size / 2) + x, -(size / 2) + y, (size / 2) + z);
            GL.Vertex3((size / 2) + x, -(size / 2) + y, (size / 2) + z);
            GL.Vertex3((size / 2) + x, -(size / 2) + y, -(size / 2) + z);
            GL.Vertex3(-(size / 2) + x, -(size / 2) + y, -(size / 2) + z);

            GL.End();
        }
    }
}
