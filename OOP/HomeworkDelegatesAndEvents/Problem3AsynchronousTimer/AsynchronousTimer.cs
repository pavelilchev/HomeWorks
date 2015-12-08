using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem3AsynchronousTimer
{
    public class AsynchronousTimer
    {
        public AsynchronousTimer(Action<int> action, int ticks, int interval)
        {
            this.Ticks = ticks;
            this.Interval = interval;
            this.Action = action;
        }

        public int Ticks { get; set; }

        public int Interval { get; set; }

        public Action<int> Action { get; set; }

        public void Execute()
        {
            Thread newThread = new Thread(this.Run);
            newThread.Start();

        }

        private void Run()
        {
            Random random = new Random();

            while (this.Ticks > 0)
            {
                Thread.Sleep(this.Interval);
                this.Action(random.Next(100));
                this.Ticks--;
            }
        }
    }
}
