using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public GameObject target;
    public float radius = 10.0f;
    public float speed = 3.0F;

    private const string PLAYER_TAG = "player";
    private Vector3 _moveInput;
    private Vector3 _moveVelocity;
    private Rigidbody _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        FindTarget();
    }

    void Update()
    {
        if (target == null)
        {
            //Roaming
            FindTarget();
        }
        else
        {
            _moveInput = (target.transform.position - transform.position).normalized;
            _moveVelocity = _moveInput * speed;
            Debug.DrawLine(transform.position, _moveVelocity + Vector3.up, Color.red);
        }
    }

    private void FixedUpdate()
    {
        //TODO: can remove the gravity by removing the up vector
        _rigidBody.velocity = _moveVelocity + _rigidBody.velocity.y * Vector3.up;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void FindTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        Collider nearestCollider = null;
        float minSqrDistance = Mathf.Infinity;

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == PLAYER_TAG)
            {
                float sqrDistanceToCenter = (transform.position - colliders[i].transform.position).sqrMagnitude;

                if (sqrDistanceToCenter < minSqrDistance)
                {
                    minSqrDistance = sqrDistanceToCenter;
                    nearestCollider = colliders[i];
                }
            }
        }
        if (nearestCollider != null)
        {
            target = nearestCollider.gameObject;
        }
    }
}
