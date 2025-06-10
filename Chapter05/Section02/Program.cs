namespace Section02 {
    internal class Program {
        static void Main(string[] args) {

            var appVer1 = new AppVersion(5, 1, 3);
            Console.WriteLine(appVer1);

            var appVer2 = new AppVersion(5, 1, 3);
            Console.WriteLine(appVer2);

            var YearMonth = new ymmethod(12, 8);
            Console.WriteLine(YearMonth);

            Console.WriteLine(appVer1);

            //if (appVer1 == appVer2) {
            //    Console.WriteLine("等しい");
            //} else {
            //    Console.WriteLine("等しくない");
            //}
        }
    }

    public record AppVersion(int m, int mi, int b = 0, int r = 0) {
        public int Major { get; init; } = m;
        public int Minor { get; init; } = mi;
        public int Build { get; init; } = b;
        public int Revision { get; init; } = r;

        public override string ToString() =>
            $"{Major}.{Minor}.{Build}.{Revision}";
    }

    public class ymmethod(int Year = 0, int Month = 0) {
        public int Year { get; init; } = Year;
        public int Month { get; init; } = Month;

        public override string ToString() => $"{Year}.{Month}";
    }
}

