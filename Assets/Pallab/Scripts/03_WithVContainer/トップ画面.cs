using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Pallab.WithVContainer
{
    class トップ画面 : MonoBehaviour
    {
        [SerializeField] Button ステージセレクトボタン;
        [SerializeField] Button オプションボタン;
        [SerializeField] Button ライセンスボタン;

        画面の状態 画面の状態インスタンス;

        [Inject]
        public void 注入(画面の状態 画面の状態インスタンス)
        {
            this.画面の状態インスタンス = 画面の状態インスタンス;
        }

        void Start()
        {
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