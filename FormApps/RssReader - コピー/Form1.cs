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


                //RSS����͂��ĕK�v�ȗv�f���擾
                items = xdoc.Root.Descendants("item")
                     .Select(x =>
                new ItemData 
                     {   
                       Title = (string)x.Element("title"),
                       Link = (string)x.Element("link"),
                     }).ToList();
            }

            //���X�g�{�b�N�X�ɕ\��
            listboxTitles.Items.Clear();
            items.ForEach(item => listboxTitles.Items.Add(item.Title)) ;
   
        }
    }
}
