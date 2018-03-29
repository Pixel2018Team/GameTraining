using UnityEngine;

namespace Assets.Scripts.Controllers.StateMachine
{
    class ZombieRunningState : ZombieState
    {
        public override void Update(GameObject gameObject)
        {
            var controller = gameObject.GetComponent<ZombieController>();

            var diffX = controller.target.transform.position.x - gameObject.transform.position.x;
            var diffZ = controller.target.transform.position.z - gameObject.transform.position.z;
            var moveInput = new Vector3(diffX, 0.0f, diffZ).normalized;
            controller.moveVelocity = moveInput * controller.speed;
            Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + controller.moveVelocity, Color.red);
        }
    }
}
