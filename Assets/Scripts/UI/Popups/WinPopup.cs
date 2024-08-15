using Scripts.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Popups
{
    public class WinPopup : BaseView
    {
        [field: SerializeField]
        public Button ContinueButton { get; private set; }

        [field: SerializeField]
        public TMP_Text ScoreText { get; private set; }
    }
}