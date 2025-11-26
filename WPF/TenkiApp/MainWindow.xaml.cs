using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace TenkiApp {
    public partial class MainWindow : Window {
        // タイマーとHTTPクライアント
        private DispatcherTimer timer;
        private static readonly HttpClient httpClient = new HttpClient();

        // 現在の位置情報
        private double currentLatitude = 35.68944;    // デフォルト：東京
        private double currentLongitude = 139.69167;
        private string currentCityName = "東京都";

        // 都道府県・市区町村データ
        private Dictionary<string, LocationData> locationDatabase;

        // ローディング制御
        private bool isSearching = false;

        public MainWindow() {
            InitializeComponent();

            // 初期化
            httpClient.Timeout = TimeSpan.FromSeconds(10);
            locationDatabase = new Dictionary<string, LocationData>();

            // イベント設定
            Loaded += MainWindow_Loaded;
            SearchButton.Click += SearchButton_Click;
            CityInput.KeyDown += CityInput_KeyDown;
        }

        #region 初期化・起動時処理
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            // CSVデータ読み込み
            LoadLocationDatabase();

            // 初期表示
            CityText.Text = currentCityName;

            // 最初の天気取得
            await UpdateWeatherDataAsync();

            // 自動更新タイマー開始（5分間隔）
            StartAutoUpdateTimer();
        }

        private void LoadLocationDatabase() {
            string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "prefecture_list.csv");

            if (!File.Exists(csvPath)) {
                ShowWarning($"CSVファイルが見つかりません: {csvPath}\n\nデフォルトデータを使用します。");
                LoadDefaultLocations();
                return;
            }

            try {
                var lines = File.ReadAllLines(csvPath, Encoding.UTF8);
                int loadedCount = 0;

                // ヘッダー行をスキップ（1行目）
                for (int i = 1; i < lines.Length; i++) {
                    string line = lines[i].Trim();
                    if (string.IsNullOrEmpty(line)) continue;

                    var parts = line.Split(',');
                    if (parts.Length >= 3) {
                        string name = parts[0].Trim();

                        if (double.TryParse(parts[1].Trim(), out double lat) &&
                            double.TryParse(parts[2].Trim(), out double lon)) {

                            var location = new LocationData {
                                FullName = name,
                                Latitude = lat,
                                Longitude = lon
                            };

                            // 複数のキーで登録
                            RegisterLocation(name, location);
                            loadedCount++;
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine($"CSV読み込み完了: {loadedCount}件の地名を登録");
                System.Diagnostics.Debug.WriteLine($"検索可能な名前: {locationDatabase.Count}パターン");

            }
            catch (Exception ex) {
                ShowWarning($"CSVの読み込みエラー: {ex.Message}\n\nデフォルトデータを使用します。");
                LoadDefaultLocations();
            }

            // データが空の場合
            if (locationDatabase.Count == 0) {
                LoadDefaultLocations();
            }
        }

        private void RegisterLocation(string fullName, LocationData location) {
            // 1. フルネームで登録（例: 群馬県太田市）
            AddToDictionary(fullName, location);

            // 2. 都道府県と市区町村を分離
            string prefecture = "";
            string city = "";

            if (fullName.StartsWith("北海道")) {
                prefecture = "北海道";
                city = fullName.Substring(3);
            } else {
                // 都道府県を抽出
                foreach (var suffix in new[] { "県", "都", "府" }) {
                    int idx = fullName.IndexOf(suffix);
                    if (idx > 0) {
                        prefecture = fullName.Substring(0, idx + 1);
                        city = fullName.Substring(idx + 1);
                        break;
                    }
                }
            }

            // 3. 都道府県のみで登録（例: 群馬県）
            if (!string.IsNullOrEmpty(prefecture) && string.IsNullOrEmpty(city)) {
                AddToDictionary(prefecture, location);

                // 短縮形も登録（例: 群馬）
                string prefShort = prefecture.Replace("県", "").Replace("都", "").Replace("府", "");
                AddToDictionary(prefShort, location);
            }

            // 4. 市区町村名で登録（例: 太田市）
            if (!string.IsNullOrEmpty(city)) {
                AddToDictionary(city, location);

                // 市区町村の短縮形も登録（例: 太田）
                string cityShort = city
                    .Replace("市", "")
                    .Replace("区", "")
                    .Replace("町", "")
                    .Replace("村", "");

                if (!string.IsNullOrEmpty(cityShort) && cityShort != city) {
                    AddToDictionary(cityShort, location);
                }
            }

            // 5. 都道府県+市区町村短縮形（例: 群馬太田）
            if (!string.IsNullOrEmpty(prefecture) && !string.IsNullOrEmpty(city)) {
                string prefShort = prefecture.Replace("県", "").Replace("都", "").Replace("府", "");
                string cityShort = city.Replace("市", "").Replace("区", "").Replace("町", "").Replace("村", "");

                if (!string.IsNullOrEmpty(cityShort)) {
                    AddToDictionary(prefShort + cityShort, location);
                }
            }
        }

        private void AddToDictionary(string key, LocationData location) {
            if (!string.IsNullOrEmpty(key) && !locationDatabase.ContainsKey(key)) {
                locationDatabase[key] = location;
                System.Diagnostics.Debug.WriteLine($"  登録: {key} → {location.FullName}");
            }
        }

        private void LoadDefaultLocations() {
            var defaultData = new Dictionary<string, (double lat, double lon)> {
                { "東京都", (35.68944, 139.69167) },
                { "大阪府", (34.68639, 135.52) },
                { "北海道", (43.06417, 141.34694) },
                { "愛知県", (35.18028, 136.90667) },
                { "福岡県", (33.60639, 130.41806) }
            };

            foreach (var item in defaultData) {
                var location = new LocationData {
                    FullName = item.Key,
                    Latitude = item.Value.lat,
                    Longitude = item.Value.lon
                };
                RegisterLocation(item.Key, location);
            }
        }
        #endregion

        #region 検索機能
        private async void SearchButton_Click(object sender, RoutedEventArgs e) {
            await SearchLocationAsync();
        }

        private async void CityInput_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.Enter) {
                await SearchLocationAsync();
            }
        }

        private async Task SearchLocationAsync() {
            string input = CityInput.Text.Trim();

            if (string.IsNullOrEmpty(input)) {
                ShowInfo("都道府県名または市区町村名を入力してください。");
                return;
            }

            if (isSearching) return;
            isSearching = true;

            try {
                // ローカルデータベースで検索
                if (locationDatabase.TryGetValue(input, out LocationData location)) {
                    System.Diagnostics.Debug.WriteLine($"検索成功: {input} → {location.FullName} ({location.Latitude}, {location.Longitude})");

                    currentLatitude = location.Latitude;
                    currentLongitude = location.Longitude;
                    currentCityName = location.FullName;
                    CityText.Text = currentCityName;

                    await UpdateWeatherDataAsync();
                    return;
                }

                // ローカルデータベースになければGeocoding APIを使用
                System.Diagnostics.Debug.WriteLine($"ローカルDBに見つからず、APIで検索: {input}");

                string geocodeUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(input)}&count=5&language=ja&format=json";
                var response = await httpClient.GetFromJsonAsync<GeocodingResponse>(geocodeUrl);

                if (response?.results != null && response.results.Length > 0) {
                    // 日本の結果を優先
                    var result = response.results.FirstOrDefault(r => r.country_code == "JP")
                                 ?? response.results[0];

                    currentLatitude = result.latitude;
                    currentLongitude = result.longitude;
                    currentCityName = result.name ?? input;
                    CityText.Text = currentCityName;

                    System.Diagnostics.Debug.WriteLine($"API検索成功: {currentCityName} ({currentLatitude}, {currentLongitude})");

                    await UpdateWeatherDataAsync();
                } else {
                    ShowWarning($"「{input}」の位置情報が見つかりませんでした。\n\n別の名前で試してください。");
                }

            }
            catch (Exception ex) {
                ShowError($"検索エラー: {ex.Message}");
            }
            finally {
                isSearching = false;
            }
        }
        #endregion

        #region 天気情報取得・表示
        private async Task UpdateWeatherDataAsync() {
            // API URLに UV指数取得パラメータ daily=uv_index_max を追加
            string apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={currentLatitude}&longitude={currentLongitude}&current_weather=true&hourly=relativehumidity_2m&daily=uv_index_max&timezone=Asia/Tokyo";

            // まず表示をクリア/初期化
            TemperatureText.Text = "-- ℃";
            WindText.Text = "-- m/s";
            HumidityText.Text = "-- %";
            UVIndexText.Text = "測定中"; // 初期値を設定
            ClothingAdviceText.Text = "取得中...";
            WeatherDescText.Text = "取得中";

            try {
                System.Diagnostics.Debug.WriteLine($"天気API呼び出し: {currentCityName} ({currentLatitude}, {currentLongitude})");

                var response = await httpClient.GetFromJsonAsync<OpenMeteoResponse>(apiUrl);

                if (response?.current_weather != null) {
                    // 気温
                    double temp = response.current_weather.temperature;
                    TemperatureText.Text = $"{temp:F1} ℃";

                    // 風速
                    double wind = response.current_weather.windspeed;
                    WindText.Text = $"{wind:F1} m/s";

                    // 湿度
                    double humidity = 0;
                    if (response.hourly?.relativehumidity_2m != null && response.hourly.relativehumidity_2m.Length > 0) {
                        // 湿度データを取得（現在時刻に最も近いデータ）
                        // Open-Meteoのhourlyデータは通常、リクエストした直近のデータから始まるため、0番目の要素を使用する
                        humidity = response.hourly.relativehumidity_2m[0];
                    }
                    HumidityText.Text = $"{humidity:F0} %";

                    // UV指数
                    double uvIndexMax = 0;
                    if (response.daily?.uv_index_max != null && response.daily.uv_index_max.Length > 0) {
                        // UV指数データを取得（当日の最大値）
                        uvIndexMax = response.daily.uv_index_max[0];
                    }
                    // UV指数は小数点第一位まで表示
                    UVIndexText.Text = $"{uvIndexMax:F1}";


                    // 日時
                    DateText.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");

                    // 天気コード
                    int weatherCode = response.current_weather.weathercode;

                    // 絵文字（WPFでは非推奨のため削除するか、XAML側で定義したWeatherIconを使用）
                    // WeatherEmojiText.Text = GetWeatherEmoji(weatherCode);

                    // 天気説明
                    WeatherDescText.Text = GetWeatherDescription(weatherCode);

                    // アイコン
                    string iconPath = GetWeatherIconPath(weatherCode);
                    try {
                        WeatherIcon.Source = new BitmapImage(new Uri(iconPath, UriKind.RelativeOrAbsolute));
                    }
                    catch {
                        WeatherIcon.Source = null;
                    }

                    System.Diagnostics.Debug.WriteLine($"天気更新完了: {temp}℃, {wind}m/s, {humidity}%, UV={uvIndexMax:F1}, code={weatherCode}");
                }

            }
            catch (HttpRequestException ex) {
                ShowError($"ネットワークエラー: {ex.Message}");
            }
            catch (TaskCanceledException) {
                ShowError("通信がタイムアウトしました。");
            }
            catch (Exception ex) {
                ShowError($"天気情報取得エラー: {ex.Message}");
            }
        }

        private string GetWeatherDescription(int code) {
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

        private string GetWeatherIconPath(int code) {
            return code switch {
                0 or 1 => "Images/sunny.png",
                2 or 3 or 45 or 48 => "Images/cloudy.png",
                51 or 53 or 55 or 61 or 63 or 65 or 80 or 81 or 82 => "Images/rain.png",
                71 or 73 or 75 or 77 or 85 or 86 => "Images/snow.png",
                95 or 96 or 99 => "Images/rain.png",
                _ => "Images/sunny.png"
            };
        }
        #endregion

        #region 自動更新タイマー
        private void StartAutoUpdateTimer() {
            timer = new DispatcherTimer {
                Interval = TimeSpan.FromMinutes(5)
            };
            timer.Tick += async (s, e) => await UpdateWeatherDataAsync();
            timer.Start();

            System.Diagnostics.Debug.WriteLine("自動更新タイマー開始: 5分間隔");
        }
        #endregion

        #region メッセージ表示
        private void ShowInfo(string message) {
            MessageBox.Show(message, "情報", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ShowWarning(string message) {
            MessageBox.Show(message, "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ShowError(string message) {
            MessageBox.Show(message, "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        #endregion

        #region クリーンアップ
        protected override void OnClosed(EventArgs e) {
            timer?.Stop();
            httpClient?.Dispose();
            base.OnClosed(e);
        }
        #endregion
    }

    #region データクラス
    // 位置情報
    public class LocationData {
        public string FullName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    // Open-Meteo 天気API
    public class OpenMeteoResponse {
        public CurrentWeather current_weather { get; set; }
        public HourlyData hourly { get; set; }
        public DailyData daily { get; set; } // DailyDataを追加
    }

    public class CurrentWeather {
        public double temperature { get; set; }
        public double windspeed { get; set; }
        public int is_day { get; set; }
        public int weathercode { get; set; }
    }

    public class HourlyData {
        public double[] relativehumidity_2m { get; set; }
    }

    // Dailyデータクラスを新しく追加
    public class DailyData {
        public double[] uv_index_max { get; set; } // UV指数
    }

    // Open-Meteo Geocoding API
    public class GeocodingResponse {
        public GeocodingResult[] results { get; set; }
    }

    public class GeocodingResult {
        public string name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
    }
    #endregion
}