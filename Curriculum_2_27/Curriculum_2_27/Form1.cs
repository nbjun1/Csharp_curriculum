using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Curriculum_2_27
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // タイトルを設定
                ofd.Title = Message_manage.Title1; // 「開くファイルを選択してください」
                // ファイルが選択されたら
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // テキストボックス（項番4）にパスを表示
                    textBox1.Text = ofd.FileName; // パスをテキストボックスに表示
                }
            }

            string path = textBox1.Text;

            if (System.IO.File.Exists(path))
            {
                // ファイルを全て読み込んでラベルに表示
                label3.Text = System.IO.File.ReadAllText(path, Encoding.UTF8);
            }
            else
            {
                // エラーメッセージを表示[cite: 1]
                MessageBox.Show(Message_manage.Msg2, Message_manage.Title4);
            }
        }



        // 「読込」ボタン（項番7）をダブルクリックして作成
        private void Button2_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;

            if (System.IO.File.Exists(path))
            {
                // ファイル内容をラベル（項番5）に表示
                label3.Text = System.IO.File.ReadAllText(path, System.Text.Encoding.UTF8);
            }
            else
            {
                // 「ファイルまたはフォルダが存在しません」を表示
                MessageBox.Show(Message_manage.Msg2, Message_manage.Title4);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            // 確認ダイアログを表示
            DialogResult result = MessageBox.Show(Message_manage.Msg1, Message_manage.Title3, MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                // Form2を生成。コンストラクタでlabel3のテキストを渡す
                // ※Form2側のコンストラクタ改造が必要です
                using (Form2 f2 = new Form2(label3.Text))
                {
                    f2.ShowDialog(); // モーダルで表示

                    // Form2が閉じられた後、21のテキストボックスの内容を10のラベルに表示
                    // ※Form2側に公開プロパティ（ReturnValue等）を作る必要があります
                    label4.Text = f2.ReturnValue;
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e) { label4.BackColor = Color.Yellow; }
        private void Button5_Click(object sender, EventArgs e) { label4.BackColor = Color.Green; }
        private void Button6_Click(object sender, EventArgs e) { label4.BackColor = Color.Blue; }

        private void Button7_Click(object sender, EventArgs e)
        {
            try
            {
                string path = textBox1.Text;
                // label4の内容で上書き
                System.IO.File.WriteAllText(path, label4.Text, Encoding.UTF8);

                // 完了メッセージ「ファイルを上書きしました」
                MessageBox.Show(Message_manage.Msg3, Message_manage.Title2);
            }
            catch (Exception ex)
            {
                // 書き込み失敗時のエラー表示
                MessageBox.Show(ex.Message, Message_manage.Title4);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // 現在時刻を「HH:mm:ss」形式で表示
            label5.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
