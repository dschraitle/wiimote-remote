using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace wiimoteremote
{
    public class Delay
    {
        DateTime start;
        bool delay = true;
        bool off = false;
        int repeat = 0;

        public Delay()
        {}

        public bool repeatbutton(int maxrepeat)
        {
            if (off)
                return false;
            TimeSpan duration = DateTime.Now - start;
            if (delay && duration.Milliseconds > 650)
            {
                delay = false;
                return true;
            }
            if (!delay)
            {
                if (repeat >= maxrepeat)
                {
                    repeat = 0;
                    return true;
                }
                else
                    repeat++;
            }
            return false;
        }

        public void reset()
        {
            delay = true;
            off = false;
            start = DateTime.Now;
            repeat = 0;
        }

        public void turnoff()
        {
            off = true;
        }
    }
}
