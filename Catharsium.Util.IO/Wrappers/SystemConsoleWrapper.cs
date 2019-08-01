using Catharsium.Util.IO.Interfaces;
using System;

namespace Catharsium.Util.IO.Wrappers
{
    public class SystemConsoleWrapper : IConsoleWrapper
    {
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


        public void WriteLine(string text)
        {
            System.Console.WriteLine(text);
        }

        #endregion
    }
}