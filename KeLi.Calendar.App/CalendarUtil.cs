using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace KeLi.Calendar.App
{
    public class CalendarUtil
    {
        public static void ShowCurrentMonth(bool flag = false)
        {
            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            var week = (int)date.DayOfWeek;

            var dayNum = date.AddMonths(1).AddDays(-1).Day;

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("SU  MO  TU  WE  TH  FR  SA");

            // Fills blank space in first line.
            for (var i = 0; i < week; i++)
                Console.Write("    ");

            for (var i = 1; i <= dayNum; i++)
            {
                if (i == DateTime.Now.Day)
                {
                    // Sets back color at today position.
                    Console.BackgroundColor = ConsoleColor.DarkGray;

                    // If they are same color. then sets foreground color to black.  
                    if (Console.ForegroundColor == ConsoleColor.DarkGray)
                        Console.ForegroundColor = ConsoleColor.Black;

                    if (flag)
                        Thread.Sleep(100);

                    Console.Write("{0:00}", i);

                    // Resets back color to black.
                    Console.BackgroundColor = ConsoleColor.Black;

                    // The next date position should add two space.
                    Console.Write("  ");
                }

                else
                {
                    var colors = ((ConsoleColor[])Enum.GetValues(typeof(ConsoleColor))).ToList();

                    colors.Remove(ConsoleColor.Black);

                    Console.ForegroundColor = colors[new Random(DateTime.Now.Millisecond + i).Next(0, colors.Count)];

                    if (flag)
                        Thread.Sleep(100);

                    Console.Write("{0:00}  ", i);
                }

                if ((i + week) % 7 == 0)
                    Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine();
        }

        public static void ShowAnyMonth(int year, int month, bool flag = false, int height = 0)
        {
            if (year < 0 && year > 9999 || month < 0 || month > 12)
                throw new InvalidDataException();

            if (!flag)
            {
                Console.WindowHeight = height - 2;

                Console.BufferHeight = height - 2;
            }

            var date = new DateTime(year, month, 1);

            var week = (int)date.DayOfWeek;

            var dayNum = date.AddMonths(1).AddDays(-1).Day;

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("SU  MO  TU  WE  TH  FR  SA");

            for (var i = 0; i < week; i++)
                Console.Write("    ");

            for (var i = 1; i <= dayNum; i++)
            {
                var colors = ((ConsoleColor[])Enum.GetValues(typeof(ConsoleColor))).ToList();

                colors.Remove(ConsoleColor.Black);

                Console.ForegroundColor = colors[new Random(DateTime.Now.Millisecond + i).Next(0, colors.Count)];

                if (flag)
                    Thread.Sleep(100);

                Console.Write("{0:00}  ", i);

                if ((i + week) % 7 == 0)
                    Console.WriteLine();
            }
        }

        public static int ComputeCurrentMonthLine()
        {
            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            var week = (int)date.DayOfWeek;

            var dayNum = date.AddMonths(1).AddDays(-1).Day;

            var lineNum = 1 + (dayNum - 7 + week) / 7 + ((dayNum - 7 + week) % 7 == 0 ? 0 : 1);

            return 2 * lineNum + 2;
        }

        public static int ComputeAnyMonthLine(int year, int month)
        {
            if (year < 0 && year > 9999 || month < 0 || month > 12)
                throw new InvalidDataException();

            var date = new DateTime(year, month, 1);

            var week = (int)date.DayOfWeek;

            var dayNum = date.AddMonths(1).AddDays(-1).Day;

            var lineNum = 1 + (dayNum - 7 + week) / 7 + ((dayNum - 7 + week) % 7 == 0 ? 0 : 1);

            return 2 * lineNum + 2;
        }
    }
}