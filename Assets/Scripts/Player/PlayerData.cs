using UnityEngine;
using Utilities;

namespace Scripts.GameModes
{
    public class PlayerData
    {
        public Vector3 Position;
        public Observable<int> Score;

        public PlayerData()
        {
            Score = new Observable<int>();
            Position = new Vector3();
        }
    }
}