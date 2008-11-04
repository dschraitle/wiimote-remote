using System;
using System.Collections.Generic;
using System.Text;

namespace wiimoteremote
{
    public class buttonmap
    {
        public int[] indexes;
        public int[] prevselindex;
        public string[] custom;
        
        public buttonmap()
        {
            indexes = new int[Form1.NUMBOXES];
            custom = new string[Form1.NUMBOXES];
            prevselindex = new int[Form1.NUMBOXES];
            
        }
    }
}
