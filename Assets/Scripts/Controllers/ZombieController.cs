using Assets.Scripts.Controllers.StateMachine;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public GameObject target;
    public float radius = 10.0f;
    public float speed = 3.0F;
    public Vector3 moveVelocity;

    private const string PLAYER_TAG = "player";
    private Vector3 _moveInput;
    private Rigidbody _rigidBody;
    private ZombieStateMachine _stateMachine;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _stateMachine = GetComponent<ZombieStateMachine>();
    }

    void Update()
    {
        _stateMachine.currentState.Update(gameObject);
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector3(moveVelocity.x, _rigidBody.velocity.y, moveVelocity.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
