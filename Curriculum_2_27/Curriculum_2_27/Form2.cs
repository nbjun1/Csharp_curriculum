using System;
using System.Windows.Forms;

namespace Curriculum_2_27
{
    public partial class Form2 : Form
    {
        // Form1に戻すための値を保持するプロパティ
        public string ReturnValue { get; private set; }

        public Form2()
        {
            InitializeComponent();
        }

        // Form1からの引数を受け取るコンストラクタ
        public Form2(string sendText)
        {
            InitializeComponent();
            // 項番4のラベルに値を表示
            label3.Text = sendText;
        }

        // 項番13: 分割ボタン
        private void Button1_Click(object sender, EventArgs e)
        {
            // label3の内容を「,」で分割
            string[] splitText = label3.Text.Split(',');

            // 分割した結果を各テキストボックス（項番9～12）に配置
            // 要素が足りない場合に備えて、インデックスの範囲内かチェックして代入します
            if (splitText.Length > 0) textBox1.Text = splitText[0];
            if (splitText.Length > 1) textBox2.Text = splitText[1];
            if (splitText.Length > 2) textBox3.Text = splitText[2];
            if (splitText.Length > 3) textBox4.Text = splitText[3];
        }

        // 項番14: 空白削除A（前後空白削除）
        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Trim();
            textBox2.Text = textBox2.Text.Trim();
            textBox3.Text = textBox3.Text.Trim();
            textBox4.Text = textBox4.Text.Trim();
        }

        // 項番15: 空白削除B（全空白削除）
        private void Button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(" ", "").Replace("　", "");
            textBox2.Text = textBox2.Text.Replace(" ", "").Replace("　", "");
            textBox3.Text = textBox3.Text.Replace(" ", "").Replace("　", "");
            textBox4.Text = textBox4.Text.Replace(" ", "").Replace("　", "");
        }

        // 項番16: 形成ボタン
        private void Button4_Click(object sender, EventArgs e)
        {
            // 9～12の内容を「,」区切りで結合して21（textBox5）に表示
            string combined = string.Join(",", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            textBox5.Text = combined;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        // 項番22: Loopボタン（階段状の文字列作成）
        private void Button5_Click(object sender, EventArgs e)
        {
            // コンボボックス等から選択された数値を取得（例: numericUpDown1 や comboBox の値）
            int selectedNumber = (int)numericUpDown1.Value;

            // 結果を格納する変数（TextBoxやLabelに表示することを想定）
            string result = "";

            // 外側のループ：行数を決める（0から選択した数字まで）
            for (int i = 0; i <= selectedNumber; i++)
            {
                // 内側のループ：各行の中身を作る
                for (int j = 0; j <= i; j++)
                {
                    // 数字を順番に足していく
                    result += j.ToString();
                }

                // 1行終わるごとに改行を入れる
                result += Environment.NewLine;
            }

            // テキストボックス等に表示
            richTextBox1.Text = result;
        }

        // 項番23: Closeボタン
        private void Button6_Click(object sender, EventArgs e)
        {
            // 21のテキストボックスの内容をプロパティにセットして閉じる
            this.ReturnValue = textBox5.Text;
            this.Close();
        }

    }
}