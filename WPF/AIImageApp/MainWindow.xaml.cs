using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Media.Imaging;



namespace AIImageApp {
    public partial class MainWindow : Window {

        // ★★★ ここに自分の OpenAI APIキーを貼り付ける ★★★
        // 例: "sk-xxxx..." で始まる文字列
        private const string ApiKey = "APIキー";

        private static readonly HttpClient httpClient = new HttpClient();

        public MainWindow() {
            InitializeComponent();
        }

        // 「生成」ボタン
        private async void GenerateImage_Click(object sender, RoutedEventArgs e) {
            string prompt = PromptBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(prompt)) {
                MessageBox.Show("プロンプトを入力してください。", "入力エラー",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(ApiKey) || ApiKey.StartsWith("sk-ここに")) {
                MessageBox.Show("MainWindow.xaml.cs の ApiKey を自分のキーに書き換えてください。",
                    "APIキー未設定", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            StatusText.Text = "AIが画像を生成しています…";

            try {
                // ========= ① リクエストの準備 =========
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", ApiKey);

                var requestBody = new ImageGenerationRequest {
                    model = "gpt-image-1",       // 画像生成モデル
                    prompt = prompt,             // プロンプト
                    n = 1,                       // 生成枚数
                    size = "1024x1024",          // サイズ
                    response_format = "b64_json" // Base64形式で受け取る
                };

                string json = JsonSerializer.Serialize(requestBody);

                using var content = new StringContent(json, Encoding.UTF8, "application/json");

                // ========= ② OpenAI APIを呼ぶ =========
                var response = await httpClient.PostAsync(
                    "https://api.openai.com/v1/images/generations",
                    content
                );

                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();

                // ========= ③ レスポンスJSONをパース =========
                var result = JsonSerializer.Deserialize<ImageGenerationResponse>(
                    responseJson,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                string base64 = result?.data?[0]?.b64_json;

                if (string.IsNullOrWhiteSpace(base64)) {
                    StatusText.Text = "画像データを取得できませんでした。";
                    return;
                }

                // ========= ④ Base64 → BitmapImage に変換して表示 =========
                byte[] bytes = Convert.FromBase64String(base64);

                var bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = new MemoryStream(bytes);
                bmp.CacheOption = BitmapCacheOption.OnLoad;
                bmp.EndInit();
                bmp.Freeze();

                ResultImage.Source = bmp;
                StatusText.Text = "生成完了！";
            }
            catch (Exception ex) {
                StatusText.Text = "エラー: " + ex.Message;
            }
        }

        // ====== OpenAI Images API 用のシンプルなモデルクラス ======

        // リクエストボディ
        public class ImageGenerationRequest {
            public string model { get; set; } = "";
            public string prompt { get; set; } = "";
            public int n { get; set; } = 1;
            public string size { get; set; } = "1024x1024";
            public string response_format { get; set; } = "b64_json";
        }

        // レスポンス全体
        public class ImageGenerationResponse {
            public List<ImageData> data { get; set; } = new();
        }

        // data[0] の中身
        public class ImageData {
            public string b64_json { get; set; } = "";
        }
    }
}
