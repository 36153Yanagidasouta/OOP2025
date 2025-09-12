using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {

            InitializeComponent();
            DataContext = GetColorList();

        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }


        //スライダー
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {

            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            Color newColor = Color.FromRgb(r, g, b);
            colorArea.Background = new SolidColorBrush(newColor);



        }


        //ストックボタンクリック
        private void stockButton_Click(object sender, RoutedEventArgs e) {

            Color currentColor = ((SolidColorBrush)colorArea.Background).Color;
            var myColor = new MyColor() {
                Color = currentColor,
                Name = $"RGB({currentColor.R}, {currentColor.G}, {currentColor.B})"


            };

            if (!ColorList.Items.Cast<MyColor>().Any(c => c.Color == myColor.Color)) {
                ColorList.Items.Add(myColor);
            } else {
                MessageBox.Show("重複してるよ", "不満", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }


        //コンボボックス色選択
        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (!(((ComboBox)sender).SelectedItem is MyColor selectedMyColor)) {
                return;
            }
            setSliderValue(selectedMyColor.Color);

            if (!ColorList.Items.Cast<MyColor>().Any(c => c.Color.Equals(selectedMyColor.Color))) {
                ColorList.Items.Add(selectedMyColor);

            }
        }

        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;

        }

        //カラーリストから選択(ダブルクリック)
        private void ColorList_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            if (ColorList.SelectedItem is MyColor selectedMyColor) {
                Color selectedColor = selectedMyColor.Color;
                setSliderValue(selectedColor);
                colorArea.Background = new SolidColorBrush(selectedColor);
                ColorSelectComboBox.SelectedItem = selectedMyColor;
            }
        }



        //削除ボタン
        private void Deletebutton_Click(object sender, RoutedEventArgs e) {
            if (ColorList.SelectedItem != null) {
                int sel = ColorList.SelectedIndex;
                ColorList.Items.RemoveAt(sel);
            } else {
                MessageBox.Show("選択されてないよ", "不満", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }



        //オールクリアボタン
        private void Allclearbutton_Click(object sender, RoutedEventArgs e) {

        }

        private void Allclearbutton_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            MessageBoxResult result = MessageBox.Show("本当に消しますか?", "確認", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            if (result == MessageBoxResult.OK) {
                ColorList.Items.Clear();
            }
        }
    }
}