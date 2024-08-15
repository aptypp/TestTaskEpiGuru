using Scripts.Base;
using UnityEngine;

namespace Scripts.Environment
{
    public class CoinView : BaseView
    {
        [SerializeField]
        private float _speed;

        private float _angle;

        public void Update()
        {
            _angle += _speed * Time.deltaTime;

            transform.rotation = Quaternion.AngleAxis(
                _angle,
                Vector3.up);
        }
    }
}