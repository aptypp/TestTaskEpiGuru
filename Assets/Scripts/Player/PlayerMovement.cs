using Scripts.Environment;
using Scripts.GameModes;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerMovement
    {
        private readonly PlayerData _playerData;

        public PlayerMovement(
            PlayerData playerData)
        {
            _playerData = playerData;
            _playerData.Position.y = 1;
        }

        public void SetHorizontalPosition(
            float normalized)
        {
            _playerData.Position.x = Mathf.Lerp(
                -1,
                1,
                normalized) * 4;
        }

        public void Move(
            PlayerView playerView)
        {
            const float speed = 7.5f;

            _playerData.Position.z += speed * Time.deltaTime;

            playerView.transform.position = Vector3.Lerp(
                playerView.transform.position,
                _playerData.Position,
                speed * Time.deltaTime);
        }
    }
}