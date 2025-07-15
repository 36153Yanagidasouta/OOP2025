using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            //問題12.1.1
            var emp = new Employee {
                Id = 123,
                Name = "山田太郎",
                HireDate = new DateTime(2018, 10, 1),
            };
            var jsonString = Serialize(emp);
            Console.WriteLine(jsonString);
            var obj = Deserialize(jsonString);
            Console.WriteLine(obj);

            //問題12.1.2
            Employee[] employees = [
                new () {
                    Id = 123,
                    Name = "山田太郎",
                    HireDate = new DateTime(2018, 10, 1),
                },
                new () {
                    Id = 198,
                    Name = "田中華子",
                    HireDate = new DateTime(2020, 4, 1),
                },
            ];
            Serialize("employees.json", employees);

            //問題12.1.3
            //var empdata = Deserialize_f("employees.json");
            //foreach (var empd in empdata)
            //    Console.WriteLine(empd);

        }
        //問題12.1.1
        static string Serialize(Employee emp) {
            var options = new JsonSerializerOptions {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            string jsonString = JsonSerializer.Serialize(emp, options);
            return jsonString;
        }

        static Employee? Deserialize(string text) {
            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            return JsonSerializer.Deserialize<Employee>(text, options);
        }

        //問題12.1.2
        //シリアル化してファイルへ出力する
        static void Serialize(string filePath, IEnumerable<Employee> employees) {

            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true

            };
            string json = JsonSerializer.Serialize(employees, options);
            File.WriteAllText("product.json", json);

        }
        //問題12.1.3
        //シリアル化してファイルへ出力する
        static Employee[] Deserialize_f(string filePath) {

            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true

            };

            var text = File.ReadAllText("./product.json ");
            var empfile = JsonSerializer.Deserialize<Employee[]>(text);

            return empfile ; 
             
                
        }

    }
    public record Employee {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
    }
}