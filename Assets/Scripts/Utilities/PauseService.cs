using UnityEngine;

namespace Utilities
{
    public class PauseService
    {
        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Unpause()
        {
            Time.timeScale = 1;
        }
    }
}