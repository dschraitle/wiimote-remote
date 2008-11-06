using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;//for firing keyboard and mouse events (optional)
using System.IO;//for saving the reading the calibration data
using WiimoteLib;
using Microsoft.Win32;
using System.Xml.Serialization;

namespace wiimoteremote
{
    public partial class Form1 : Form
    {
        Wiimote wm = new Wiimote();
        #region constants
        //declare consts for mouse messages
        public const int INPUT_MOUSE = 0;
        public const int INPUT_KEYBOARD = 1;
        public const int INPUT_HARDWARE = 2;

        public const int MOUSEEVENTF_MOVE = 0x01;
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        public const int MOUSEEVENTF_MIDDLEUP = 0x40;
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;


        public const int APPCOMMAND_VOLUME_MUTE = 524288;
        public const int APPCOMMAND_VOLUME_DOWN = 589824;
        public const int APPCOMMAND_VOLUME_UP = 655360;
        public const int APPCOMMAND_MEDIA_NEXTTRACK = 720896;
        public const int APPCOMMAND_MEDIA_PREVIOUSTRACK = 786432;
        public const int APPCOMMAND_MEDIA_STOP = 851968;
        public const int APPCOMMAND_MEDIA_PLAY_PAUSE = 917504;
        public const int APPCOMMAND_MEDIA_PLAY = 3014656;
        public const int APPCOMMAND_MEDIA_PAUSE = 3080192;
        public const int APPCOMMAND_BROWSER_BACKWARD = 65536;
        public const int APPCOMMAND_BROWSER_FORWARD = 131072;
        public const int APPCOMMAND_BROWSER_REFRESH = 196608;
        public const int WM_APPCOMMAND = 0x0319;
        public const int HWND_BROADCAST = 0xFFFF;
        //declare consts for key scan codes
        public const byte VK_LBUTTON = 0x01;
        public const byte VK_RBUTTON = 0x02;
        public const byte VK_CANCEL = 0x03;
        public const byte VK_MBUTTON = 0x04;
        public const byte VK_BACK = 0x08;
        public const byte VK_TAB = 0x09;
        public const byte VK_CLEAR = 0x0C;
        public const byte VK_RETURN = 0x0D;
        public const byte VK_SHIFT = 0x10;
        public const byte VK_CONTROL = 0x11;
        public const byte VK_MENU = 0x12;
        public const byte VK_PAUSE = 0x13;
        public const byte VK_CAPITAL = 0x14;
        public const byte VK_ESCAPE = 0x1B;
        public const byte VK_SPACE = 0x20;
        public const byte VK_PRIOR = 0x21;
        public const byte VK_NEXT = 0x22;
        public const byte VK_END = 0x23;
        public const byte VK_HOME = 0x24;
        public const byte VK_LEFT = 0x25;
        public const byte VK_UP = 0x26;
        public const byte VK_RIGHT = 0x27;
        public const byte VK_DOWN = 0x28;
        public const byte VK_SELECT = 0x29;
        public const byte VK_EXECUTE = 0x2B;
        public const byte VK_SNAPSHOT = 0x2C;
        public const byte VK_INS = 0x2D;
        public const byte VK_DELETE = 0x2E;
        public const byte VK_HELP = 0x2F;
        public const byte VK_LWIN = 0x5B;
        public const byte VK_RWIN = 0x5C;
        public const byte VK_APPS = 0x5D;

        public const int KEYEVENTF_EXTENDEDKEY = 0x01;
        public const int KEYEVENTF_KEYUP = 0x02;

        //for firing mouse and keyboard events
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam); 

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;//4
            public int dy;//4
            public uint mouseData;//4
            public uint dwFlags;//4
            public uint time;//4
            public IntPtr dwExtraInfo;//4
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort wVk;//2
            public ushort wScan;//2
            public uint dwFlags;//4
            public uint time;//4
            public IntPtr dwExtraInfo;//4
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        [StructLayout(LayoutKind.Explicit, Size = 28)]
        public struct INPUT
        {
            [FieldOffset(0)]
            public int type;
            [FieldOffset(4)] //*
            public MOUSEINPUT mi;
            [FieldOffset(4)] //*
            public KEYBDINPUT ki;
            [FieldOffset(4)] //*
            public HARDWAREINPUT hi;
        }
        //imports mouse_event function from user32.dll

