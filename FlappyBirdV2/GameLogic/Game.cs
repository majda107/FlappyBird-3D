using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using FlappyBirdV2.Solids;

namespace FlappyBirdV2.GameLogic
{
    enum GameState { Menu, InGame };
    class Game
    {
        public GameWindow gw { get; private set; }
        public GameData gd { get; private set; }
        public GameState gs { get; private set; }

        private bool mouseDown;
        private bool spaceDown;

        public Game(GameWindow gw)
        {
            this.mouseDown = false;
            this.spaceDown = false;
            
            this.gw = gw;
            this.gd = new GameData(1.0);
            this.gs = GameState.InGame;
        }
        
        public void Start()
        {
            gd.Collide += Collision;

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

        private void Loaded(Object o, EventArgs e)
        {
            GL.ClearColor(1.0f, 1.0f, 1.0f, 0.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.ColorMaterial);

            GL.Light(LightName.Light0, LightParameter.Position, new float[] { 10f, 10f, 50f });
            GL.Light(LightName.Light0, LightParameter.Ambient, new float[] { 0.5f, 0.5f, 0.5f });
            GL.Light(LightName.Light0, LightParameter.Diffuse, new float[] { 1.0f, 1.0f, 1.0f });

            GL.Enable(EnableCap.Light0);
        }

        private void RenderF(Object o, EventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); // clearing buffers

            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView((float)MathHelper.DegreesToRadians(45.0), (float)gw.Width / (float)gw.Height, 1.0f, 1000.0f);
            GL.LoadMatrix(ref perspective);
            GL.MatrixMode(MatrixMode.Modelview);

            GL.LoadIdentity(); // reseting matrix

            GL.Translate(0.0, 0.0, -80.0);
            GL.Rotate(-25, 0.0, 1.0, 0.0);

            if (gs == GameState.InGame)
            {
                gd.Frame(this.mouseDown, this.spaceDown);
            }

            gw.SwapBuffers();
        }

        private void Collision(Object o, FlappyEventArgs e)
        {
            gd = new GameData(1.0);
            Console.WriteLine(e.score);
            gd.Collide += Collision;
        }

        public void Resized(Object o, EventArgs e)
        {
            GL.Viewport(0, 0, gw.Width, gw.Height);
        }
    }
}
