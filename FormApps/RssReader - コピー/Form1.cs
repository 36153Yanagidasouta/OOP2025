using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;
      //  private List<ItemData> link;


        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {

            using (var hc = new HttpClient()) {

                XDocument xdoc =  XDocument
                .Parse (await hc.GetStringAsync(textboxUrl.Text));


                //RSSを解析して必要な要素を取得
                items = xdoc.Root.Descendants("item")
                     .Select(x =>
                new ItemData 
                     {   
                       Title = (string)x.Element("title"),
                       Link = (string)x.Element("link"),
                     }).ToList();
            }

            //リストボックスに表示
            listboxTitles.Items.Clear();
            items.ForEach(item => listboxTitles.Items.Add(item.Title)) ;
   
        }
    }
}
