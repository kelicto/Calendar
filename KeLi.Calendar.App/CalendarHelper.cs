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
     |  |              Email: kelistudy@163.com              |  |  |     |         |      |
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
using System.Threading;

using static System.DateTime;

namespace KeLi.Calendar.App
{
    public class CalendarHelper
    {
        private static int _year;

        private static int _month;

        private static int _height;

        public static void ShowCalendar()
        {
            ShowCurrentMonth(true);

            SearchAnyMonth();

            Thread.Sleep(3000);

            for (var i = 0; i < 100000; i++)
            {
                Console.Clear();

                ShowCurrentMonth();

                Console.WriteLine();

                ShowAnyMonth();

                var seek = new Random((int)(Now.Ticks & 0xffffffffL) | (int)(Now.Ticks >> 32)).Next(10) * 100;

                Thread.Sleep(seek);
            }
        }

        private static void SearchAnyMonth()
        {
            while (true)
            {
                Console.SetCursorPosition(0, CalendarUtil.ComputeCurrentMonthLine());

                Console.Write("Inputs Year[1-9999]: ");

                _year = Convert.ToInt32(Console.ReadLine());

                if (_year > 0 && _year < 9999)
                    break;
            }

            while (true)
            {
                Console.SetCursorPosition(0, CalendarUtil.ComputeCurrentMonthLine() + 1);

                Console.Write("Inputs Month[1-12]: ");

                _month = Convert.ToInt32(Console.ReadLine());

                if (_month > 0 && _month < 13)
                    break;
            }

            Console.WriteLine();

            _height = CalendarUtil.ComputeCurrentMonthLine() + CalendarUtil.ComputeAnyMonthLine(_year, _month) + 2;

            // Updates console's window height.
            Console.WindowHeight = _height;

            // Updates console's buffer height.
            Console.BufferHeight = _height;

            CalendarUtil.ShowAnyMonth(_year, _month, true);
        }

        private static void ShowCurrentMonth(bool flag = false)
        {
            CalendarUtil.ShowCurrentMonth(flag);
        }

        private static void ShowAnyMonth()
        {
            CalendarUtil.ShowAnyMonth(_year, _month, false, _height);
        }
    }
}