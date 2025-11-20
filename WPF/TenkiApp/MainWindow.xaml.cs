using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Input;

namespace TenkiApp {
    public partial class MainWindow : Window {
        private readonly Random rnd = new Random();
        private DispatcherTimer timer = new DispatcherTimer();
        private double latitude = 35.0;
        private double longitude = 139.0;
        private Dictionary<string, (double lat, double lon)> prefectures;

        public MainWindow() {
            InitializeComponent();
            LoadPrefectures();

            Loaded += (_, _) => {
                Dispatcher.InvokeAsync(() => {
                    CreateInitialClouds(10, 30); // 初期雲を均等に配置
                }, DispatcherPriority.Loaded);
                StartAutoUpdate();
            };

            UpdateButton.Click += async (_, _) => await UpdateWeatherAsync();
            SearchButton.Click += async (_, _) => await SearchPrefectureAsync();
        }

        #region CSV読み込み
        private void LoadPrefectures() {
            string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "prefecture_list.csv");
            if (!File.Exists(csvPath)) {
                MessageBox.Show("prefecture_list.csv が見つかりません。");
                prefectures = new Dictionary<string, (double, double)>();
                return;
            }

            prefectures = File.ReadAllLines(csvPath)
                .Skip(1)
                .Select(line => line.Split(','))
                .Where(parts => parts.Length >= 3)
                .Select(parts => {
                    bool okLat = double.TryParse(parts[1], out double lat);
                    bool okLon = double.TryParse(parts[2], out double lon);
                    return (Name: parts[0].Trim(), Lat: lat, Lon: lon, Valid: okLat && okLon);
                })
                .Where(x => x.Valid)
                .ToDictionary(x => x.Name, x => (x.Lat, x.Lon));
        }
        #endregion

        #region 自動更新
        private void StartAutoUpdate() {
            timer.Interval = TimeSpan.FromMinutes(5);
            timer.Tick += async (_, _) => await UpdateWeatherAsync();
            timer.Start();
        }
        #endregion

        #region 雲生成

        // 初期雲：均等に横幅に分布
        private void CreateInitialClouds(int count, double baseSpeed) {
            CloudCanvas.Children.Clear();
            double canvasWidth = CloudCanvas.ActualWidth;
            double spacing = canvasWidth / count;

            for (int i = 0; i < count; i++) {
                double x = i * spacing - rnd.Next(0, 50); // 少しランダムずらす
                double y = rnd.Next(0, (int)(CloudCanvas.ActualHeight * 0.7));
                CreateCloudAtPosition(x, y, baseSpeed);
            }
        }

        // 雲生成メソッド
        private void CreateCloudAtPosition(double x, double y, double baseSpeed) {
            // 2種類の画像からランダム選択
            string[] cloudImages = { "Images/EDK.png", "Images/YNG.png", "Images/adt.jpg" };
            string cloudImage = cloudImages[rnd.Next(cloudImages.Length)];

            var img = new Image {
                Source = new BitmapImage(new Uri(cloudImage, UriKind.Relative)),
                Width = rnd.Next(150, 250),
                Height = rnd.Next(70, 150),
                Opacity = 0.4 + rnd.NextDouble() * 0.5
            };

            CloudCanvas.Children.Add(img);
            Canvas.SetTop(img, y);
            Canvas.SetLeft(img, x);

            var transform = new TranslateTransform();
            img.RenderTransform = transform;

            var anim = new DoubleAnimation {
                From = x,
                To = CloudCanvas.ActualWidth + img.Width,
                Duration = TimeSpan.FromSeconds(baseSpeed + rnd.NextDouble() * 10),
                RepeatBehavior = RepeatBehavior.Forever
            };

            transform.BeginAnimation(TranslateTransform.XProperty, anim);
        }

        // クリックで複数雲をランダムに出現
        private void CloudCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            for (int i = 0; i < 3; i++) // 一度に3個生成
            {
                double x = rnd.Next(0, (int)CloudCanvas.ActualWidth);
                double y = rnd.Next(0, (int)(CloudCanvas.ActualHeight * 0.8));
                CreateCloudAtPosition(x, y, 30 + rnd.NextDouble() * 10);
            }
        }

        #endregion

        #region 天気取得
        private async Task UpdateWeatherAsync() {
            string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true&hourly=relativehumidity_2m,weathercode";
            using var http = new HttpClient();
            try {
                var response = await http.GetFromJsonAsync<OpenMeteoResponse>(url);
                if (response?.current_weather != null) {
                    Dispatcher.Invoke(() => {
                        double temp = response.current_weather.temperature;
                        double wind = response.current_weather.windspeed;
                        double humidity = 0;

                        if (response.hourly?.relativehumidity_2m != null && response.hourly.relativehumidity_2m.Length > 0)
                            humidity = response.hourly.relativehumidity_2m[0];

                        TemperatureText.Text = $"{temp} ℃";
                        WindText.Text = $"風速: {wind} m/s";
                        HumidityText.Text = $"湿度: {humidity} %";
                        DateText.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
                        CityText.Text = CityInput.Text;

                        string weatherDesc = WeatherCodeToText(response.current_weather.weathercode);
                        WeatherDescText.Text = weatherDesc;

                        string iconUri = WeatherCodeToIcon(response.current_weather.weathercode);
                        WeatherIcon.Source = new BitmapImage(new Uri(iconUri, UriKind.RelativeOrAbsolute));
                    });
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"天気情報取得エラー: {ex.Message}");
            }
        }

        private async Task SearchPrefectureAsync() {
            string prefecture = CityInput.Text.Trim();
            if (string.IsNullOrEmpty(prefecture)) return;

            if (prefectures.TryGetValue(prefecture, out var coord)) {
                latitude = coord.lat;
                longitude = coord.lon;
                await UpdateWeatherAsync();
            } else {
                MessageBox.Show("対応している都道府県名を入力してください。");
            }
        }

        private string WeatherCodeToText(int code) {
            return code switch {
                0 => "晴れ",
                1 => "主に晴れ",
                2 => "曇りがち",
                3 => "曇り",
                61 => "小雨",
                63 => "雨",
                65 => "大雨",
                71 => "小雪",
                73 => "雪",
                75 => "大雪",
                _ => "不明"
            };
        }

        private string WeatherCodeToIcon(int code) {
            return code switch {
                0 => "Images/sunny.png",
                1 or 2 or 3 => "Images/cloudy.png",
                61 or 63 or 65 => "Images/rain.png",
                71 or 73 or 75 => "Images/snow.png",
                _ => "Images/sunny.png"
            };
        }
        #endregion
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
