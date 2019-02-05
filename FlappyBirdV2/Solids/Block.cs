using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace FlappyBirdV2.Solids
{
    class Block : Entity
    {
        public double sizex { get; set; }
        public double sizey { get; set; }
        public double sizez { get; set; }
        public float[] color { get; set; }
        public Block(double x, double y, double z, double sizex, double sizey, double sizez, float[] color)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.sizex = sizex;
            this.sizey = sizey;
            this.sizez = sizez;
            this.color = color;
        }
        public override bool collide(Entity e)
        {
            throw new NotImplementedException();
        }

        public void draw()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(color[0], color[1], color[2]);

            //front
            GL.Normal3(0.0, 0.0, 1.0);
            GL.Vertex3(-(sizex / 2) + x, -(sizey / 2) + y, (sizez / 2) + z); //left bottom
            GL.Vertex3((sizex / 2) + x, -(sizey / 2) + y, (sizez / 2) + z); // right bottom
            GL.Vertex3((sizex / 2) + x, (sizey / 2) + y, (sizez / 2) + z); // top right
            GL.Vertex3(-(sizex / 2) + x, (sizey / 2) + y, (sizez / 2) + z); // top left

            //left
            GL.Normal3(-1.0, 0.0, 0.0);
            GL.Vertex3(-(sizex / 2) + x, -(sizey / 2) + y, -(sizez / 2) + z);
            GL.Vertex3(-(sizex / 2) + x, -(sizey / 2) + y, (sizez / 2) + z);
            GL.Vertex3(-(sizex / 2) + x, (sizey / 2) + y, (sizez / 2) + z);
            GL.Vertex3(-(sizex / 2) + x, (sizey / 2) + y, -(sizez / 2) + z);

            //right
            GL.Normal3(1.0, 0.0, 0.0);
            GL.Vertex3((sizex / 2) + x, -(sizey / 2) + y, -(sizez / 2) + z);
            GL.Vertex3((sizex / 2) + x, -(sizey / 2) + y, (sizez / 2) + z);
            GL.Vertex3((sizex / 2) + x, (sizey / 2) + y, (sizez / 2) + z);
            GL.Vertex3((sizex / 2) + x, (sizey / 2) + y, -(sizez / 2) + z);

            //back
            GL.Normal3(0.0, 0.0, -1.0);
            GL.Vertex3(-(sizex / 2) + x, -(sizey / 2) + y, -(sizez / 2) + z);
            GL.Vertex3((sizex / 2) + x, -(sizey / 2) + y, -(sizez / 2) + z);
            GL.Vertex3((sizex / 2) + x, (sizey / 2) + y, -(sizez / 2) + z);
            GL.Vertex3(-(sizex / 2) + x, (sizey / 2) + y, -(sizez / 2) + z);

            //top
            GL.Normal3(0.0, 1.0, 0.0);
            GL.Vertex3(-(sizex / 2) + x, (sizey / 2) + y, (sizez / 2) + z);
            GL.Vertex3((sizex / 2) + x, (sizey / 2) + y, (sizez / 2) + z);
            GL.Vertex3((sizex / 2) + x, (sizey / 2) + y, -(sizez / 2) + z);
            GL.Vertex3(-(sizex / 2) + x, (sizey / 2) + y, -(sizez / 2) + z);

            //bottom
            GL.Normal3(0.0, -1.0, 0.0);
            GL.Vertex3(-(sizex / 2) + x, -(sizey / 2) + y, (sizez / 2) + z);
            GL.Vertex3((sizex / 2) + x, -(sizey / 2) + y, (sizez / 2) + z);
            GL.Vertex3((sizex / 2) + x, -(sizey / 2) + y, -(sizez / 2) + z);
            GL.Vertex3(-(sizex / 2) + x, -(sizey / 2) + y, -(sizez / 2) + z);

            GL.End();
        }
    }
}
