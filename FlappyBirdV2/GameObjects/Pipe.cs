using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlappyBirdV2.Solids;

namespace FlappyBirdV2.GameObjects
{
    class Pipe
    {
        public Block bottomPart;
        public Block topPart;

        public double zSpeed { get; private set; }
        public double zPos { get; private set; }
        public Pipe(double x, double y, double z, double width, double height, double depth, double holey, double holeheight)
        {
            double bottomPartHeight = holey + (height / 2) - (holeheight / 2);
            double bottomPartY = -1*(height - bottomPartHeight) / 2; 
            bottomPart = new Block(x, bottomPartY, z, width, bottomPartHeight, depth, new float[3] { 0.2f, 0.7f, 0.2f});

            double topPartHeight = (height / 2) - (holeheight / 2) - holey;
            double topPartY = (height - topPartHeight) / 2;
            topPart = new Block(x, topPartY, z, width, topPartHeight, depth, new float[3] { 0.2f, 0.7f, 0.2f });

            this.zPos = z;
            this.zSpeed = 1.0;
        }

        public void update(double gameSpeed)
        {
            this.zPos += (zSpeed) * gameSpeed;

            this.bottomPart.z = zPos;
            this.topPart.z = zPos;

            this.draw();
        }

        private void draw()
        {
            this.topPart.draw();
            this.bottomPart.draw();
        }
    }
}
