/*
 * MIT License
 *
 * Copyright(c) 2020 KeLi
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

/*
             ,---------------------------------------------------,              ,---------,
        ,----------------------------------------------------------,          ,"        ,"|
      ,"                                                         ,"|        ,"        ,"  |
     +----------------------------------------------------------+  |      ,"        ,"    |
     |  .----------------------------------------------------.  |  |     +---------+      |
     |  | C:\>FILE -INFO                                     |  |  |     | -==----'|      |
     |  |                                                    |  |  |     |         |      |
     |  |                                                    |  |  |/----|`---=    |      |
     |  |              Author: KeLi                          |  |  |     |         |      |
     |  |              Email: kelicto@protonmail.com         |  |  |     |         |      |
     |  |              Creation Time: 04/19/2020 01:00:00 PM |  |  |     |         |      |
     |  | C:\>_                                              |  |  |     | -==----'|      |
     |  |                                                    |  |  |   ,/|==== ooo |      ;
     |  |                                                    |  |  |  // |(((( [66]|    ,"
     |  `----------------------------------------------------'  |," .;'| |((((     |  ,"
     +----------------------------------------------------------+  ;;  | |         |,"
        /_)_________________________________________________(_/  //'   | +---------+
           ___________________________/___  `,
          /  oooooooooooooooo  .o.  oooo /,   \,"-----------
         / ==ooooooooooooooo==.o.  ooo= //   ,`\--{)B     ,"
        /_==__==========__==_ooo__ooo=_/'   /___________,"
*/

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