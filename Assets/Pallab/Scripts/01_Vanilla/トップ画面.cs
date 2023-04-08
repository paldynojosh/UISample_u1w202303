using UnityEngine;

namespace Pallab.Vanilla
{
    class トップ画面 : MonoBehaviour
    {
        public void 表示() => gameObject.SetActive(true);
        public void 非表示() => gameObject.SetActive(false);
    }
}