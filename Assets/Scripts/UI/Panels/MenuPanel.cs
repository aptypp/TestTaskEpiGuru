using Scripts.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Panels
{
    public class MenuPanel : BaseView
    {
        [field: SerializeField]
        public Button PlayButton { get; private set; }
    }
}