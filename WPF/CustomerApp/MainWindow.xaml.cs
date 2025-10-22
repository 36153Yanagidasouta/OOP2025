using CustomerApp.Data;
using Microsoft.VisualBasic;
using SQLite;
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

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    private List<Customer> _customers = new List<Customer>();

    public MainWindow() {
        InitializeComponent();
        ReadDatabase();
        PersonListView.ItemsSource = _customers;
    }

    private void ReadDatabase() {
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            _customers = connection.Table<Customer>().ToList();
        }
    }

    //削除ボタン
    private void DeleteButton_Click(object sender, RoutedEventArgs e) {
        var item = PersonListView.SelectedItem as Customer;

        if (item == null) {
            MessageBox.Show("選択なし");
            return;
        }

        //データベース接続
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Delete(item);
            ReadDatabase();
            PersonListView.ItemsSource = _customers;
        }
    }

    //更新ボタン
    private void UpdateButton_Click(object sender, RoutedEventArgs e) {

        var selectedPerson = PersonListView.SelectedItem as Customer;
        if (selectedPerson is null) return;


        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();

            var person = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddresTextBox.Text,
            };
            connection.Update(person);
            ReadDatabase();
            PersonListView.ItemsSource = _customers;
        }
    }


    //新規登録ボタン
    private void SaveButton_Click(object sender, RoutedEventArgs e) {

        var person = new Customer() {
            Name = NameTextBox.Text,
            Phone = PhoneTextBox.Text,
            Address = AddresTextBox.Text
        };
    }


    private void Button_Selected(object sender, RoutedEventArgs e) {

    }

    //画像保存ボタン
    private void ImageButton_Click(object sender, RoutedEventArgs e) {
        ReadDatabase();
        PersonListView.ItemsSource = _customers;

    }
}