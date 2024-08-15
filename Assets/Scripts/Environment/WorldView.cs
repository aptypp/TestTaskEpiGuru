using Scripts.Base;
using UnityEngine;

namespace Scripts.Environment
{
    public class WorldView : BaseView
    {
        [field: SerializeField]
        public CoinView[] CoinViews { get; private set; }
    }
}