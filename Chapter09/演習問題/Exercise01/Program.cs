using System.Globalization;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            var dateTime = DateTime.Now;

            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);

        }

        private static void DisplayDatePattern1(DateTime dateTime) {

            var str = string.Format($"{dateTime}");
            Console.WriteLine(str);
        }


        private static void DisplayDatePattern2(DateTime dateTime) {

            var s2 = dateTime.ToString("yyyy年MM月dd日HH時mm分ss秒 ");
            Console.WriteLine(s2);
        }

        private static void DisplayDatePattern3(DateTime dateTime) {

            var today = DateTime.Now;

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var datestr = today.ToString("ggyy", culture);
            var dayofweek = culture.DateTimeFormat.GetDayName(today.DayOfWeek);

            var str = string.Format($"{datestr}年{dateTime.Month,2}年{dateTime.Day,2}日({dayofweek})");
            Console.WriteLine(str);

        }
    }
}
