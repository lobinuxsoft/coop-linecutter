using UnityEngine;

[RequireComponent(typeof(CapsuleCollider), typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField, Range(.5f, 10)] float maxSpeed = 10, maxAcceleration = 10;

    Rigidbody body = default;
    Vector3 desireVelocity = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    Vector3 lookDir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.freezeRotation = true;
        body.interpolation = RigidbodyInterpolation.Interpolate;
    }

    // private void Update() {

    //     MoveDir(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    // }

    // Update is called once per frame
    private void FixedUpdate() {
        
        velocity = body.velocity;
        float maxSpeedChange = maxAcceleration * Time.fixedDeltaTime;

        velocity.x = Mathf.MoveTowards(velocity.x, desireVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desireVelocity.z, maxSpeedChange);

        body.velocity = velocity;
        body.MoveRotation(Quaternion.Lerp(body.rotation, Quaternion.LookRotation(lookDir, Vector3.up), Time.fixedDeltaTime));
    }

    public void MoveDir(Vector3 dir)
    {
        lookDir = dir.magnitude > 0 ? dir : lookDir;

        desireVelocity = new Vector3(dir.x, 0, dir.z) * maxSpeed;
    }
}
