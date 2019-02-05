using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlappyBirdV2.GameObjects;

namespace FlappyBirdV2.GameLogic
{
    class GameData
    {
        public delegate void FlappyEventHandler(object sender, FlappyEventArgs e);
        public event FlappyEventHandler Collide;

        private Random rand;
        public Bird bird { get; private set; }
        public List<Pipe> pipes { get; private set; }

        public double frameCount { get; private set; }
        public double gameSpeed { get; private set; }
        public int score { get; private set; }

        public GameData(double gameSpeed)
        {
            this.frameCount = 0;
            this.score = 0;
            this.gameSpeed = gameSpeed;

            this.rand = new Random();
            this.pipes = new List<Pipe>();
            this.bird = new Bird(0, 0, 0, 5, new float[3] { 0.6f, 0.2f, 0.2f });
        }

        public void Frame(bool mouseDown, bool spaceDown)
        {
            if (mouseDown || spaceDown) bird.moveUp();

            bird.update();

            if (frameCount % 80 == 0) pipes.Add(new Pipe(0, 0, -600, 10, 80, 10, rand.Next(-20, 20), 20));
            for (int i = pipes.Count - 1; i >= 0; i--)
            {
                pipes[i].update(this.gameSpeed);

                if (bird.pipeCollide(pipes[i]))
                {
                    FireCollisionEvent(new FlappyEventArgs(score));
                }

                if (pipes[i].zPos > 100)
                {
                    score++;
                    pipes.RemoveAt(i);
                }
            }

            frameCount++;
        }

        private void FireCollisionEvent(FlappyEventArgs e)
        {
            if(Collide != null) Collide(this, e);
        }
    }
}
