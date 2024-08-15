using System;
using Scripts.Environment;
using Scripts.Player;
using UnityEngine;

namespace Scripts.GameModes
{
    public class ClassicGameMode
    {
        public event Action Won;
        public event Action Lose;

        private bool _isActive;

        private readonly float _cameraMovementSpeed;
        private readonly Vector3 _cameraOffset;

        private readonly Camera _meshCamera;
        private readonly WorldView _worldView;
        private readonly PlayerData _playerData;
        private readonly PlayerView _playerView;
        private readonly PlayerMovement _playerMovement;

        public ClassicGameMode(
            Camera meshCamera,
            WorldView worldView,
            PlayerData playerData,
            PlayerView playerView,
            PlayerMovement playerMovement)
        {
            _meshCamera = meshCamera;
            _worldView = worldView;
            _playerData = playerData;
            _playerView = playerView;
            _playerMovement = playerMovement;
            _cameraMovementSpeed = 10;
            _cameraOffset = new Vector3(
                0,
                3.5f,
                -15f);

            _playerView.CollidedCoin += coinView =>
            {
                _playerData.Score.Value += 1;
                coinView.Hide();
            };

            _playerView.CollidedObstacle += obstacleView =>
            {
                Stop();
                Lose?.Invoke();
            };

            _playerView.CollidedFinishLine += obstacleView =>
            {
                Stop();
                Won?.Invoke();
            };
        }

        public void Start()
        {
            _isActive = true;
        }

        public void Update()
        {
            if (!_isActive) return;

            _playerMovement.Move(_playerView);
        }

        public void LateUpdate()
        {
            _meshCamera.transform.position = Vector3.Lerp(
                _meshCamera.transform.position,
                Vector3.forward * _playerView.transform.position.z + _cameraOffset,
                _cameraMovementSpeed * Time.deltaTime);
        }

        public void Stop()
        {
            _isActive = false;
        }

        public void Reset()
        {
            var startPosition = new Vector3(
                0,
                1,
                0);

            _playerData.Score.Value = 0;
            _playerData.Position = startPosition;
            _playerView.transform.position = startPosition;
            _meshCamera.transform.position = startPosition + _cameraOffset;

            foreach (var coinView in _worldView.CoinViews)
            {
                coinView.Show();
            }
        }
    }
}