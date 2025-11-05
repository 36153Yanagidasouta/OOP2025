using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;

namespace Exercise01_Forms {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Filter = null;
                openFileDialog.Filter = "テキストファイル (*.txt)|*.txt|すべてのファイル (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    string filePath = openFileDialog.FileName;
                    string fileContent = await DoLongTimeWorkAsync(filePath);
                    ViewtextBox.Text = fileContent;
                }
            }
        }

        private async Task<string> DoLongTimeWorkAsync(String filePath) {
            return await File.ReadAllTextAsync(filePath);
        }

        private void ViewtextBox_TextChanged(object sender, EventArgs e) {

        }
    }
}