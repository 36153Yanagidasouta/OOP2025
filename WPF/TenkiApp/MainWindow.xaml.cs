using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using NGeo;

namespace TenkiApp {
    public partial class MainWindow : Window {
        private DispatcherTimer timer = new DispatcherTimer();
        private double latitude = 35.0;
        private double longitude = 139.0;
        private static readonly HttpClient httpClient = new HttpClient();
        private Geocoder geoCoder = new Geocoder(); // Geocoder インスタンスを作成

        public MainWindow() {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            SearchButton.Click += async (_, _) => await SearchLocationAsync();
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            StartAutoUpdate();
            await UpdateWeatherAsync();
        }

        #region 自動更新
        private void StartAutoUpdate() {
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += async (_, _) => await UpdateWeatherAsync();
            timer.Start();
        }
        #endregion

        #region 天気取得
        private async Task UpdateWeatherAsync() {
            string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true&hourly=relativehumidity_2m,weathercode&timezone=Asia/Tokyo";

            try {
                var response = await httpClient.GetFromJsonAsync<OpenMeteoResponse>(url);

                if (response?.current_weather != null) {
                    double temp = response.current_weather.temperature;
                    double wind = response.current_weather.windspeed;
                    double humidity = 0;

                    if (response.hourly?.relativehumidity_2m != null && response.hourly.relativehumidity_2m.Length > 0)
                        humidity = response.hourly.relativehumidity_2m[0];

                    TemperatureText.Text = $"{temp:F1} ℃";
                    WindText.Text = $"{wind:F1} m/s";
                    HumidityText.Text = $"{humidity:F0} %";
                    DateText.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
                    CityText.Text = string.IsNullOrEmpty(CityInput.Text) ? "現在地" : CityInput.Text;

                    string weatherEmoji = WeatherCodeToEmoji(response.current_weather.weathercode);
                    string weatherDesc = WeatherCodeToText(response.current_weather.weathercode);
                    WeatherEmojiText.Text = weatherEmoji;
                    WeatherDescText.Text = weatherDesc;

                    string iconUri = WeatherCodeToIcon(response.current_weather.weathercode);
                    WeatherIcon.Source = new BitmapImage(new Uri(iconUri, UriKind.RelativeOrAbsolute));
                }
            }
            catch (HttpRequestException ex) {
                MessageBox.Show($"ネットワークエラー: {ex.Message}", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex) {
                MessageBox.Show($"天気情報取得エラー: {ex.Message}", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task SearchLocationAsync() {
            string input = CityInput.Text.Trim();

            if (string.IsNullOrEmpty(input)) {
                MessageBox.Show("住所を入力してください。", "入力エラー", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // NGeo を使って住所から緯度・経度を取得
            var geoResults = await geoCoder.GeocodeAsync(input);

            if (geoResults.Any()) {
                var result = geoResults.First(); // 最初の結果を取得（最も関連性の高いもの）
                latitude = result.Latitude;
                longitude = result.Longitude;
                await UpdateWeatherAsync();
            } else {
                MessageBox.Show("住所に対応する緯度・経度を取得できませんでした。", "エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private string WeatherCodeToEmoji(int code) {
            return code switch {
                0 => "☀️",
                1 => "🌤️",
                2 => "⛅",
                3 => "☁️",
                45 or 48 => "🌫️",
                51 or 53 or 55 => "🌦️",
                61 => "🌧️",
                63 => "🌧️",
                65 => "⛈️",
                71 => "🌨️",
                73 => "❄️",
                75 => "❄️",
                77 => "🌨️",
                80 or 81 or 82 => "🌦️",
                85 or 86 => "🌨️",
                95 => "⛈️",
                96 or 99 => "⛈️",
                _ => "❓"
            };
        }

        private string WeatherCodeToText(int code) {
            return code switch {
                0 => "快晴",
                1 => "晴れ",
                2 => "一部曇り",
                3 => "曇り",
                45 or 48 => "霧",
                51 or 53 or 55 => "霧雨",
                61 => "小雨",
                63 => "雨",
                65 => "大雨",
                71 => "小雪",
                73 => "雪",
                75 => "大雪",
                77 => "みぞれ",
                80 or 81 or 82 => "にわか雨",
                85 or 86 => "にわか雪",
                95 => "雷雨",
                96 or 99 => "雷雨と雹",
                _ => "不明"
            };
        }

        private string WeatherCodeToIcon(int code) {
            return code switch {
                0 or 1 => "Images/sunny.png",
                2 or 3 or 45 or 48 => "Images/cloudy.png",
                51 or 53 or 55 or 61 or 63 or 65 or 80 or 81 or 82 => "Images/rain.png",
                71 or 73 or 75 or 77 or 85 or 86 => "Images/snow.png",
                95 or 96 or 99 => "Images/rain.png", // 雷用のアイコンがあれば変更
                _ => "Images/sunny.png"
            };
        }
        #endregion

        protected override void OnClosed(EventArgs e) {
            timer?.Stop();
            base.OnClosed(e);
        }
    }

    #region データクラス
    public class OpenMeteoResponse {
        public CurrentWeather current_weather { get; set; }
        public HourlyData hourly { get; set; }
    }

    public class CurrentWeather {
        public double temperature { get; set; }
        public double windspeed { get; set; }
        public int is_day { get; set; }
        public int weathercode { get; set; }
    }

    public class HourlyData {
        public double[] relativehumidity_2m { get; set; }
        public int[] weathercode { get; set; }
    }
    #endregion
}
