using System.Data.Common;
using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            /*     var today =new  DateTime(2025,7,12);　//日付を返す
                   var now = DateTime.Now;　　　//時間と日付

                   Console.WriteLine($"Today:{today.Month}");
                   Console.WriteLine($"Today:{now}");*/


            //①自分の生年月日は何曜日かを書いて調べる

            Console.WriteLine("生年月日を入力");
            Console.Write("西暦:");
            var year = int.Parse(Console.ReadLine());

            Console.Write( "月:" );
            var month = int.Parse(Console.ReadLine());

            Console.Write("日");
            var day = int.Parse(Console.ReadLine());

            var birthday = new DateTime(year, month, day);



            var culuter = new CultureInfo("ja-JP");
            culuter.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = birthday.ToString("ggyy年M月d日", culuter);


            var dayofweek = culuter.DateTimeFormat.GetShortestDayName(birthday.DayOfWeek);
            Console.Write(str + dayofweek+ "曜日");


            //②うるう年の判定プログラムを作成

            var isLeapYear = DateTime.IsLeapYear(birthday.Year);
            if (isLeapYear) {
                Console.WriteLine("うるう年です");
            }
            Console.WriteLine("うるう年ではない");


            //③生まれてから何日?

            var date1 = birthday;
            var date2 = DateTime.Today;

            TimeSpan diff = date2 - date1;

            Console.WriteLine($"生まれてから{diff.Days}日");

            
            //④あなたは○○歳です

            Console.WriteLine($"年齢{diff.Days / 365}歳");



            //⑤一月一日から何日目か
            var today = DateTime.Today;
            int dayOfYear = today.DayOfYear;
            Console.WriteLine(dayOfYear);


        }
    }
}
