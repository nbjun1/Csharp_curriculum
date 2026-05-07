using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Curriculum_2_27
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // タイマーを有効にして、現在時刻の表示を開始
            timer1.Enabled = true;
            timer1.Interval = 1000; // 1秒ごとにTickイベントを発生させる
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

        }

        // 「読込」ボタン（項番7）をダブルクリックして作成
        private void Button2_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;

            if (System.IO.File.Exists(path))
            {
                // 読み込んだテキストを label3 に代入
                label3.Text = System.IO.File.ReadAllText(path, Encoding.UTF8);
            }
            else
            {
                // エラーメッセージを表示
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
        private void Button5_Click(object sender, EventArgs e) { label4.BackColor = Color.LightGreen; }
        private void Button6_Click(object sender, EventArgs e) { label4.BackColor = Color.LightBlue; }

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

        // 項番16: PUSHボタン (Form3への遷移)
        private void Button8_Click(object sender, EventArgs e)
        {
            // Form3をインスタンス化
            using (Form3 f3 = new Form3())
            {
                // モーダルダイアログとして表示
                f3.ShowDialog();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // 現在時刻を「HH:mm:ss」形式で表示
            label5.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        // label5 の Paint イベント内
        private void Label5_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = label5.ClientRectangle;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.White,           // 1. 開始色を「白」に
                Color.Blue,            // 2. 終了色を「青」に
                LinearGradientMode.Vertical)) // 3. 方向を「垂直（上から下）」に
            {
                e.Graphics.FillRectangle(brush, rect);
            }

            TextRenderer.DrawText(
                e.Graphics,
                label5.Text,
                label5.Font,
                rect,
                Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
