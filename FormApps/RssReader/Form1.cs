using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {



        private List<ItemData> items;
        //      private List<ItemData> link;


        public Form1() {
            InitializeComponent();
            btGoBack.Enabled = wvRssLink.CanGoBack;
            btGoForward.Enabled = wvRssLink.CanGoForward;
        }

        private async void btRssGet_Click(object sender, EventArgs e) {

            try {
                using (var hc = new HttpClient()) {

                    //       if (listboxTitles.Items.Count == 0) return;
                    XDocument xdoc = XDocument
                    .Parse(await hc.GetStringAsync(textboxUrl.Text));

                    //RSSを解析して必要な要素を取得
                    items = xdoc.Root.Descendants("item")
                         .Select(x =>
                    new ItemData {
                        Title = (string?)x.Element("title"),
                        Link = (string?)x.Element("link"),
                    }).ToList();
                }

                //リストボックスに表示
                listboxTitles.Items.Clear();
                items.ForEach(item => listboxTitles.Items.Add(item.Title));
            }
            catch (Exception) {
                return;
            }


        }//https://kyoko-np.net/index.xml



        //タイトルを選択(クリック)したときに呼ばれるイベントハンドラー
        private void listboxTitles_Click(object sender, EventArgs e) {


            if (listboxTitles.Items is not null) {
                int n = listboxTitles.SelectedIndex;
                if (n < 0) return;
                wvRssLink.Source = new Uri(items[n].Link);
            } else {
                return;
            }
            btGoBack.Enabled = false;
            btGoForward.Enabled = false;

        }

        //進ボタン
        private void btGo_Click(object sender, EventArgs e) {
            wvRssLink.GoForward();
            btGoBack.Enabled = wvRssLink.CanGoBack;
            btGoForward.Enabled = wvRssLink.CanGoForward;
        }

        //戻るボタン
        private void btBack_Click(object sender, EventArgs e) {

            wvRssLink.GoBack();
            btGoBack.Enabled = wvRssLink.CanGoBack;
            btGoForward.Enabled = wvRssLink.CanGoForward;

        }



        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
      
            GoFowardBtEnableSet();
        }

        private void GoFowardBtEnableSet() {

            btGoBack.Enabled = wvRssLink.CanGoBack;
            btGoForward.Enabled = wvRssLink.CanGoForward;

        }



        //お気に入り機能





    }
}
