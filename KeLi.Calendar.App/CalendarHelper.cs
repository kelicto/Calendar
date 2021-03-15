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