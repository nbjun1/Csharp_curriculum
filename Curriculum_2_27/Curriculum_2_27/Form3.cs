using System;
using System.Drawing;
using System.Windows.Forms;

namespace Curriculum_2_27
{
    public partial class Form3 : Form
    {
        // ※1, ※2 の配列を定義（0番目は空白）
        private readonly string[] daysArray = { "", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
        private readonly string[] yearsArray = { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

        // ロード完了フラグ（初期化中の意図しないイベント発火を防ぐ）
        private bool isLoaded = false;

        public Form3()
        {
            InitializeComponent();
        }

        // --- 項番1: ロードイベント ---
        private void Form3_Load(object sender, EventArgs e)
        {
            // 1. まずフラグを false にし、初期化中のイベント動作を完全にブロック
            isLoaded = false;

            // 2. テキスト設定やコンボボックスの初期化を行う（この時点ではラベルが変わっても無視される）
            radioButton1.Text = daysArray[1];
            radioButton7.Text = daysArray[7];

            comboBox1.Items.Clear();
            for (int i = 1; i < daysArray.Length; i++)
            {
                comboBox1.Items.Add(daysArray[i]);
            }

            DisplayImageOnPanel();

            // 3. ラジオボタンのリセット
            ResetRadioButtons();

            // 4. 【重要】全ての処理が終わった「最後」に、ラベルを "Days" で上書きする
            // これにより、もし手順3で意図せずイベントが動いてラベルが変わっていても、ここで修正されます。
            label1.Text = "Days";
            label2.Text = "Days";

            // 5. ラジオボタンへの自動フォーカスを外す
            this.ActiveControl = label1;

            // 6. 初期状態のボタン色と有効化設定
            button1.BackColor = Color.Yellow;
            button1.Enabled = false;

            // 7. すべてが整ったところで、フラグを true にしてユーザー操作を許可する
            isLoaded = true;
        }

        // --- 項番3, 4: 曜日のラジオボタン変更イベント ---
        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                // ラベル1に選択された曜日を表示
                label1.Text = rb.Text;
            }
        }

        // --- 項番6, 7: リスト切り替え用ラジオボタン (Days/Years) ---
        private void RadioButton_Switch_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            RadioButton rb = sender as RadioButton;
            if (rb == null || !rb.Checked) return;

            // コンボボックスをクリアして再設定
            comboBox1.Items.Clear();

            if (rb == radioButton8) // Days選択時
            {
                for (int i = 1; i < daysArray.Length; i++) comboBox1.Items.Add(daysArray[i]);
            }
            else if (rb == radioButton9) // Years選択時
            {
                for (int i = 1; i < yearsArray.Length; i++) comboBox1.Items.Add(yearsArray[i]);
            }

            // リストの先頭を選択し、ラベル2を更新
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
                label2.Text = comboBox1.SelectedItem.ToString();
            }
        }

        // --- 項番7, 8: コンボボックス選択変更イベント ---
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                // ラベル2を選択した文字列に変更
                label2.Text = comboBox1.SelectedItem.ToString();
            }
        }

        // --- 項番9: チェックボックス連動 (ボタン有効化判定) ---
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // 3つのチェックボックスすべてにチェックが入っている場合のみボタンを有効化
            button1.Enabled = (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked);
        }

        // --- 項番10: ボタンクリックイベント ---
        private void Button1_Click(object sender, EventArgs e)
        {
            // チェック完了メッセージを表示
            MessageBox.Show(Message_manage.Msg4, Message_manage.Title3);
        }

        // --- 項番10: ボタンの色・カーソル変更 ---
        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Cursor = Cursors.Hand;
            button1.BackColor = Color.Black;    // 背景色：黒
            button1.ForeColor = Color.White;    // 文字色：白
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            // 元の背景色（黄色）に戻す
            button1.BackColor = Color.Yellow;

            // 文字色も元（黒）に戻す
            button1.ForeColor = Color.Black;
        }

        // --- 項番12: 画像表示処理 ---
        private void DisplayImageOnPanel()
        {
            if (Properties.Resources.ichigo != null)
            {
                panel4.BackgroundImage = Properties.Resources.ichigo;
                panel4.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        // --- 項番14: 画像レイアウト変更ラジオボタン ---
        private void RadioButton_Layout_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            RadioButton rb = sender as RadioButton;
            if (rb == null || !rb.Checked) return;

            if (rb == radioButton10) panel4.BackgroundImageLayout = ImageLayout.Zoom;
            else if (rb == radioButton11) panel4.BackgroundImageLayout = ImageLayout.Stretch;
            else if (rb == radioButton12) panel4.BackgroundImageLayout = ImageLayout.Center;
        }

        // ラジオボタンのリセット用補助メソッド
        private void ResetRadioButtons()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
        }
    }
}