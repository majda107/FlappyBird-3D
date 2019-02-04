using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using FlappyBirdV2.Solids;

namespace FlappyBirdV2
{
    class Game
    {
        public GameWindow gw { get; private set; }

        public double frameCount;

        public Bird bird;
        public List<Pipe> pipes;

        private bool mouseDown;
        private bool spaceDown;

        private Random rand;
        public Game(GameWindow gw)
        {
            
            this.rand = new Random();
            this.pipes = new List<Pipe>();
            this.bird = new Bird(0, 0, 0, 5, new float[3] { 0.6f, 0.2f, 0.2f });

            this.mouseDown = false;
            this.spaceDown = false;
            
            this.gw = gw;
            this.frameCount = 0;
        }

        public void Start()
        {
            gw.Load += Loaded;

            gw.MouseDown += MouseDown;
            gw.MouseUp += MouseUp;

            gw.KeyDown += KeyDown;
            gw.KeyUp += KeyUp;

            gw.RenderFrame += RenderF;
            gw.Resize += Resized;
            gw.Run(1 / 60);
        }

        private void MouseDown(Object o, EventArgs e)
        {
            mouseDown = true;
        }

        private void MouseUp(Object o, EventArgs e)
        {
            mouseDown = false;
        }

        private void KeyDown(Object o, OpenTK.Input.KeyboardKeyEventArgs e)
        {
            if (e.Key == OpenTK.Input.Key.Space) spaceDown = true;
        }

        private void KeyUp(Object o, OpenTK.Input.KeyboardKeyEventArgs e)
        {
            if (e.Key == OpenTK.Input.Key.Space) spaceDown = false;
        }

        public void Loaded(Object o, EventArgs e)
        {
            GL.ClearColor(1.0f, 1.0f, 1.0f, 0.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.ColorMaterial);

            float[] light_pos = { 10f, 10f, 50f };
            float[] ambient = { 0.5f, 0.5f, 0.5f };
            float[] diffuse = { 1.0f, 1.0f, 1.0f };

            GL.Light(LightName.Light0, LightParameter.Position, light_pos);
            GL.Light(LightName.Light0, LightParameter.Ambient, ambient);
            GL.Light(LightName.Light0, LightParameter.Diffuse, diffuse);

            GL.Enable(EnableCap.Light0);
        }

        public void RenderF(Object o, EventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView((float)MathHelper.DegreesToRadians(45.0), (float)gw.Width / (float)gw.Height, 1.0f, 1000.0f);
            GL.LoadMatrix(ref perspective);
            GL.MatrixMode(MatrixMode.Modelview);

            GL.LoadIdentity();

            GL.Translate(0.0, 0.0, -80.0);
            GL.Rotate(-25, 0.0, 1.0, 0.0);

            if (this.mouseDown || this.spaceDown) bird.moveUp();

            if(frameCount % 80 == 0) pipes.Add(new Pipe(0, 0, -600, 10, 80, 10, rand.Next(-20, 20), 20));

            bird.update();
            bird.draw();

            for (int i = pipes.Count - 1; i >= 0; i--)
            {
                pipes[i].draw();
                pipes[i].update();

                bird.pipeCollide(pipes[i]);

                if (pipes[i].zPos > 200) pipes.RemoveAt(i);
            }

            gw.SwapBuffers();

            frameCount++;
        }

        public void Resized(Object o, EventArgs e)
        {
            GL.Viewport(0, 0, gw.Width, gw.Height);
        }
    }
}
