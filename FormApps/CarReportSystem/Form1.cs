using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Drawing.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //�J�[���|�[�g�Ǘ��p���X�g
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

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
                tsslbMessage.Text = "�L�^�A�܂��͎Ԗ��������͂ł�";
                return;
            }

            tsslbMessage.Text = "";
            var carReport = new CarReport {
                Author = cbAuthor.Text,
                CarName = cbCarName.Text,
                Date = dtpDate.Value.Date,                  //���t
                Maker = GetRadioButtonMaker(),              //���[�J�[
                Report = tbReport.Text,                     //���|�[�g
                Picture = pbPicture.Image                   //�ʐ^
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
                return CarReport.MakerGroup.�g���^;
            } else if (rbSuzuki.Checked) {
                return CarReport.MakerGroup.�X�Y�L;
            } else if (rbHonda.Checked) {
                return CarReport.MakerGroup.�z���_;
            } else if (rbSubaru.Checked) {
                return CarReport.MakerGroup.�X�o��;
            } else if (rbImport.Checked) {
                return CarReport.MakerGroup.�A����;
            } else {
                return CarReport.MakerGroup.���̑�;
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
        //�w�肵�����[�J�[�̃��W�I�{�^�����Z�b�g
        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {

            switch (targetMaker) {
                case CarReport.MakerGroup.�Ȃ�:
                    break;
                case CarReport.MakerGroup.�X�Y�L:
                    break;
                case CarReport.MakerGroup.�z���_:
                    break;
                case CarReport.MakerGroup.�X�o��:
                    break;
                case CarReport.MakerGroup.�A����:
                    break;
                case CarReport.MakerGroup.���̑�:
                    break;
                default:
                    break;
            }
        }
        //�L�^�҂̗������R���{�{�b�N�X�֓o�^�i�d���Ȃ��j

        private void setCbAuthor(string author) {
            //���łɓo�^�ς݂��m�F
            if (!cbAuthor.Items.Contains(author)) {
                //���o�^�Ȃ�o�^(�o�^�ςȂ�o�^�Ȃ�)
                cbAuthor.Items.Add(author);
            }
        }

        //�Ԗ��̗������R���{�{�b�N�X�֓o�^(�d���Ȃ�)

        private void setCbCarName(string carName) {

            if (!cbCarName.Items.Contains(carName)) {
                //���o�^�Ȃ�o�^(�o�^�ςȂ�o�^�Ȃ�)
                cbCarName.Items.Add(carName);
            }
        }

        private void btNewRecord_Click(object sender, EventArgs e) {
            //�V�K����
            InputItemsAllClear();
        }

        private void btRecordDelete_Click(object sender, EventArgs e) {

            if (dgvRecord.CurrentRow is null) {
                return;
            }
            //�폜�{�^��
            int index = dgvRecord.CurrentRow.Index;
            listCarReports.RemoveAt(index);
        }

        private void Form1_Load(object sender, EventArgs e) {

            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.Red;

        }

        private void btRecordModify_Click(object sender, EventArgs e) {
            //�C���{�^��
            //if (dgvRecord.CurrentRow is null) {
            //    return;
            //}

            if (dgvRecord.Rows.Count == 0) return;

            var carReport = new CarReport {
                Author = cbAuthor.Text,
                CarName = cbCarName.Text,
                Date = dtpDate.Value.Date,                  //���t
                Maker = GetRadioButtonMaker(),              //���[�J�[
                Report = tbReport.Text,                     //���|�[�g
                Picture = pbPicture.Image                   //�ʐ^

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

        private void �F�ݒ�ToolStripMenuItem_Click(object sender, EventArgs e) {

            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
            }

        }

        //�t�@�C���I�[�v������
        private void reportOpenfile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //�t�V���A�����Ńo�C�i���`������荞��

#pragma warning disable SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    using (FileStream fs = File.Open(
                        ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {

                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;

                        cbAuthor.Items.Clear();
                        cbCarName.Items.Clear();
                        //�R���{�{�b�N�X�ɓo�^
                        foreach (var report in listCarReports) {
                            setCbAuthor(report.Author);
                            setCbCarName(report.CarName);
                        }
                    }
                }
                catch (Exception) {
                    tsslbMessage.Text = "�t�@�C���`�����Ⴂ�܂�";

                }
            }
        }

        //�t�@�C���Z�[�u����
        private void reportSaveFile() {

            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //�o�C�i���`���ŃV���A����
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011

                    using (FileStream fs = File.Open(
                                   sfdReportFileSave.FileName, FileMode.Create)) {

                        bf.Serialize(fs, listCarReports);
                    }

                }
                catch (Exception) {
                    tsslbMessage.Text = "�t�@�C�������o���G���[";
                }

            }

        }

        private void �ۑ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();

        }

        private void �t�@�C��FToolStripMenuItem1_Click(object sender, EventArgs e) {

            reportOpenfile();


        }
    }
}
