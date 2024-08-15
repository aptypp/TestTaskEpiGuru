using UnityEngine;

namespace Scripts.Base
{
    public class BaseView : MonoBehaviour
    {
        public void Show() => SetVisibility(true);

        public void Hide() => SetVisibility(false);

        public void SetVisibility(
            bool isVisible)
        {
            gameObject.SetActive(isVisible);
        }
    }
}