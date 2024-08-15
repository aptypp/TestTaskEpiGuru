using Scripts.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Popups
{
    public class PausePopup : BaseView
    {
        [field: SerializeField]
        public Button ContinueButton { get; private set; }
    }
}