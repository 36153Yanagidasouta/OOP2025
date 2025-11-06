using System;
using System.Collections.Frozen;
using System.Net;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;
        //      private List<ItemData> link;

        Dictionary<string, string> rssUrlDict = new Dictionary<string, string>() {
            {"主要", "https://jp-postal-code-api.ttskch.com/api/v1/3792231.json"},
            {"国際","https://news.yahoo.co.jp/rss/categories/world.xml" },
            {"科学","http://news.yahoo.co.jp/rss/topics/science.xml" },
        };

        public Form1() {
            InitializeComponent();
            btGoBack.Enabled = wvRssLink.CanGoBack;
            btGoForward.Enabled = wvRssLink.CanGoForward;
        }

        private void Form1_Load(object sender, EventArgs e) {
            cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();
            cbUrl.SelectedIndex = -1;
            GoFowardBtEnableSet();

        }


        private async void btRssGet_Click(object sender, EventArgs e) {
            string url = cbUrl.Text;



            try {
                using (var hc = new HttpClient()) {

                    //       if (listboxTitles.Items.Count == 0) return;
                    XDocument xdoc = XDocument
                    .Parse(await hc.GetStringAsync(url));

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
                items.ForEach(item => listboxTitles.Items.Add(item.Title ?? "データなし"));
            }
            catch (Exception ex) {
                MessageBox.Show("URLが入ってないっすね");
                return;
            }

        }

        private string getRssUrl(string str) {

            if (rssUrlDict.ContainsKey(str)) {
                return rssUrlDict[str];

            }
            return str;
        }


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

        private void textboxUrl_SelectedIndexChanged(object sender, EventArgs e) {

            var url = cbUrl;

        }

        //お気に入り機能
        private void btfavorite_Click(object sender, EventArgs e) {

            var url = cbUrl.Text;
            var title = textboxUrl.Text;
            rssUrlDict.Add(title, url);
            cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();
            cbUrl.SelectedIndex = -1;
        }


        //お気に入り削除機能
        private void delbt_Click(object sender, EventArgs e) {

            var title = cbUrl.Text;
            if (rssUrlDict.ContainsKey(title)) {
                rssUrlDict.Remove(title);


                cbUrl.DataSource = null;
                cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();

                cbUrl.SelectedIndex = -1;
                MessageBox.Show($"{title} のお気に入りを削除しました");
            } else {
                MessageBox.Show("選択されたタイトルがなし");
            }
        }

        private void listboxTitles_DrawItem(object sender, DrawItemEventArgs e) {
            var idx = e.Index;                                                      //描画対象の行
            if (idx == -1) return;                                                  //範囲外なら何もしない
            var sts = e.State;                                                      //セルの状態
            var fnt = e.Font;                                                       //フォント
            var _bnd = e.Bounds;                                                    //描画範囲(オリジナル)
            var bnd = new RectangleF(_bnd.X, _bnd.Y, _bnd.Width, _bnd.Height);     //描画範囲(描画用)
            var txt = (string)listboxTitles.Items[idx];                                  //リストボックス内の文字
            var bsh = new SolidBrush(listboxTitles.ForeColor);                           //文字色
            var sel = (DrawItemState.Selected == (sts & DrawItemState.Selected));   //選択行か
            var odd = (idx % 2 == 1);                                               //奇数行か
            var fore = Brushes.Coral;                                         //偶数行の背景色
            var bak = Brushes.DarkViolet;                                           //奇数行の背景色

            e.DrawBackground();                                                     //背景描画

            //奇数項目の背景色を変える（選択行は除く）
            if (odd && !sel) {
                e.Graphics.FillRectangle(bak, bnd);
            } else if (!odd && !sel) {
                e.Graphics.FillRectangle(fore, bnd);
            }

            //文字を描画
            e.Graphics.DrawString(txt, fnt, bsh, bnd);
        }
    
    }
}
