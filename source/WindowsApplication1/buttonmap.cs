using System;
using System.Collections.Generic;
using System.Text;

namespace wiimoteremote
{
    public class buttonmap
    {
        /// <summary>
        /// stores the item names of the comboboxes
        /// </summary>
        public string[] indexes;
        /// <summary>
        /// stores the custom strings for the item boxes
        /// </summary>
        public string[] custom;
		
		public int[] repeat;
        
        public buttonmap()
        {
            indexes = new string[Form1.NUMBOXES];
            custom = new string[Form1.NUMBOXES];
			repeat = new int[Form1.NUMBOXES];
			for(int i = 0; i < repeat.Length; i++)
				repeat[i] = 0;
        }
    }
}
