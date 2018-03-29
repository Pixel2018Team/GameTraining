using UnityEngine;

namespace Assets.Scripts.Controllers.StateMachine
{
    class ZombieStateMachine : MonoBehaviour
    {
        public static ZombieSearchState zombieSearchState = new ZombieSearchState();
        public static ZombieRunningState running = new ZombieRunningState();

        public ZombieState currentState = zombieSearchState;
    }
}