        [DllImport("user32.dll")]
        private static extern void mouse_event(
        long dwFlags, // motion and click options
        long dx, // horizontal position or change
        long dy, // vertical position or change
        long dwData, // wheel movement
        long dwExtraInfo // application-defined information
        );

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int X, int Y);

        //imports keybd_event function from user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void keybd_event(byte bVk, byte bScan, long dwFlags, long dwExtraInfo);
        WiimoteState lastWiiState = new WiimoteState();//helps with event firing
        #endregion

        public const int NUMBOXES = 13; //number of editable boxes on form
        object[] items = new object[] { "", "Custom", "Ctrl", "Alt", "Shift", "Tab", "Enter", "Esc", "UpArrow", "DownArrow", "LeftArrow", "RightArrow", "Home", "End", "Delete", "PgDown", "PgUp", "Insert", "PrtScrn", "Backspace", "Space", "Click", "RightClick", "Copy", "Paste", "Play", "Pause", "Play/Pause", "Stop", "Prev Track", "Next Track", "Vol Up", "Vol Down", "Vol Mute", "KeyShift", "Slow", "MouseCtrl" };   //items in each combobox, order does not matter anymore
        bool[] done = new bool[NUMBOXES];   //helps shifting know when an action has occured
        ComboBox[] boxes;   //array containing all boxes
        bool start = true;  //signals start of program when all boxes are discombobulated, also comes in handy during other operations where box indexes change and you don't want the changeindex events happening
        bool mouse = false; //signals mouse control
        int speed;  //coefficient of axis for mouse control, higher = faster
        Mutex mut = new Mutex();    //helps synchronous execution
        int mouseclickd = MOUSEEVENTF_LEFTDOWN; //mouse click values for left clicking
        int mouseclicku = MOUSEEVENTF_LEFTUP;
        public buttonmap[] maps = new buttonmap[] { new buttonmap(), new buttonmap() }; //array which holds buttonmaps for regular and shift, more buttonmaps would go in here
        bool shifted = false;   //
        int currentmap = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < NUMBOXES; i++)
                done[i] = true;
            boxes = new ComboBox[] {boxa, boxb, boxup, boxdown, boxleft, boxright, boxhome, boxminus, boxplus, box1, box2, boxc, boxz};
            
            foreach (ComboBox b in boxes)
                b.Items.AddRange(items);

            buttonmap[] temp = new buttonmap[] { new buttonmap(), new buttonmap() };
            try
            {
                RegistryKey ourkey;
                ourkey = Registry.Users;
                ourkey = ourkey.OpenSubKey(@".DEFAULT\Software\Schraitle\Remote");
                temp = SerializeFromString<buttonmap[]>((string)ourkey.GetValue("maps"));
                tb1.Text = (string)ourkey.GetValue("custom");
                speedbox.Value = decimal.Parse((string)ourkey.GetValue("speed"));
                traycheck.Checked = bool.Parse((string)ourkey.GetValue("tray"));
            }
            catch (Exception x) { MessageBox.Show(x.ToString()); }

            if (temp[0].indexes.Length <= NUMBOXES) //in case future versions have different numbers of boxes, the serialized objects won't get indexoutofbounds errors
                replacemap(temp, temp[0].indexes.Length);
            else if (temp[0].indexes.Length >= NUMBOXES)
                replacemap(temp, NUMBOXES);
            else
                maps = temp;

            changestate();
            wm.WiimoteChanged += wm_WiimoteChanged;
            wm.WiimoteExtensionChanged += wm_ExtensionChanged;
            try
            {
                wm.Connect();
                wm.SetLEDs(true, false, false, false);
                if (wm.WiimoteState.ExtensionType.ToString() == "Nunchuk")
                {
                    wm.SetReportType(InputReport.ButtonsExtension, true);
                    mouse = true;
                }
                else
                    wm.SetReportType(InputReport.Buttons, true);
                connectbox.Text = "connected";
                connectbutton.Enabled = false;
            }
            catch (Exception x)
            {
                MessageBox.Show("Exception: " + x.Message);
                connectbox.Text = "not connected";
            }
            checkmouse.Checked = mouse;

            tray.Icon = this.Icon;
            start = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            regsave();
        }

        /// <summary>
        /// replaces map arrays up to given index
        /// </summary>
        /// <param name="temp">new map array</param>
        /// <param name="max">index to replace to</param>
        private void replacemap(buttonmap[] temp, int max)
        {
            for (int i = 0; i < max; i++)
            {
                maps[0].indexes[i] = temp[0].indexes[i];
                maps[1].indexes[i] = temp[1].indexes[i];
                maps[0].custom[i] = temp[0].custom[i];
                maps[1].custom[i] = temp[1].custom[i];
            }
        }

        /// <summary>
        /// saves button data to registry
        /// </summary>
        private void regsave()
        {
            RegistryKey ourkey = Registry.Users;
            ourkey = ourkey.CreateSubKey(@".DEFAULT\Software\Schraitle\Remote");
            ourkey.OpenSubKey(@".DEFAULT\Software\Schraitle\Remote", true);
            ourkey.SetValue("maps", SerializeToString(maps));
            //foreach (ComboBox box in boxes) ourkey.SetValue(box.Name, box.SelectedIndex);
            //for (int i = 0; i < NUMBOXES; i++) ourkey.SetValue(boxes[i].Name + "custom", custom[i]);
            ourkey.SetValue("custom", tb1.Text);
            ourkey.SetValue("speed", speedbox.Value);
            ourkey.SetValue("tray", traycheck.Checked);
            ourkey.Close();
        }

        /// <summary>
        /// serializes object into xml string
        /// </summary>
        /// <param name="obj">object to be serialized</param>
        /// <returns></returns>
        public static string SerializeToString(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }

        /// <summary>
        /// returns type T from serialized xml string
        /// </summary>
        /// <typeparam name="T">type to be returned</typeparam>
        /// <param name="xml">xml serialized string</param>
        /// <returns></returns>
        public static T SerializeFromString<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StringReader reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// when wiimote sends updated state information, this function is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs args)
        {
            mut.WaitOne();
            WiimoteState ws = args.WiimoteState;

            if (mouse)
            {
                double doublex = Math.Round(Convert.ToDouble(ws.NunchukState.Joystick.X * (int)speedbox.Value), 0);
                double doubley = Math.Round(Convert.ToDouble(ws.NunchukState.Joystick.Y * -1 * (int)speedbox.Value), 0);
                int X = int.Parse(doublex.ToString());
                int Y = int.Parse(doubley.ToString());
                if (ws.NunchukState.Joystick.Y < .012 && ws.NunchukState.Joystick.Y > -.012)
                    Y = 0;
                if (ws.NunchukState.Joystick.X < .012 && ws.NunchukState.Joystick.X > -.012)
                    X = 0;
                Cursor.Position = new System.Drawing.Point(Cursor.Position.X + X, Cursor.Position.Y + Y);

                if (shifted)
                {
                    if (ws.NunchukState.C && !done[11]) translate(maps[1].indexes[11], true, 11);
                    if (ws.NunchukState.Z && !done[12]) translate(maps[1].indexes[12], true, 12);
                    if (!ws.NunchukState.C && done[11]) translate(maps[1].indexes[11], false, 11);
                    if (!ws.NunchukState.Z && done[12]) translate(maps[1].indexes[12], false, 12);
                }


                if (!lastWiiState.NunchukState.C && ws.NunchukState.C && !shifted)
                    translate(maps[0].indexes[11], true, 11);
                if (lastWiiState.NunchukState.C && !ws.NunchukState.C)
                {
                    translate(maps[0].indexes[11], false, 11);
                }
                lastWiiState.NunchukState.C = ws.NunchukState.C;

                if (!lastWiiState.NunchukState.Z && ws.NunchukState.Z && !shifted)
                    translate(maps[0].indexes[12], true, 12);
                if (lastWiiState.NunchukState.Z && !ws.NunchukState.Z)
                {
                    translate(maps[0].indexes[12], false, 12);
                }
                lastWiiState.NunchukState.Z = ws.NunchukState.Z;
            }

            if (shifted)
            {
                if (ws.ButtonState.A && !done[0]) translate(maps[1].indexes[0], true, 0);
                if (ws.ButtonState.B && !done[1]) translate(maps[1].indexes[1], true, 1);
                if (ws.ButtonState.Up && !done[2]) translate(maps[1].indexes[2], true, 2);
                if (ws.ButtonState.Down && !done[3]) translate(maps[1].indexes[3], true, 3);
                if (ws.ButtonState.Left && !done[4]) translate(maps[1].indexes[4], true, 4);
                if (ws.ButtonState.Right && !done[5]) translate(maps[1].indexes[5], true, 5);
                if (ws.ButtonState.Home && !done[6]) translate(maps[1].indexes[6], true, 6);
                if (ws.ButtonState.Minus && !done[7]) translate(maps[1].indexes[7], true, 7);
                if (ws.ButtonState.Plus && !done[8]) translate(maps[1].indexes[8], true, 8);
                if (ws.ButtonState.One && !done[9]) translate(maps[1].indexes[9], true, 9);
                if (ws.ButtonState.Two && !done[10]) translate(maps[1].indexes[10], true, 10);
                if (!ws.ButtonState.A && done[0]) translate(maps[1].indexes[0], false, 0);
                if (!ws.ButtonState.B && done[1]) translate(maps[1].indexes[1], false, 1);
                if (!ws.ButtonState.Up && done[2]) translate(maps[1].indexes[2], false, 2);
                if (!ws.ButtonState.Down && done[3]) translate(maps[1].indexes[3], false, 3);
                if (!ws.ButtonState.Left && done[4]) translate(maps[1].indexes[4], false, 4);
                if (!ws.ButtonState.Right && done[5]) translate(maps[1].indexes[5], false, 5);
                if (!ws.ButtonState.Home && done[6]) translate(maps[1].indexes[6], false, 6);
                if (!ws.ButtonState.Minus && done[7]) translate(maps[1].indexes[7], false, 7);
                if (!ws.ButtonState.Plus && done[8]) translate(maps[1].indexes[8], false, 8);
                if (!ws.ButtonState.One && done[9]) translate(maps[1].indexes[9], false, 9);
                if (!ws.ButtonState.Two && done[10]) translate(maps[1].indexes[10], false, 10);
            }

            if (!lastWiiState.ButtonState.A && ws.ButtonState.A && !shifted)
                translate(maps[0].indexes[0], true, 0);
            if (lastWiiState.ButtonState.A && !ws.ButtonState.A)
                translate(maps[0].indexes[0], false, 0);
            lastWiiState.ButtonState.A = ws.ButtonState.A;

            if (!lastWiiState.ButtonState.B && ws.ButtonState.B && !shifted)
                translate(maps[0].indexes[1], true, 1);
            if (lastWiiState.ButtonState.B && !ws.ButtonState.B)
                translate(maps[0].indexes[1], false, 1);
            lastWiiState.ButtonState.B = ws.ButtonState.B;

            if (!lastWiiState.ButtonState.Up && ws.ButtonState.Up && !shifted)
                translate(maps[0].indexes[2], true, 2);
            if (lastWiiState.ButtonState.Up && !ws.ButtonState.Up)
                translate(maps[0].indexes[2], false, 2);
            lastWiiState.ButtonState.Up = ws.ButtonState.Up;

            if (!lastWiiState.ButtonState.Down && ws.ButtonState.Down && !shifted)
                translate(maps[0].indexes[3], true, 3);
            if (lastWiiState.ButtonState.Down && !ws.ButtonState.Down)
                translate(maps[0].indexes[3], false, 3);
            lastWiiState.ButtonState.Down = ws.ButtonState.Down;

            if (!lastWiiState.ButtonState.Left && ws.ButtonState.Left && !shifted)
                translate(maps[0].indexes[4], true, 4);
            if (lastWiiState.ButtonState.Left && !ws.ButtonState.Left)
                translate(maps[0].indexes[4], false, 4);
            lastWiiState.ButtonState.Left = ws.ButtonState.Left;

            if (!lastWiiState.ButtonState.Right && ws.ButtonState.Right && !shifted)
                translate(maps[0].indexes[5], true, 5);
            if (lastWiiState.ButtonState.Right && !ws.ButtonState.Right)
                translate(maps[0].indexes[5], false, 5);
            lastWiiState.ButtonState.Right = ws.ButtonState.Right;

            if (!lastWiiState.ButtonState.Home && ws.ButtonState.Home && !shifted)
                translate(maps[0].indexes[6], true, 6);
            if (lastWiiState.ButtonState.Home && !ws.ButtonState.Home)
                translate(maps[0].indexes[6], false, 6);
            lastWiiState.ButtonState.Home = ws.ButtonState.Home;

            if (!lastWiiState.ButtonState.Minus && ws.ButtonState.Minus && !shifted)
                translate(maps[0].indexes[7], true, 7);
            if (lastWiiState.ButtonState.Minus && !ws.ButtonState.Minus)
                translate(maps[0].indexes[7], false, 7);
            lastWiiState.ButtonState.Minus = ws.ButtonState.Minus;

            if (!lastWiiState.ButtonState.Plus && ws.ButtonState.Plus && !shifted)
                translate(maps[0].indexes[8], true, 8);
            if (lastWiiState.ButtonState.Plus && !ws.ButtonState.Plus)
                translate(maps[0].indexes[8], false, 8);
            lastWiiState.ButtonState.Plus = ws.ButtonState.Plus;

            if (!lastWiiState.ButtonState.One && ws.ButtonState.One && !shifted)
                translate(maps[0].indexes[9], true, 9);
            if (lastWiiState.ButtonState.One && !ws.ButtonState.One)
                translate(maps[0].indexes[9], false, 9);
            lastWiiState.ButtonState.One = ws.ButtonState.One;

            if (!lastWiiState.ButtonState.Two && ws.ButtonState.Two && !shifted)
                translate(maps[0].indexes[10], true, 10);
            if (lastWiiState.ButtonState.Two && !ws.ButtonState.Two)
                translate(maps[0].indexes[10], false, 10);
            lastWiiState.ButtonState.Two = ws.ButtonState.Two;

            //(ws.Battery > 0x64 ? 0x64 : (int)ws.Battery); });
            float f = (((100.0f * 48.0f * (float)(ws.Battery / 48.0f))) / 192.0f);
            BeginInvoke((MethodInvoker)delegate() { lblBattery.Text = f.ToString("F"); });
            BeginInvoke((MethodInvoker)delegate() { pbBattery.Value = (int)f; });

            mut.ReleaseMutex(); 
        }

        /// <summary>
        /// when extension is plugged in or unplugged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void wm_ExtensionChanged(object sender, WiimoteExtensionChangedEventArgs args)
        {
            //if extension attached, enable it
            if (args.Inserted)
            {
                if (wm.WiimoteState.ExtensionType.ToString() == "Nunchuk")
                {
                    mouse = true;
                    wm.SetReportType(InputReport.ButtonsExtension, true);
                }
            }
            else
            {
                wm.SetReportType(InputReport.Buttons, true);
                mouse = false;
            }
            start = true;
            checkmouse.Checked = mouse;
            start = false;
            label1.Text = wm.WiimoteState.ExtensionType.ToString();
        }

        /// <summary>
        /// translates index of boxes into appropriate function
        /// </summary>
        /// <param name="i">selected item of corresponding combobox</param>
        /// <param name="down">button pressed down</param>
        /// <param name="button">index of box in boxes array</param>
        void translate(string i, bool down, int button)
        {
            if (i == "Ctrl") {   //Ctrl
                if (down) { keybd_event(VK_CONTROL, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_CONTROL, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "Alt"){    //Alt
                if (down){ keybd_event(VK_MENU, 0x45, 0, 0);done[button] = true;}
                else {keybd_event(VK_MENU, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "Shift"){    //Shift
                if (down) {keybd_event(VK_SHIFT, 0x45, 0, 0);done[button] = true;}
                else {keybd_event(VK_SHIFT, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "Tab"){    //Tab
                if (down){ keybd_event(VK_TAB, 0x45, 0, 0);done[button] = true;}
                else{ keybd_event(VK_TAB, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "Enter"){    //Enter
                if (down){ keybd_event(VK_RETURN, 0x45, 0, 0);done[button] = true;}
                else {keybd_event(VK_RETURN, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "Esc"){    //Esc
                if (down) {keybd_event(VK_ESCAPE, 0x45, 0, 0);done[button] = true;}
                else {keybd_event(VK_ESCAPE, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "UpArrow"){    //Uparrow
                if (down){ keybd_event(VK_UP, 0x45, 0, 0);done[button] = true;}
                else {keybd_event(VK_UP, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "DownArrow"){    //downarrow
                if (down){ keybd_event(VK_DOWN, 0x45, 0, 0);done[button] = true;}
                else {keybd_event(VK_DOWN, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "LeftArrow"){    //leftarrow
                if (down){ keybd_event(VK_LEFT, 0x45, 0, 0);done[button] = true;}
                else {keybd_event(VK_LEFT, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "RightArrow"){    //rightarrow
                if (down){ keybd_event(VK_RIGHT, 0x45, 0, 0);done[button] = true;}
                else {keybd_event(VK_RIGHT, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "Home"){   //home
                if (down){ keybd_event(VK_HOME, 0x45, 0, 0);done[button] = true;}
                else {keybd_event(VK_HOME, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "End"){   //end
                if (down){ keybd_event(VK_END, 0x45, 0, 0);done[button] = true;}
                else {keybd_event(VK_END, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "Delete"){   //delete
                if (down){ keybd_event(VK_DELETE, 0x45, 0, 0);done[button] = true;}
                else {keybd_event(VK_DELETE, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "PgDown"){   //pgdown
                if (down){ keybd_event(VK_NEXT, 0x45, 0, 0);done[button] = true;}
                else {keybd_event(VK_NEXT, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "PgUp"){   //pgup
                if (down){ keybd_event(VK_PRIOR, 0x45, 0, 0);done[button] = true;}
                else {keybd_event(VK_PRIOR, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "Insert"){   //insert
                if (down){ keybd_event(VK_INS, 0x45, 0, 0);done[button] = true;}
                else {keybd_event(VK_INS, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "PrtScrn"){   //printscreen
                if (down){ keybd_event(VK_SNAPSHOT, 0x45, 0, 0);done[button] = true;}
                else {keybd_event(VK_SNAPSHOT, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "Backspace"){   //backspace
                if (down){ keybd_event(VK_BACK, 0x45, 0, 0);done[button] = true;}
                else {keybd_event(VK_BACK, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "Space"){   //space
                if (down){ keybd_event(VK_SPACE, 0x45, 0, 0);done[button] = true;}
                else {keybd_event(VK_SPACE, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }}
            if (i == "Click"){   //click
                if (down) { mouse_event(MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0); done[button] = true; }
                else { mouse_event(MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0); done[button] = false; }
            }
            if (i == "RightClick"){   //right click
                if (down) { mouse_event(MOUSEEVENTF_RIGHTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0); done[button] = true; }
                else { mouse_event(MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0); done[button] = false; }
            }
            if (i == "Copy"){   //copy
                if (down){
                    keybd_event(VK_CONTROL, 0x45, 0, 0);
                    keybd_event(0x43, 0x45, 0, 0);
                    done[button] = true;}//control + c
                else{
                    keybd_event(VK_CONTROL, 0x45, KEYEVENTF_KEYUP, 0);
                    keybd_event(0x43, 0x45, KEYEVENTF_KEYUP, 0);
                    done[button] = false;}}
            if (i == "Paste"){   //paste
                if (down){
                    keybd_event(VK_CONTROL, 0x45, 0, 0);
                    keybd_event(0x56, 0x45, 0, 0);
                    done[button] = true;}//control + v
                else{
                    keybd_event(VK_CONTROL, 0x45, KEYEVENTF_KEYUP, 0);
                    keybd_event(0x56, 0x45, KEYEVENTF_KEYUP, 0);
                    done[button] = false;}}
            if (i == "Custom")    //custom
            {   
                if (down)
                {
                    if (shifted)
                        SendKeys.SendWait(maps[1].custom[button]);
                    else
                        SendKeys.SendWait(maps[0].custom[button]);
                    done[button] = true;
                }
                else{done[button] = false;}
            }
            if (i == "Play") if (down) {SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_PLAY)); done[button] = true;}else{done[button] = false;}
            if (i == "Pause") if (down) { SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_PAUSE)); done[button] = true; } else { done[button] = false; }
            if (i == "Play/Pause") if (down) { SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_PLAY_PAUSE)); done[button] = true; } else { done[button] = false; }
            if (i == "Stop") if (down) { SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_STOP)); done[button] = true; } else { done[button] = false; }
            if (i == "Prev Track") if (down) { SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_PREVIOUSTRACK)); done[button] = true; } else { done[button] = false; }
            if (i == "Next Track") if (down) { SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_NEXTTRACK)); done[button] = true; } else { done[button] = false; }
            if (i == "Vol Up") if (down) { SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_VOLUME_UP)); done[button] = true; } else { done[button] = false; }
            if (i == "Vol Down") if (down) { SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_VOLUME_DOWN)); done[button] = true; } else { done[button] = false; }
            if (i == "Vol Mute") if (down) { SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_VOLUME_MUTE)); done[button] = true; } else { done[button] = false; }
            if (i == "KeyShift") if (down) { shifted = true; done[button] = true; } else { shifted = false; done[button] = false; }   //keyshift
            if (i == "Slow")
            {   //speed slow down
                if (down){
                    speed = (int)speedbox.Value;
                    speedbox.Value = speedbox.Value / 3;
                    done[button] = true;}
                else
                    speedbox.Value = speed;
                    done[button] = false;}
            if (i == "MouseCtrl") if (down) {checkmouse.Checked = !checkmouse.Checked;  done[button] = true;}else{done[button] = false;}


            done[button] = down;
        }

        /// <summary>
        /// connects wiimote (buggy)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectbutton_Click(object sender, EventArgs e)
        {
            try
            {
                wm.Connect();
                wm.SetLEDs(true, false, false, false);
                wm.SetReportType(InputReport.Buttons, true);
                connectbox.Text = "connected";
                connectbutton.Enabled = false;
            }
            catch (Exception x)
            {
                MessageBox.Show("Exception: " + x.Message);
                connectbox.Text = "not connected";
            }


        }

        /// <summary>
        /// saves button configurations to a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog svfl = new SaveFileDialog();
            svfl.Filter = "Special Files (*.sch)|*.sch";
            if (svfl.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer s = new XmlSerializer(typeof(buttonmap[]));
                TextWriter w = new StreamWriter(svfl.FileName);
                s.Serialize(w, maps);
                w.Close();
            }
        }

        /// <summary>
        /// load button mappings file into program
        /// file must be an xml serialized file created from save function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void load_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opfl = new OpenFileDialog();
                opfl.Filter = "Special Files (*.sch)|*.sch";
                if (opfl.ShowDialog() == DialogResult.OK)
                {
                    TextReader r = new StreamReader(opfl.FileName);
                    XmlSerializer s = new XmlSerializer(typeof(buttonmap[]));
                    maps = (buttonmap[])s.Deserialize(r);
                    r.Close();
                    currentmap = 0;
                    changestate();
                }
            }
            catch (Exception x) { x.ToString(); }
        }

        /// <summary>
        /// sets the values of mouse down and up for when mouse clicks occur, such as changing to right click and back
        /// </summary>
        /// <param name="down">value of mouse down</param>
        /// <param name="up">value of mouse up</param>
        void setclick(int down, int up)
        {
            mouseclickd = down;
            mouseclicku = up;
        }
        
        ///<summary>
        ///every box does this function when it changes, for item specific things. 
        ///</summary>
        ///<param name="box">the combobox being changed</param>
        ///<param name="i">the index of the box in the boxes array</param>
        void customize(ComboBox box, int i) 
        {
            if (currentmap == 1 && (string)box.SelectedItem == "KeyShift")  //check to make sure shift isn't used in shifted state
            {
                box.SelectedItem = maps[currentmap].indexes[i];
                return;
            }
            if (box.SelectedIndex == 1 && maps[currentmap].indexes[i] != "Custom" && !start)
            {
                start = true;
                box.Items.RemoveAt(1);
                box.Items.Insert(1, tb1.Text);
                maps[currentmap].custom[i] = tb1.Text;
                maps[currentmap].indexes[i] = "Custom";
                box.SelectedItem = tb1.Text;
                start = false;
            }
            else if (box.SelectedIndex != 1 && maps[currentmap].indexes[i] == "Custom")
            {
                box.Items.RemoveAt(1);
                box.Items.Insert(1, "Custom");
                maps[currentmap].indexes[i] = (string)box.SelectedItem;
            }
            else if (!start)
                maps[currentmap].indexes[i] = (string)box.SelectedItem;
        }

        #region events
        private void boxa_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxa, 0);
        }

        private void boxb_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxb, 1);
        }

        private void boxup_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxup, 2);
        }

        private void boxdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxdown, 3);
        }

        private void boxleft_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxleft, 4);
        }

        private void boxright_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxright, 5);
        }

        private void boxhome_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxhome, 6);
        }

        private void boxminus_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxminus, 7);
        }

        private void boxplus_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxplus, 8);
        }

        private void box1_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(box1, 9);
        }

        private void box2_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(box2, 10);
        }

        private void boxc_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxc, 11);
        }

        private void boxz_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxz, 12);
        }
        #endregion

        private void checkmouse_CheckedChanged(object sender, EventArgs e)
        {
            if(!start)
            mouse = !mouse;
        }

        /// <summary>
        /// changes boxes to reflect a shifted state or not, or if button maps have been edited
        /// </summary>
        private void changestate()
        {
            start = true;
            for (int i = 0; i < NUMBOXES; i++)
            {
                if (!boxes[i].Enabled)
                    boxes[i].Enabled = true;
                if (currentmap == 1 && maps[0].indexes[i] == "KeyShift")
                    boxes[i].Enabled = false;
                boxes[i].Items.RemoveAt(1);
                if (maps[currentmap].indexes[i] == "Custom")
                {
                    boxes[i].Items.Insert(1, maps[currentmap].custom[i]);
                    boxes[i].SelectedIndex = 1;
                }
                else
                {
                    boxes[i].Items.Insert(1, "Custom");
                    boxes[i].SelectedItem = maps[currentmap].indexes[i];
                }
            }
            start = false;
        }

        private void shiftbutton_Click(object sender, EventArgs e)
        {
            
            if (currentmap == 0)
            {
                currentmap = 1;
                shiftlabel.Text = "Shifted";
            }
            else
            {
                currentmap = 0;
                shiftlabel.Text = "Regular";
            }
            changestate();
        }

        void tray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            tray.Visible = false;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized && traycheck.Checked)
            {
                tray.Visible = true;
                this.Hide();
            }
        }

        private void gomPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maps[0].indexes = new string[] {"Play/Pause", "KeyShift", "UpArrow", "DownArrow", "LeftArrow", "RightArrow", "Enter", "Prev Track", "Next Track", "Custom", "Custom", "Slow", "Click", };
            maps[0].custom = new string[] { "", "", "", "", "", "", "", "", "", "!<", "!>", "", "" };
            maps[1].indexes = new string[] { "", "", "Custom", "Custom", "Custom", "Custom", "MouseCtrl", "", "", "", "", "", "RightClick" };
            maps[1].custom = new string[] { "", "", "^{up}", "^{down}", "^{left}", "^{right}", "", "", "", "", "", "", "" };
            currentmap = 0;
            changestate();
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maps[0].indexes = new string[] { "", "KeyShift", "UpArrow", "DownArrow", "LeftArrow", "RightArrow", "Enter", "Copy", "Paste", "", "", "Slow", "Click", };
            maps[0].custom = new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "" };
            maps[1].indexes = new string[] { "", "", "", "", "", "", "MouseCtrl", "", "", "", "", "", "RightClick" };
            maps[1].custom = new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "" };
            currentmap = 0;
            changestate();
        }
    }
}