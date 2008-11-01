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


/*
 * things to add:
 * motion sensor data
 * serialized saving/loading functions
 */

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
        public const byte VK_NUMPAD0 = 0x60;
        public const byte VK_NUMPAD1 = 0x61;
        public const byte VK_NUMPAD2 = 0x62;
        public const byte VK_NUMPAD3 = 0x63;
        public const byte VK_NUMPAD4 = 0x64;
        public const byte VK_NUMPAD5 = 0x65;
        public const byte VK_NUMPAD6 = 0x66;
        public const byte VK_NUMPAD7 = 0x67;
        public const byte VK_NUMPAD8 = 0x68;
        public const byte VK_NUMPAD9 = 0x69;
        public const byte VK_MULTIPLY = 0x6A;
        public const byte VK_ADD = 0x6B;
        public const byte VK_SEPARATOR = 0x6C;
        public const byte VK_SUBTRACT = 0x6D;
        public const byte VK_DECIMAL = 0x6E;
        public const byte VK_DIVIDE = 0x6F;
        public const byte VK_F1 = 0x70;
        public const byte VK_F2 = 0x71;
        public const byte VK_F3 = 0x72;
        public const byte VK_F4 = 0x73;
        public const byte VK_F5 = 0x74;
        public const byte VK_F6 = 0x75;
        public const byte VK_F7 = 0x76;
        public const byte VK_F8 = 0x77;
        public const byte VK_F9 = 0x78;
        public const byte VK_F10 = 0x79;
        public const byte VK_F11 = 0x7A;
        public const byte VK_F12 = 0x7B;
        public const byte VK_F13 = 0x7C;
        public const byte VK_F14 = 0x7D;
        public const byte VK_F15 = 0x7E;
        public const byte VK_F16 = 0x7F;
        public const byte VK_F17 = 0x80;
        public const byte VK_F18 = 0x81;
        public const byte VK_F19 = 0x82;
        public const byte VK_F20 = 0x83;
        public const byte VK_F21 = 0x84;
        public const byte VK_F22 = 0x85;
        public const byte VK_F23 = 0x86;
        public const byte VK_F24 = 0x87;
        public const byte VK_NUMLOCK = 0x90;
        public const byte VK_SCROLL = 0x91;
        public const byte VK_LSHIFT = 0xA0;
        public const byte VK_RSHIFT = 0xA1;
        public const byte VK_LCONTROL = 0xA2;
        public const byte VK_RCONTROL = 0xA3;
        public const byte VK_LMENU = 0xA4;
        public const byte VK_RMENU = 0xA5;
        public const byte VK_0 = 0x30;
        public const byte VK_1 = 0x31;
        public const byte VK_2 = 0x32;
        public const byte VK_3 = 0x33;
        public const byte VK_4 = 0x34;
        public const byte VK_5 = 0x35;
        public const byte VK_6 = 0x36;
        public const byte VK_7 = 0x37;
        public const byte VK_8 = 0x38;
        public const byte VK_9 = 0x39;
        public const byte VK_A = 0x41;
        public const byte VK_B = 0x42;
        public const byte VK_C = 0x43;
        public const byte VK_D = 0x44;
        public const byte VK_E = 0x45;
        public const byte VK_F = 0x46;
        public const byte VK_G = 0x47;
        public const byte VK_H = 0x48;
        public const byte VK_I = 0x49;
        public const byte VK_J = 0x4A;
        public const byte VK_K = 0x4B;
        public const byte VK_L = 0x4C;
        public const byte VK_M = 0x4D;
        public const byte VK_N = 0x4E;
        public const byte VK_O = 0x4F;
        public const byte VK_P = 0x50;
        public const byte VK_Q = 0x51;
        public const byte VK_R = 0x52;
        public const byte VK_S = 0x53;
        public const byte VK_T = 0x54;
        public const byte VK_U = 0x55;
        public const byte VK_V = 0x56;
        public const byte VK_W = 0x57;
        public const byte VK_X = 0x58;
        public const byte VK_Y = 0x59;
        public const byte VK_Z = 0x5A;

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

        const int NUMBOXES = 11;
        object[] items = new object[] { "Ctrl", "Alt", "Shift", "Tab", "Enter", "Esc", "UpArrow", "DownArrow", "LeftArrow", "RightArrow", "Home", "End", "Delete", "PgDown", "PgUp", "Insert", "PrtScrn", "Backspace", "Space", "LeftClick", "RightClick", "Copy", "Paste", "Custom", "Play", "Pause", "Play/Pause", "Stop", "Prev Track", "Next Track", "Vol Up", "Vol Down", "Vol Mute"};
        string[] custom = new string[] { "", "", "", "", "", "", "", "", "", "", "", "" };
        int[] prevselindex;
        ComboBox[] boxes;
        bool start = true;
        bool nunchuk = false;
        bool mouse = false;
        int speed;
        Mutex mut = new Mutex();
        int mouseclickd = MOUSEEVENTF_LEFTDOWN;
        int mouseclicku = MOUSEEVENTF_LEFTUP;
        byte[] zaccel = new byte[20];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tb1.Text = custom[1];
            boxes = new ComboBox[] {boxb, boxa, boxup, boxdown, boxleft, boxright, boxhome, boxminus, boxplus, box1, box2};
            prevselindex = new int[NUMBOXES+1];

            foreach (ComboBox b in boxes)
                b.Items.AddRange(items);

            int[] saveo = new int[11] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            try
            {
                RegistryKey ourkey;
                ourkey = Registry.Users;
                ourkey = ourkey.OpenSubKey(@".DEFAULT\Software\Schraitle\Remote");
                for (int i = 0; i <= NUMBOXES-1; i++) saveo[i] = (int)ourkey.GetValue(boxes[i].Name);  
                for (int i = 0; i <= NUMBOXES-1; i++) custom[i] = (string)ourkey.GetValue(boxes[i].Name+"custom");
                tb1.Text = (string)ourkey.GetValue("custom");
                for (int i = 0; i < NUMBOXES-1; i++)
                    if (saveo[i] == 23){
                        boxes[i].Items.RemoveAt(23);
                        boxes[i].Items.Insert(23, custom[i]);
                        boxes[i].SelectedItem = custom[i];}
                start = false;
            }
            catch (Exception x) { x.ToString(); }

            for (int i = 0; i <= NUMBOXES-1; i++) boxes[i].SelectedIndex = saveo[i];

            wm.WiimoteChanged += wm_WiimoteChanged;
            wm.WiimoteExtensionChanged += wm_ExtensionChanged;
            try
            {
                wm.Connect();
                wm.SetLEDs(true, false, false, false);
                if (wm.WiimoteState.ExtensionType.ToString() == "Nunchuk")
                {

                    wm.SetReportType(InputReport.ButtonsExtension, true);
                    nunchuk = true;
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
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            for (int i = 1; i < custom.Length; i++ )
                if (custom[i] == null) custom[i] = "";
            RegistryKey ourkey = Registry.Users;
            ourkey = ourkey.CreateSubKey(@".DEFAULT\Software\Schraitle\Remote");
            ourkey.OpenSubKey(@".DEFAULT\Software\Schraitle\Remote", true);
            foreach (ComboBox box in boxes) ourkey.SetValue(box.Name, box.SelectedIndex);
            for (int i = 0; i < NUMBOXES; i++) ourkey.SetValue(boxes[i].Name + "custom", custom[i]);
            ourkey.SetValue("custom", tb1.Text);
            ourkey.Close();
        }

        void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs args)
        {
            mut.WaitOne();
            WiimoteState ws = args.WiimoteState;

            if (mouse)
            {
                //for (int i = ACCELDATA - 2; i >= 0; i--)
                //{
                //    zaccel[i + 1] = zaccel[i];
                //}
                double doublex = Math.Round(Convert.ToDouble(ws.NunchukState.Joystick.X * (int)speedbox.Value), 0);
                double doubley = Math.Round(Convert.ToDouble(ws.NunchukState.Joystick.Y * -1 * (int)speedbox.Value), 0);
                int X = int.Parse(doublex.ToString());
                int Y = int.Parse(doubley.ToString());
                Cursor.Position = new System.Drawing.Point(Cursor.Position.X + X, Cursor.Position.Y + Y);

                if (!lastWiiState.NunchukState.Z && ws.NunchukState.Z)
                    mouse_event(mouseclickd, X, Y, 0, 0);
                if (lastWiiState.NunchukState.Z && !ws.NunchukState.Z)
                    mouse_event(mouseclicku, X, Y, 0, 0);
                lastWiiState.NunchukState.Z = ws.NunchukState.Z;

                if (!lastWiiState.NunchukState.C && ws.NunchukState.C)
                {
                    speed = (int)speedbox.Value;
                    speedbox.Value = speedbox.Value / 3;
                }
                if (lastWiiState.NunchukState.C && !ws.NunchukState.C)
                    speedbox.Value = speed;
                lastWiiState.NunchukState.C = ws.NunchukState.C;
            }

            if (!lastWiiState.ButtonState.A && ws.ButtonState.A)
                translate(boxa.SelectedIndex, true, 1);
            if (lastWiiState.ButtonState.A && !ws.ButtonState.A)
                translate(boxa.SelectedIndex, false, 1);
            lastWiiState.ButtonState.A = ws.ButtonState.A;

            if (!lastWiiState.ButtonState.B && ws.ButtonState.B)
                translate(boxb.SelectedIndex, true, 2);
            if (lastWiiState.ButtonState.B && !ws.ButtonState.B)
                translate(boxb.SelectedIndex, false, 2);
            lastWiiState.ButtonState.B = ws.ButtonState.B;

            if (!lastWiiState.ButtonState.Up && ws.ButtonState.Up)
                translate(boxup.SelectedIndex, true, 3);
            if (lastWiiState.ButtonState.Up && !ws.ButtonState.Up)
                translate(boxup.SelectedIndex, false, 3);
            lastWiiState.ButtonState.Up = ws.ButtonState.Up;

            if (!lastWiiState.ButtonState.Down && ws.ButtonState.Down)
                translate(boxdown.SelectedIndex, true, 4);
            if (lastWiiState.ButtonState.Down && !ws.ButtonState.Down)
                translate(boxdown.SelectedIndex, false, 4);
            lastWiiState.ButtonState.Down = ws.ButtonState.Down;

            if (!lastWiiState.ButtonState.Left && ws.ButtonState.Left)
                translate(boxleft.SelectedIndex, true, 5);
            if (lastWiiState.ButtonState.Left && !ws.ButtonState.Left)
                translate(boxleft.SelectedIndex, false, 5);
            lastWiiState.ButtonState.Left = ws.ButtonState.Left;

            if (!lastWiiState.ButtonState.Right && ws.ButtonState.Right)
                translate(boxright.SelectedIndex, true, 6);
            if (lastWiiState.ButtonState.Right && !ws.ButtonState.Right)
                translate(boxright.SelectedIndex, false, 6);
            lastWiiState.ButtonState.Right = ws.ButtonState.Right;

            if (!lastWiiState.ButtonState.Home && ws.ButtonState.Home)
                translate(boxhome.SelectedIndex, true, 7);
            if (lastWiiState.ButtonState.Home && !ws.ButtonState.Home)
                translate(boxhome.SelectedIndex, false, 7);
            lastWiiState.ButtonState.Home = ws.ButtonState.Home;

            if (!lastWiiState.ButtonState.Minus && ws.ButtonState.Minus)
                translate(boxminus.SelectedIndex, true, 8);
            if (lastWiiState.ButtonState.Minus && !ws.ButtonState.Minus)
                translate(boxminus.SelectedIndex, false, 8);
            lastWiiState.ButtonState.Minus = ws.ButtonState.Minus;

            if (!lastWiiState.ButtonState.Plus && ws.ButtonState.Plus)
                translate(boxplus.SelectedIndex, true, 9);
            if (lastWiiState.ButtonState.Plus && !ws.ButtonState.Plus)
                translate(boxplus.SelectedIndex, false, 9);
            lastWiiState.ButtonState.Plus = ws.ButtonState.Plus;

            if (!lastWiiState.ButtonState.One && ws.ButtonState.One)
                translate(box1.SelectedIndex, true, 10);
            if (lastWiiState.ButtonState.One && !ws.ButtonState.One)
                translate(box1.SelectedIndex, false, 10);
            lastWiiState.ButtonState.One = ws.ButtonState.One;

            if (!lastWiiState.ButtonState.Two && ws.ButtonState.Two)
                translate(box2.SelectedIndex, true, 11);
            if (lastWiiState.ButtonState.Two && !ws.ButtonState.Two)
                translate(box2.SelectedIndex, false, 11);
            lastWiiState.ButtonState.Two = ws.ButtonState.Two;

            //(ws.Battery > 0x64 ? 0x64 : (int)ws.Battery); });
            float f = (((100.0f * 48.0f * (float)(ws.Battery / 48.0f))) / 192.0f);
            BeginInvoke((MethodInvoker)delegate() { lblBattery.Text = f.ToString("F"); });
            BeginInvoke((MethodInvoker)delegate() { pbBattery.Value = (int)f; });

            mut.ReleaseMutex(); 
        }

        void wm_ExtensionChanged(object sender, WiimoteExtensionChangedEventArgs args)
        {
            //if extension attached, enable it
            if (args.Inserted)
                wm.SetReportType(InputReport.ButtonsExtension, true);
            else
            {
                wm.SetReportType(InputReport.Buttons, true);
                nunchuk = false;
            }
            if (wm.WiimoteState.ExtensionType.ToString() == "Nunchuk")
            {
                nunchuk = true;
                mouse = true;
            }
            label1.Text = wm.WiimoteState.ExtensionType.ToString();
        }

        void translate(int i, bool down, int button)
        {
            if (i == 0) {
                if (down) keybd_event(VK_CONTROL, 0x45, 0, 0);
                else keybd_event(VK_CONTROL, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 1){
                if (down) keybd_event(VK_MENU, 0x45, 0, 0);
                else keybd_event(VK_MENU, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 2){
                if (down) keybd_event(VK_SHIFT, 0x45, 0, 0);
                else keybd_event(VK_SHIFT, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 3){
                if (down) keybd_event(VK_TAB, 0x45, 0, 0);
                else keybd_event(VK_TAB, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 4){
                if (down) keybd_event(VK_RETURN, 0x45, 0, 0);
                else keybd_event(VK_RETURN, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 5){
                if (down) keybd_event(VK_ESCAPE, 0x45, 0, 0);
                else keybd_event(VK_ESCAPE, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 6){
                if (down) keybd_event(VK_UP, 0x45, 0, 0);
                else keybd_event(VK_UP, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 7){
                if (down) keybd_event(VK_DOWN, 0x45, 0, 0);
                else keybd_event(VK_DOWN, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 8){
                if (down) keybd_event(VK_LEFT, 0x45, 0, 0);
                else keybd_event(VK_LEFT, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 9){
                if (down) keybd_event(VK_RIGHT, 0x45, 0, 0);
                else keybd_event(VK_RIGHT, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 10){
                if (down) keybd_event(VK_HOME, 0x45, 0, 0);
                else keybd_event(VK_HOME, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 11){
                if (down) keybd_event(VK_END, 0x45, 0, 0);
                else keybd_event(VK_END, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 12){
                if (down) keybd_event(VK_DELETE, 0x45, 0, 0);
                else keybd_event(VK_DELETE, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 13){
                if (down) keybd_event(VK_NEXT, 0x45, 0, 0);
                else keybd_event(VK_NEXT, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 14){
                if (down) keybd_event(VK_PRIOR, 0x45, 0, 0);
                else keybd_event(VK_PRIOR, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 15){
                if (down) keybd_event(VK_INS, 0x45, 0, 0);
                else keybd_event(VK_INS, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 16){
                if (down) keybd_event(VK_SNAPSHOT, 0x45, 0, 0);
                else keybd_event(VK_SNAPSHOT, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 17){
                if (down) keybd_event(VK_BACK, 0x45, 0, 0);
                else keybd_event(VK_BACK, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 18){
                if (down) keybd_event(VK_SPACE, 0x45, 0, 0);
                else keybd_event(VK_SPACE, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 19){
                if (down) keybd_event(VK_LBUTTON, 0x45, 0, 0);
                else keybd_event(VK_LBUTTON, 0x45, KEYEVENTF_KEYUP, 0);}
            if (i == 20){
                if (down) setclick(MOUSEEVENTF_RIGHTDOWN, MOUSEEVENTF_RIGHTUP);
                else setclick(MOUSEEVENTF_LEFTDOWN, MOUSEEVENTF_LEFTUP);
            }
            if (i == 21){
                if (down){
                    keybd_event(VK_CONTROL, 0x45, 0, 0);
                    keybd_event(0x43, 0x45, 0, 0);}//control + c
                else{
                    keybd_event(VK_CONTROL, 0x45, KEYEVENTF_KEYUP, 0);
                    keybd_event(0x43, 0x45, KEYEVENTF_KEYUP, 0);}}
            if (i == 22){
                if (down){
                    keybd_event(VK_CONTROL, 0x45, 0, 0);
                    keybd_event(0x56, 0x45, 0, 0);}//control + v
                else{
                    keybd_event(VK_CONTROL, 0x45, KEYEVENTF_KEYUP, 0);
                    keybd_event(0x56, 0x45, KEYEVENTF_KEYUP, 0);}}
            if (i == 23){
                if (down){
                    SendKeys.SendWait(custom[button]);}}
            if (i == 24) if (down) SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_PLAY));
            if (i == 25) if (down) SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_PAUSE));
            if (i == 26) if (down) SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_PLAY_PAUSE));
            if (i == 27) if (down) SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_STOP));
            if (i == 28) if (down) SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_PREVIOUSTRACK));
            if (i == 29) if (down) SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_NEXTTRACK));
            if (i == 30) if (down) SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_VOLUME_UP));
            if (i == 31) if (down) SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_VOLUME_DOWN));
            if (i == 32) if (down) SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_VOLUME_MUTE));
        }

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

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog svfl = new SaveFileDialog();
            svfl.Filter = "Special Files (*.sch)|*.sch";
            if (svfl.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw;
                sw = File.CreateText(svfl.FileName);
                sw.WriteLine(boxa.SelectedIndex);
                sw.WriteLine(boxb.SelectedIndex);
                sw.WriteLine(boxup.SelectedIndex);
                sw.WriteLine(boxdown.SelectedIndex);
                sw.WriteLine(boxleft.SelectedIndex);
                sw.WriteLine(boxright.SelectedIndex);
                sw.WriteLine(boxhome.SelectedIndex);
                sw.WriteLine(boxminus.SelectedIndex);
                sw.WriteLine(boxplus.SelectedIndex);
                sw.WriteLine(box1.SelectedIndex);
                sw.WriteLine(box2.SelectedIndex);
                foreach (string s in custom){
                    string t = s;
                    if (s == "")
                        t = "nothinghere";
                    sw.WriteLine(t);}
                sw.WriteLine(tb1.Text);
                sw.Close();
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfl = new OpenFileDialog();
            opfl.Filter = "Special Files (*.sch)|*.sch";
            if (opfl.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr;
                sr = File.OpenText(opfl.FileName);
                boxa.SelectedIndex = int.Parse(sr.ReadLine());
                boxb.SelectedIndex = int.Parse(sr.ReadLine());
                boxup.SelectedIndex = int.Parse(sr.ReadLine());
                boxdown.SelectedIndex = int.Parse(sr.ReadLine());
                boxleft.SelectedIndex = int.Parse(sr.ReadLine());
                boxright.SelectedIndex = int.Parse(sr.ReadLine());
                boxhome.SelectedIndex = int.Parse(sr.ReadLine());
                boxminus.SelectedIndex = int.Parse(sr.ReadLine());
                boxplus.SelectedIndex = int.Parse(sr.ReadLine());
                box1.SelectedIndex = int.Parse(sr.ReadLine());
                box2.SelectedIndex = int.Parse(sr.ReadLine());
                sr.ReadLine();
                for (int i = 1; i < custom.Length;i++){
                    custom[i] = sr.ReadLine();
                    if (custom[i] != null && custom[i] != "nothinghere"){
                        boxes[i].Items.RemoveAt(23);
                        boxes[i].Items.Insert(23, custom[i]);
                        boxes[i].SelectedItem = custom[i];}
                    else { custom[i] = ""; }}
                tb1.Text = sr.ReadLine();
                sr.Close();
            }


        }

        void setclick(int down, int up)
        {
            mouseclickd = down;
            mouseclicku = up;
        }

        void customize(ComboBox box, int i)
        {
            if (box.SelectedIndex == 23 && prevselindex[i] != 23 && !start)
            {
                box.Items.RemoveAt(23);
                box.Items.Insert(23, tb1.Text);
                custom[i] = tb1.Text;
                prevselindex[i] = 23;
                box.SelectedItem = tb1.Text;
            }
            if (box.SelectedIndex != 23 && prevselindex[i] == 23)
            {
                box.Items.RemoveAt(23);
                box.Items.Insert(23, "Custom");
            }
            prevselindex[i] = box.SelectedIndex;
        }

        #region events
        private void boxa_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxa, 1);
        }

        private void boxb_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxb, 2);
        }

        private void boxup_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxup, 3);
        }

        private void boxdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxdown, 4);
        }

        private void boxleft_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxleft, 5);
        }

        private void boxright_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxright, 6);
        }

        private void boxhome_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxhome, 7);
        }

        private void boxminus_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxminus, 8);
        }

        private void boxplus_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxplus, 9);
        }

        private void box1_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(box1, 10);
        }

        private void box2_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(box2, 11);
        }     

        private void alabel_Click(object sender, EventArgs e)
        {
            translate(boxa.SelectedIndex, true, 1);
        }

        private void blabel_Click(object sender, EventArgs e)
        {
            translate(boxb.SelectedIndex, true, 0);
        }

        private void uplabel_Click(object sender, EventArgs e)
        {
            translate(boxup.SelectedIndex, true, 2);
        }

        private void downlabel_Click(object sender, EventArgs e)
        {
            translate(boxdown.SelectedIndex, true, 3);
        }

        private void leftlabel_Click(object sender, EventArgs e)
        {
            translate(boxleft.SelectedIndex, true, 4);
        }

        private void rightlabel_Click(object sender, EventArgs e)
        {
            translate(boxright.SelectedIndex, true, 5);
        }

        private void homepicture_Click(object sender, EventArgs e)
        {
            translate(boxhome.SelectedIndex, true, 6);
        }

        private void minuslabel_Click(object sender, EventArgs e)
        {
            translate(boxminus.SelectedIndex, true, 7);
        }

        private void pluslabel_Click(object sender, EventArgs e)
        {
            translate(boxplus.SelectedIndex, true, 8);
        }

        private void onelabel_Click(object sender, EventArgs e)
        {
            translate(box1.SelectedIndex, true, 9);
        }

        private void twolabel_Click(object sender, EventArgs e)
        {
            translate(box2.SelectedIndex, true, 10);
        }
        #endregion
    }
}