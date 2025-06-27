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

            var today = DateTime.Now;
            var s1 = dateTime.ToString("d");

            Console.WriteLine(s1);
        }


        private static void DisplayDatePattern2(DateTime dateTime) {

            var s2 = dateTime.ToString("yyyy年MM月dd日HH時mm分ss秒 ");

            Console.WriteLine(s2);
        }

        private static void DisplayDatePattern3(DateTime dateTime) {

            var today = DateTime.Now;

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = today.ToString("ggyy年M月d日", culture);
            var dayofweek = culture.DateTimeFormat.GetDayName(today.DayOfWeek);

            Console.WriteLine($"{str}({dayofweek})");
        }
    }
}
