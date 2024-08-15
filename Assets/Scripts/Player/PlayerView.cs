using System;
using Scripts.Base;
using UnityEngine;

namespace Scripts.Environment
{
    public class PlayerView : BaseView
    {
        public event Action<CoinView> CollidedCoin;
        public event Action<ObstacleView> CollidedObstacle;
        public event Action<FinishLineView> CollidedFinishLine;

        [field: SerializeField]
        public Rigidbody RigidBody { get; private set; }

        private void OnTriggerEnter(
            Collider other)
        {
            if (other.TryGetComponent<CoinView>(out var coinView))
            {
                CollidedCoin?.Invoke(coinView);
                return;
            }

            if (other.TryGetComponent<ObstacleView>(out var obstacleView))
            {
                CollidedObstacle?.Invoke(obstacleView);
                return;
            }

            if (other.TryGetComponent<FinishLineView>(out var finishLineView))
            {
                CollidedFinishLine?.Invoke(finishLineView);
                return;
            }
        }
    }
}