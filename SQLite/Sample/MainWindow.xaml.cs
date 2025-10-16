using Sample.Data;
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

namespace Sample;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e) {
        var person = new Person() {
            Name = NameTextBox.Text,
            Phone = PhoneTextBox.Text,

        };

        string databaseName = "Persons.db";
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string databasePath = System.IO.Path.Combine(folderPath, databaseName);


        using (var connection = new SQLiteConnection(databasePath)) {
            connection.CreateTable<Person>();
            connection.Insert(person);


        }

    }
}