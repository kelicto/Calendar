using System;
using System.Media;

using KeLi.Calendar.App.Properties;

namespace KeLi.Calendar.App
{
    public class Program
    {
        public static void Main()
        {
            Console.Title = "Calendar";

            Console.WindowWidth = 26;

            Console.WindowHeight = 29;

            Console.BufferWidth = 26;

            Console.BufferHeight = 29;

            try
            {
                new SoundPlayer(Resources.SanShao).Play();

                CalendarHelper.ShowCalendar();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }

            Console.ReadKey();
        }
    }
}