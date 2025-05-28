namespace Section05 {
    internal class Program {
        static void Main(string[] args) {
            var text = "The quick brown fox jumps over the lazy dog";
            var words = text.Split(' ');

            var word = words.FirstOrDefault(s => s.Length == 10);

            var numbers = new List <int>{1,4,-5,6,8,-9,4,5,-7,8,5,-3 };
            var index = numbers.FindIndex(n => n < 0);


        }
    }
}
