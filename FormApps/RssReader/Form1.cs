using System.Net;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        public Form1() {
            InitializeComponent();
        }

        private void btRssGet_Click(object sender, EventArgs e) {

            using (var wc = new WebClient()) {
                var url = wc.OpenRead(textboxUrl.Text);
                XDocument xdoc = XDocument.Load(url); //RSS�̎擾


                items = xdoc.Root.Descendants("item")
                     .Select(x =>
                     new ItemData {
                         Title = (string)x.Element("title"),
                     }).ToList();
            }

            foreach (var item in items ) {

                listboxTitles.Items.Add(item.Title).ToString();

            }
        }
    }
}
