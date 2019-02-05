using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdV2
{
    class FlappyEventArgs : EventArgs
    {
        public int score { get; set; }
        public FlappyEventArgs(int score)
        {
            this.score = score;
        }
    }
}
