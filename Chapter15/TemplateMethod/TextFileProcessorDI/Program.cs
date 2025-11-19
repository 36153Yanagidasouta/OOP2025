using System;
using System.IO;

namespace TextFileProcessorDI {
    internal class Program {
        static void Main(string[] args) {

            var service = new LineToHalfNumberService();
            var processor = new TextFileProcessor(service);

            Console.WriteLine("ファイルのパスを入力してください:");

            string inputPath = Console.ReadLine();
            string filePath = inputPath.Trim().Trim('"');

            if (File.Exists(filePath)) {
                try {
                    processor.Run(filePath);
                }
                catch (Exception ex) {
                    Console.WriteLine($"エラー: 処理中に問題が発生しました: {ex.Message}");
                }
            } else {
                Console.WriteLine($"エラー: ファイルない: {filePath}");
            }
        }
    }
}