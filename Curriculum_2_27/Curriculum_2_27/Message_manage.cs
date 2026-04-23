using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curriculum_2_27
{
    // staticを付けると、newしなくてもどこからでも使える
    public static class Message_manage
    {
        public const string Msg1 = "画面遷移してもよろしいですか？";
        public const string Msg2 = "ファイルまたはフォルダが存在しません";
        public const string Msg3 = "ファイルを上書きしました";
        public const string Msg4 = "チェック完了！";

        public const string Title1 = "開くファイルを選択してください";
        public const string Title2 = "上書き完了";
        public const string Title3 = "確認";
        public const string Title4 = "ERR";
    }
}
