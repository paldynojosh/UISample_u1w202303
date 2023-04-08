using UniRx;

namespace Pallab
{
    public class 画面の状態
    {
        public enum 画面
        {
            トップ,
            ステージセレクト,
            オプション,
            ライセンス,
        };

        ReactiveProperty<画面> 今の画面の実態 = new();
        public IReadOnlyReactiveProperty<画面> 今の画面 => 今の画面の実態;

        public void 画面を変更(画面 遷移先の画面)
        {
            今の画面の実態.Value = 遷移先の画面;
        }
    }
}
