using Scripts.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Panels
{
    public class ActionPanel : BaseView
    {
        [field: SerializeField]
        public Button MenuButton { get; private set; }

        [field: SerializeField]
        public Button PauseButton { get; private set; }

        [field: SerializeField]
        public Touchpad Touchpad { get; private set; }
        
        [field: SerializeField]
        public TMP_Text ScoreText { get; private set; }
    }
}