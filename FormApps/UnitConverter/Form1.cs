namespace UnitConverter {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, EventArgs e) {
            int inputValue = int.Parse(tbBeforeConversion.Text);

            double outputValue = inputValue * 0.0254;



            tbAfterConversion.Text = outputValue.ToString();




        }

        private void tbBeforeConversion_TextChanged(object sender, EventArgs e) {

        }
    }
}
