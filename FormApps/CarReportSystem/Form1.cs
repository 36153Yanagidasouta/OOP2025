using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Drawing.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //設定クラスのインスタンスを生成
        Settings settings = new Settings();


        public Form1() {
            InitializeComponent();
            dgvRecord.DataSource = listCarReports;
        }

        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void btRecordAdd_Click(object sender, EventArgs e) {

            // if (cbAuthor.Text is null && cbCarName.Text is null) {
            if (cbAuthor.Text == string.Empty) {
                tsslbMessage.Text = "記録、または車名が未入力です";
                return;
            }

            tsslbMessage.Text = "";
            var carReport = new CarReport {
                Author = cbAuthor.Text,
                CarName = cbCarName.Text,
                Date = dtpDate.Value.Date,                  //日付
                Maker = GetRadioButtonMaker(),              //メーカー
                Report = tbReport.Text,                     //レポート
                Picture = pbPicture.Image                   //写真
            };
            listCarReports.Add(carReport);
            setCbAuthor(cbAuthor.Text);
            setCbCarName(cbCarName.Text);
            InputItemsAllClear();
        }


        private void rbNissan_CheckedChanged(object sender, EventArgs e) {

        }

        private CarReport.MakerGroup GetRadioButtonMaker() {

            if (rbToyota.Checked) {
                return CarReport.MakerGroup.トヨタ;
            } else if (rbSuzuki.Checked) {
                return CarReport.MakerGroup.スズキ;
            } else if (rbHonda.Checked) {
                return CarReport.MakerGroup.ホンダ;
            } else if (rbSubaru.Checked) {
                return CarReport.MakerGroup.スバル;
            } else if (rbImport.Checked) {
                return CarReport.MakerGroup.輸入車;
            } else {
                return CarReport.MakerGroup.その他;
            }
        }
        private void InputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;

        }

        private void dgvRecord_Click(object sender, EventArgs e) {
            if (dgvRecord.CurrentRow is null) return;

            dtpDate.Value = (DateTime)dgvRecord.CurrentRow.Cells["Data"].Value;
            cbAuthor.Text = (string)dgvRecord.CurrentRow.Cells["Author"].Value;
            cbCarName.Text = (string)dgvRecord.CurrentRow.Cells["CarName"].Value;
            setRadioButtonMaker((MakerGroup)dgvRecord.CurrentRow.Cells["Maker"].Value);
            tbReport.Text = (string)dgvRecord.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecord.CurrentRow.Cells["Picture"].Value;

        }
        //指定したメーカーのラジオボタンをセット
        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {

            switch (targetMaker) {
                case CarReport.MakerGroup.なし:
                    break;
                case CarReport.MakerGroup.スズキ:
                    break;
                case CarReport.MakerGroup.ホンダ:
                    break;
                case CarReport.MakerGroup.スバル:
                    break;
                case CarReport.MakerGroup.輸入車:
                    break;
                case CarReport.MakerGroup.その他:
                    break;
                default:
                    break;
            }
        }
        //記録者の履歴をコンボボックスへ登録（重複なし）

        private void setCbAuthor(string author) {
            //すでに登録済みか確認
            if (!cbAuthor.Items.Contains(author)) {
                //未登録なら登録(登録済なら登録なし)
                cbAuthor.Items.Add(author);
            }
        }

        //車名の履歴をコンボボックスへ登録(重複なし)

        private void setCbCarName(string carName) {

            if (!cbCarName.Items.Contains(carName)) {
                //未登録なら登録(登録済なら登録なし)
                cbCarName.Items.Add(carName);
            }
        }

        private void btNewRecord_Click(object sender, EventArgs e) {
            //新規入力
            InputItemsAllClear();
        }

        private void btRecordDelete_Click(object sender, EventArgs e) {

            if (dgvRecord.CurrentRow is null) {
                return;
            }
            //削除ボタン
            int index = dgvRecord.CurrentRow.Index;
            listCarReports.RemoveAt(index);
        }

        private const string settingFilePath = "setting.xml";


        private void Form1_Load(object sender, EventArgs e) {

            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.Red;

            //設定ファイルを読み込み背景色を作成
            //P286以降を参考にする(ファイル名setting.XML)



            if (File.Exists(settingFilePath)) {
                using (var reader = XmlReader.Create(settingFilePath)) { //settings.XMLをOOP2025から読むじゃん
                    var serializer = new XmlSerializer(typeof(Settings));
                    var settingData = serializer.Deserialize(reader) as Settings; //読んできたデータをsettingDataに入れる
                    settings = settingData ?? new Settings();   //settingsにsettingDataを入れる時にnullかもしれないから??とnullだった場合の処理を入れる
                    this.BackColor = Color.FromArgb(settings.MainFormBackColor);　//BackColorとsettingsの型を合わせるて完成
                    //C:\Users\infosys\source\repos\OOP2025\FormApps\CarReportSystem\bin\Debug\net8.0-windows
                }
            }
        }

        private void btRecordModify_Click(object sender, EventArgs e) {
            //修正ボタン
            //if (dgvRecord.CurrentRow is null) {
            //    return;
            //}

            if (dgvRecord.Rows.Count == 0) return;

            var carReport = new CarReport {
                Author = cbAuthor.Text,
                CarName = cbCarName.Text,
                Date = dtpDate.Value.Date,                  //日付
                Maker = GetRadioButtonMaker(),              //メーカー
                Report = tbReport.Text,                     //レポート
                Picture = pbPicture.Image                   //写真

            };

            int index = dgvRecord.CurrentRow.Index;
            listCarReports[index] = carReport;
            dgvRecord.Refresh();

        }

        private void tsmiExit_Click(object sender, EventArgs e) {

            //Application.Exit();

            Close();

        }

        private void tsmiAbout_Click(object sender, EventArgs e) {

            fmVersion fmv = new fmVersion();
            fmv.ShowDialog();

        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {

            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
                //設定ファイルへ保存
                settings.MainFormBackColor = cdColor.Color.ToArgb(); //背景色を設定インスタンスへ設定

            }
        }

        //ファイルオープン処理
        private void reportOpenfile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む

#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(
                        ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {

                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;

                        cbAuthor.Items.Clear();
                        cbCarName.Items.Clear();
                        //コンボボックスに登録
                        foreach (var report in listCarReports) {
                            setCbAuthor(report.Author);
                            setCbCarName(report.CarName);
                        }
                    }
                }
                catch (Exception) {
                    tsslbMessage.Text = "ファイル形式が違います";

                }
            }
        }

        //ファイルセーブ処理
        private void reportSaveFile() {

            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011

                    using (FileStream fs = File.Open(
                                   sfdReportFileSave.FileName, FileMode.Create)) {

                        bf.Serialize(fs, listCarReports);
                    }

                }
                catch (Exception) {
                    tsslbMessage.Text = "ファイル書き出しエラー";
                }

            }

        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();

        }

        private void ファイルFToolStripMenuItem1_Click(object sender, EventArgs e) {

            reportOpenfile();


        }

        //フォームが閉じたら呼ばれる
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルへ色情報を保存する処理(シリアル化)

            using (var writer = XmlWriter.Create(settingFilePath)) { //シリアル化するじゃん
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer, settings);
            }
        }
    }
}
