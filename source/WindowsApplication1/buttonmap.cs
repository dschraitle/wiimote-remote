using System;
using System.Collections.Generic;
using System.Text;

namespace wiimoteremote
{
    public class buttonmap
    {
        public string[] indexes;
        public string[] custom;
        
        public buttonmap()
        {
            indexes = new string[Form1.NUMBOXES];
            custom = new string[Form1.NUMBOXES];
        }
    }
}
