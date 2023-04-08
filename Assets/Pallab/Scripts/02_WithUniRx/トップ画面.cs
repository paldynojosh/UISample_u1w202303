using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Pallab.WithUniRx
{
    class トップ画面 : MonoBehaviour
    {
        [SerializeField] Button ステージセレクトボタン;
        [SerializeField] Button オプションボタン;
        [SerializeField] Button ライセンスボタン;

        [SerializeField] ステージセレクト画面 ステージセレクト;
        [SerializeField] オプション画面 オプション;
        [SerializeField] ライセンス画面 ライセンス;

        画面の状態 画面の状態インスタンス = new 画面の状態();

        void Start()
        {
            // 状態を渡す
            ステージセレクト.これみて(画面の状態インスタンス);
            オプション.これみて(画面の状態インスタンス);
            ライセンス.これみて(画面の状態インスタンス);

            // ボタンを押して状態を更新
            ステージセレクトボタン.OnClickAsObservable()
                .Subscribe(_ => 画面の状態インスタンス.画面を変更(画面の状態.画面.ステージセレクト))
                .AddTo(gameObject);
            オプションボタン.OnClickAsObservable()
                .Subscribe(_ => 画面の状態インスタンス.画面を変更(画面の状態.画面.オプション))
                .AddTo(gameObject);
            ライセンスボタン.OnClickAsObservable()
                .Subscribe(_ => 画面の状態インスタンス.画面を変更(画面の状態.画面.ライセンス))
                .AddTo(gameObject);

            // 画面の状態を監視して画面を表示・非表示
            画面の状態インスタンス.今の画面
                .Subscribe(画面 =>
                {
                    if (画面 == 画面の状態.画面.トップ)
                    {
                        表示();
                    }
                    else
                    {
                       非表示();
                    }
                })
                .AddTo(gameObject);
        }

        private void 表示() => gameObject.SetActive(true);
        private void 非表示() => gameObject.SetActive(false);
    }
}