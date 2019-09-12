using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace DungeonGenerator
{
    class ConsoleConfig
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern Int32 SetCurrentConsoleFontEx(
            IntPtr ConsoleOutput,
            bool MaximumWindow,
            ref CONSOLE_FONT_INFO_EX ConsoleCurrentFontEx);

        private enum StdHandle
        {
            OutputHandle = -11
        }

        [DllImport("kernel32")]
        private static extern IntPtr GetStdHandle(StdHandle index);

        private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);


        [StructLayout(LayoutKind.Sequential)]
        public struct COORD
        {
            public short X;
            public short Y;

            public COORD(short X, short Y)
            {
                this.X = X;
                this.Y = Y;
            }
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct CONSOLE_FONT_INFO_EX
        {
            public uint cbSize;
            public uint nFont;
            public COORD dwFontSize;
            public int FontFamily;
            public int FontWeight;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] // Edit sizeconst if the font name is too big
            public string FaceName;
        }

        public static void ChangeFont()
        {


            // Setting the font and fontsize
            // Other values can be changed too 


            // Instantiating CONSOLE_FONT_INFO_EX and setting its size (the function will fail otherwise)
            CONSOLE_FONT_INFO_EX ConsoleFontInfo = new CONSOLE_FONT_INFO_EX();
            ConsoleFontInfo.cbSize = (uint)Marshal.SizeOf(ConsoleFontInfo);

            // Optional, implementing this will keep the fontweight and fontsize from changing
            // See notes
            // GetCurrentConsoleFontEx(GetStdHandle(StdHandle.OutputHandle), false, ref ConsoleFontInfo);

            ConsoleFontInfo.FaceName = "Consolas";
            //ConsoleFontInfo.dwFontSize.X = 6;
            ConsoleFontInfo.dwFontSize.Y = 14;

            SetCurrentConsoleFontEx(GetStdHandle(StdHandle.OutputHandle), false, ref ConsoleFontInfo);

            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            Console.BufferHeight = 999;
            Console.BufferWidth = 999;


        }
    }
}
