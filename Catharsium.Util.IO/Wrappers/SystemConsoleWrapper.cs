using Catharsium.Util.IO.Interfaces;
using System;
using System.IO;

namespace Catharsium.Util.IO.Wrappers
{
    public class SystemConsoleWrapper : IConsoleWrapper
    {
        #region Basic

        public string Title
        {
            get {
                return System.Console.Title;
            }
            set {
                System.Console.Title = value;
            }
        }


        public bool CapsLock
        {
            get {
                return System.Console.CapsLock;
            }
        }

        #endregion

        #region IO

        public TextReader In
        {
            get {
                return System.Console.In;
            }
        }


        public TextWriter Out
        {
            get {
                return System.Console.Out;
            }
        }

        #endregion

        #region Buffer

        public int BufferWidth
        {
            get {
                return System.Console.BufferWidth;
            }
            set {
                System.Console.BufferWidth = value;
            }
        }


        public int BufferHeight
        {
            get {
                return System.Console.BufferHeight;
            }
            set {
                System.Console.BufferHeight = value;
            }
        }


        public void SetBufferSize(int width, int height)
        {
            System.Console.SetBufferSize(width, height);
        }


        public void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop)
        {
            System.Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop);
        }


        public void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor)
        {
            System.Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, sourceChar, sourceForeColor, sourceBackColor);
        }

        #endregion

        #region Cursor

        public int CursorLeft
        {
            get {
                return System.Console.CursorLeft;
            }
            set {
                System.Console.CursorLeft = value;
            }
        }


        public int CursorTop
        {
            get {
                return System.Console.CursorTop;
            }
            set {
                System.Console.CursorTop = value;
            }
        }


        public int CursorSize
        {
            get {
                return System.Console.CursorSize;
            }
            set {
                System.Console.CursorSize = value;
            }
        }


        public bool CursorVisible
        {
            get {
                return System.Console.CursorVisible;
            }
            set {
                System.Console.CursorVisible = value;
            }
        }


        public void SetCursorPosition(int left, int top)
        {
            System.Console.SetCursorPosition(left, top);
        }

        #endregion

        #region Color

        public ConsoleColor ForegroundColor
        {
            get {
                return System.Console.ForegroundColor;
            }
            set {
                System.Console.ForegroundColor = value;
            }
        }


        public ConsoleColor BackgroundColor
        {
            get {
                return System.Console.BackgroundColor;
            }
            set {
                System.Console.BackgroundColor = value;
            }
        }


        public void ResetColor()
        {
            System.Console.ResetColor();
        }

        #endregion

        #region Read

        public int Read()
        {
            return System.Console.Read();
        }


        public ConsoleKeyInfo ReadKey()
        {
            return System.Console.ReadKey();
        }


        public string ReadLine()
        {
            return System.Console.ReadLine();
        }

        #endregion

        #region Write

        public void Write(string text)
        {
            System.Console.Write(text);
        }


        public void WriteLine(string text = null)
        {
            if (text == null) {
                System.Console.WriteLine();
            }
            else {
                System.Console.WriteLine(text);
            }
        }

        #endregion
    }
}