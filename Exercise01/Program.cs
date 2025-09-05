
using System.Text.RegularExpressions;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine(IsPhoneNumber("080-9111-1234"));  //true
            Console.WriteLine(IsPhoneNumber("090-9111-1234"));  //true
            Console.WriteLine(IsPhoneNumber("060-9111-1234"));  //false
            Console.WriteLine(IsPhoneNumber("190-9111-1234"));  //false
            Console.WriteLine(IsPhoneNumber("091-9111-1234"));  //false
            Console.WriteLine(IsPhoneNumber("090-9111-12341")); //false
            Console.WriteLine(IsPhoneNumber("A090-9111-1234")); //false
            Console.WriteLine(IsPhoneNumber("090-911-1234"));  //false
            Console.WriteLine(IsPhoneNumber("090-1911-234"));  //false
        }

        private static bool IsPhoneNumber(string telNum) {
            return Regex.IsMatch(telNum, @"^0[7-9]0-\d{4}-\d{4}$");
        }
    }
}
