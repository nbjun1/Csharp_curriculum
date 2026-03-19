using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curriculum_2_26
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ボタンクリックイベント
        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            // 入力があるか確認
            if (string.IsNullOrWhiteSpace(txtInput2.Text))
            {
                lblMessage.Text = "からっぽ";
                lblMessage.ForeColor = Color.Yellow;
                return;
            }

            // 入力がある場合はチェック用メソッドを呼び出し
            CheckInputContent(txtInput2.Text);
        }

        // 入力内容チェック用のメソッド
        private void CheckInputContent(string input)
        {
            bool hasMountain = input.Contains("山");
            bool hasSea = input.Contains("海");

            // 条件判定（両方含まれるケースを最優先にする）
            if (hasMountain && hasSea)
            {
                lblMessage.Text = "どちらも含まれている";
                lblMessage.ForeColor = Color.Red;
            }
            else if (hasMountain)
            {
                lblMessage.Text = "山が含まれている";
                lblMessage.ForeColor = Color.Green;
            }
            else if (hasSea)
            {
                lblMessage.Text = "海が含まれている";
                lblMessage.ForeColor = Color.Blue;
            }
            else
            {
                lblMessage.Text = "どちらも含まれてない";
                lblMessage.ForeColor = Color.Black;
            }
        }
    }
}
