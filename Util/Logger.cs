using System;

namespace RCTool_Server.Util
{
    public static class Logger
    {
        private static readonly object ThreadLock = new object();

        public static void Log(params object[] strings)
        {
            lock (ThreadLock)
            {
                WriteDateTime();
                Console.WriteLine(string.Join(", ", strings));
                Console.ResetColor();
            }
        }

        public static void Error(params object[] strings)
        {
            lock (ThreadLock)
            {
                WriteDateTime();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Join(", ", strings));
                Console.ResetColor();
            }
        }

        private static void WriteDateTime()
        {
            var dtg = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(dtg.ToString("yyyy-MM-dd"));
            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(dtg.ToString("HH:mm:ss"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] ");
        }
    }
}
