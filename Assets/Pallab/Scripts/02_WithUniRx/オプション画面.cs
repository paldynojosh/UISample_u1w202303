using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Pallab.WithUniRx
{
    class オプション画面 : MonoBehaviour
    {
        [SerializeField] private Button 戻るボタン;

        private 画面の状態 画面の状態インスタンス;

        public void これみて(画面の状態 画面の状態インスタンス)
        {
            this.画面の状態インスタンス = 画面の状態インスタンス;
            セットアップ();
        }

        private void セットアップ()
        {
            画面の状態インスタンス.今の画面
                .Subscribe(type =>
                {
                    if (type == 画面の状態.画面.オプション)
                    {
                        表示();
                    }
                    else
                    {
                        非表示();
                    }
                })
                .AddTo(gameObject);

            戻るボタン.OnClickAsObservable()
                .Subscribe(_ => 画面の状態インスタンス.画面を変更(画面の状態.画面.トップ))
                .AddTo(gameObject);
        }

        private void 表示() => gameObject.SetActive(true);
        private void 非表示() => gameObject.SetActive(false);
    }
}