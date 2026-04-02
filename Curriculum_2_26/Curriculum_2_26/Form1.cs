using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Curriculum_2_26
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // --- 課題１の処理 ---

        // ボタン１（課題１）クリック時
        private void button1_Click(object sender, EventArgs e)
        {
            // 数値に変換できるかチェック
            if (int.TryParse(textBox1.Text, out int num))
            {
                bool isEven = num % 2 == 0; // 2の倍数か判定

                if (num < 5)
                {
                    label1.Text = isEven ? "5より小さい2の倍数" : "5より小さい2の倍数ではない";
                }
                else
                {
                    label1.Text = isEven ? "5以上　2の倍数" : "5以上　2の倍数ではない";
                }
            }
            else
            {
                label1.Text = "数値を入力してください";
            }
        }

        // 入力制限：数値のみ（textBox1のKeyPressイベントに紐付け）
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 0-9の数字、およびバックスペース以外の入力を無効化する
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        // --- 課題２の処理 ---

        // ボタン２（課題２）クリック時
        private void button2_Click(object sender, EventArgs e)
        {
            // 入力があるか確認
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                label2.Text = "からっぽ";
                label2.ForeColor = Color.Yellow;
            }
            else
            {
                // 入力がある場合はチェック用メソッドを呼び出し
                CheckInputContent(textBox2.Text);
            }
        }

        // 入力内容チェック用のメソッド
        private void CheckInputContent(string input)
        {
            bool hasMountain = input.Contains("山");
            bool hasSea = input.Contains("海");

            // 条件判定（両方含まれるケースを最優先にするのがコツです！）
            if (hasMountain && hasSea)
            {
                label2.Text = "どちらも含まれている";
                label2.ForeColor = Color.Red;
            }
            else if (hasMountain)
            {
                label2.Text = "山が含まれている";
                label2.ForeColor = Color.Green;
            }
            else if (hasSea)
            {
                label2.Text = "海が含まれている";
                label2.ForeColor = Color.Blue;
            }
            else
            {
                label2.Text = "どちらも含まれてない";
                label2.ForeColor = Color.Black;
            }
        }
    }
}