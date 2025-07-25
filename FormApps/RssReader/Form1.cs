using System;
using System.Collections.Frozen;
using System.Net;
using System.Security.Policy;
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
            {"��v", "https://news.yahoo.co.jp/rss/topics/top-picks.xml"},
            {"����","https://news.yahoo.co.jp/rss/categories/world.xml" },
            {"�Ȋw","http://news.yahoo.co.jp/rss/topics/science.xml" },
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

            if (rssUrlDict.ContainsKey(cbUrl.Text)) {
                url = rssUrlDict[cbUrl.Text];
            }

            try {
                using (var hc = new HttpClient()) {

                    //       if (listboxTitles.Items.Count == 0) return;
                    XDocument xdoc = XDocument
                    .Parse(await hc.GetStringAsync(url));

                    //RSS����͂��ĕK�v�ȗv�f���擾
                    items = xdoc.Root.Descendants("item")
                         .Select(x =>
                    new ItemData {
                        Title = (string?)x.Element("title"),
                        Link = (string?)x.Element("link"),
                    }).ToList();

                }

                //���X�g�{�b�N�X�ɕ\��
                listboxTitles.Items.Clear();
                items.ForEach(item => listboxTitles.Items.Add(item.Title ?? "�f�[�^�Ȃ�"));
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return;
            }

        }





        private string getRssUrl(string str) {

            if (rssUrlDict.ContainsKey(str)) {
                return rssUrlDict[str];

            }
            return str;
        }


        //�^�C�g����I��(�N���b�N)�����Ƃ��ɌĂ΂��C�x���g�n���h���[
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

        //�i�{�^��
        private void btGo_Click(object sender, EventArgs e) {
            wvRssLink.GoForward();
            btGoBack.Enabled = wvRssLink.CanGoBack;
            btGoForward.Enabled = wvRssLink.CanGoForward;
        }

        //�߂�{�^��
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





        }

        //���C�ɓ���@�\
        private void btfavorite_Click(object sender, EventArgs e) {

            var url = cbUrl.Text;
            var title = textboxUrl.Text;
            rssUrlDict.Add(title, url);
            cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();
        }


        //���C�ɓ���폜�@�\
        private void delbt_Click(object sender, EventArgs e) {
           
            var title = cbUrl.Text;           
            if (rssUrlDict.ContainsKey(title)) {
                rssUrlDict.Remove(title);

               
                cbUrl.DataSource = null; 
                cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();

                cbUrl.SelectedIndex = -1;
                MessageBox.Show($"{title} �̂��C�ɓ�����폜���܂���");
            } else {
                MessageBox.Show("�I�����ꂽ�^�C�g�����Ȃ�");
            }
        }
    }
}
