namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {

             var sales = new SalesCounter(@"data\Sales.csv");
            IDictionary<string, int> amountsPerStore = sales.GetPerStoreSales();
            foreach (KeyValuePair<string, int> obj in amountsPerStore) {
                Console.WriteLine($"{obj.Key} {obj.Value}");
            }
        }
    }
}
