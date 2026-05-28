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

            // 定期実行（Tickイベント）時の処理を紐付け
            timer1.Tick += Timer1_Tick;

            // 1秒ごとにTickイベントを発生させる（間隔を先に設定）
            timer1.Interval = 1000;

            // タイマーを有効にして、現在時刻の表示を開始（最後にスイッチを入れる）
            timer1.Enabled = true;
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

        // --- 項番7: 読込ボタン ---
        private void Button2_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;

            // 未入力（スペースのみ含む）の制限と、ファイルの実在確認
            if (!string.IsNullOrWhiteSpace(path) && System.IO.File.Exists(path))
            {
                try
                {
                    // ファイルの内容を読み込んで、label3に表示
                    label3.Text = System.IO.File.ReadAllText(path, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    // ファイルロックや権限エラーによる異常終了を防ぐための例外処理、システム生成のエラー文（ex.Message）を出力
                    MessageBox.Show(ex.Message, Message_manage.Title4);
                }
            }
            else
            {
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
                using (Form2 f2 = new Form2(label3.Text))
                {
                    // 画面が正常（OK）に閉じられた場合のみデータを受け取るガード処理
                    if (f2.ShowDialog() == DialogResult.OK)
                    {
                        // Form2から返ってきた内容をラベルに表示
                        label4.Text = f2.ReturnValue;
                    }
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e) { label4.BackColor = Color.Yellow; }
        private void Button5_Click(object sender, EventArgs e) { label4.BackColor = Color.LightGreen; }
        private void Button6_Click(object sender, EventArgs e) { label4.BackColor = Color.LightBlue; }

        // --- 項番14: ファイル更新ボタン ---
        private void Button7_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;

            // パス未選択の状態で書き込み処理が実行されるのを防ぐガード処理
            if (string.IsNullOrWhiteSpace(path))
            {
                // 既存の共通変数（Msg2）を流用
                MessageBox.Show(Message_manage.Msg2, Message_manage.Title4);
                return;
            }

            try
            {
                System.IO.File.WriteAllText(path, label4.Text, Encoding.UTF8);
                MessageBox.Show(Message_manage.Msg3, Message_manage.Title2);
            }
            catch (Exception ex)
            {
                // 書き込み失敗時の例外処理（動的なシステムエラー内容を表示）
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