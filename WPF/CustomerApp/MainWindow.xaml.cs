using CustomerApp.Data;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using SQLite;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomerApp;

public partial class MainWindow : Window {
    private List<Customer> _customers = new List<Customer>();
    private byte[]? _tempImageBytes = null;

    public MainWindow() {
        InitializeComponent();
        ReadDatabase();
        CustomerListView.ItemsSource = _customers;
    }

    private void ReadDatabase() {
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            _customers = connection.Table<Customer>().ToList();
        }
    }

    // 削除ボタン
    private void DeleteButton_Click(object sender, RoutedEventArgs e) {
        var item = CustomerListView.SelectedItem as Customer;

        if (item == null) {
            MessageBox.Show("選択なし");
            return;
        }

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Delete(item);
            ReadDatabase();
            CustomerListView.ItemsSource = _customers;
        }
    }

    // 更新ボタン
    private void UpdateButton_Click(object sender, RoutedEventArgs e) {

        var selectedCustomers = CustomerListView.SelectedItem as Customer;
        if (selectedCustomers is null) {
            MessageBox.Show("顧客を選択してください。");
            return;
        }

        var personToUpdate = new Customer() {
            Id = selectedCustomers.Id,
            Name = NameTextBox.Text,
            Phone = PhoneTextBox.Text,
            Address = AddressTextBox.Text,
            Picture = _tempImageBytes ?? selectedCustomers.Picture
        };

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();

            int rowsAffected = connection.Update(personToUpdate);

            if (rowsAffected > 0) {
                MessageBox.Show($"{personToUpdate.Name} の情報を更新しました。");
                _tempImageBytes = null;
                ReadDatabase();
                CustomerListView.ItemsSource = _customers;
            } else {
                MessageBox.Show("更新に失敗しました。");
            }
        }
    }


    // 新規登録ボタン
    private void SaveButton_Click(object sender, RoutedEventArgs e) {

        var newCustomers = new Customer() {
            Name = NameTextBox.Text,
            Phone = PhoneTextBox.Text,
            Address = AddressTextBox.Text,
            Picture = _tempImageBytes
            
        };

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();

            int rowsAffected = connection.Insert(newCustomers);
            _tempImageBytes = null;
            ReadDatabase();
            CustomerListView.ItemsSource = _customers;
        }
    }



    private void Button_Selected(object sender, RoutedEventArgs e) {

        var selectedCustomer = CustomerListView.SelectedItem as Customer;
        if (selectedCustomer != null) {
            NameTextBox.Text = selectedCustomer.Name;
            PhoneTextBox.Text = selectedCustomer.Phone;
            AddressTextBox.Text = selectedCustomer.Address;
            ImageWindow.Source = ByteArrayToBitmapImage(selectedCustomer.Picture);
            _tempImageBytes = null;
        }
    }

    // 画像保存ボタン
    private void ImageButton_Click(object sender, RoutedEventArgs e) {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
        if (openFileDialog.ShowDialog() == true) {
            try {
                byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);

                _tempImageBytes = imageBytes;

                ImageWindow.Source = ByteArrayToBitmapImage(imageBytes);

                MessageBox.Show($"新規保存または更新ボタンを押ししてください。");
            }
            catch (Exception ex) {
                MessageBox.Show($"ファイルの読み込みエラー: {ex.Message}");
            }
        }
    }


    private BitmapImage? ByteArrayToBitmapImage(byte[]? byteArray) {
        if (byteArray == null || byteArray.Length == 0) return null;
        try {
            using (var stream = new MemoryStream(byteArray)) {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
                image.Freeze();
                return image;
            }
        }
        catch (Exception) {
            return null;
        }
    }


    private void GridListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        var selectedCustomer = CustomerListView.SelectedItem as Customer;
        if (selectedCustomer is null) return;
        NameTextBox.Text = selectedCustomer.Name;PhoneTextBox.Text = selectedCustomer.Phone;
        AddressTextBox.Text = selectedCustomer.Address;
        ImageWindow.Source = ByteArrayToBitmapImage(selectedCustomer.Picture);


    }
}