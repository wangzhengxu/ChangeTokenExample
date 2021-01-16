using System;

namespace ChangeTokenExample
{
    public class Logger
    {
        public static void ToConsole(string message, ConsoleColor color = ConsoleColor.White)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"[{DateTime.Now:hh:mm:ss.ff}] - {message}");
            }
        }
    }
}