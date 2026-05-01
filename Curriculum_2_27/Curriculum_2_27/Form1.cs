using System;
using System.Windows.Forms;

namespace Curriculum_2_27
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 「参照」ボタン（項番6）をダブルクリックして作成
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = Message_manage.Title1; // 「開くファイルを選択してください」
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = ofd.FileName; // パスをテキストボックスに表示
                }
            }
        }

        // 「読込」ボタン（項番7）をダブルクリックして作成
        private void button2_Click(object sender, EventArgs e)
        {
            string path = txtFilePath.Text;

            if (System.IO.File.Exists(path))
            {
                // ファイル内容をラベル（項番5）に表示
                lblFileContent.Text = System.IO.File.ReadAllText(path, System.Text.Encoding.UTF8);
            }
            else
            {
                // 「ファイルまたはフォルダが存在しません」を表示
                MessageBox.Show(Message_manage.Msg2, Message_manage.Title4);
            }
        }
    }
}
