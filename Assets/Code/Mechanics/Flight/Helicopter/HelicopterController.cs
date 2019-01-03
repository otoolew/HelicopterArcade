using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidBody;
    public Rigidbody RigidBody
    {
        get { return rigidBody; }
        private set { rigidBody = value; }
    }
    public KeyCodeVariable upKey;
    public KeyCodeVariable downKey;
    public KeyCodeVariable leftStrafeKey;
    public KeyCodeVariable rightStrafeKey;
    public float LiftValue;
    public float ThrustInput;
    public float StrafeInput;
    public float RotationInput;

    public Vector3 EulerAngleVelocity { get; set; }
    private Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        EulerAngleVelocity = new Vector3(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        RotationInput = Input.GetAxis("Horizontal");
        ThrustInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        HelicopterMovement();
    }
    public void HelicopterMovement()
    {
        RigidBody.AddForce(transform.forward * ThrustInput * 10f);
        if (leftStrafeKey.KeyPressValue())
            RigidBody.AddForce(-transform.right * 10f);
        if (rightStrafeKey.KeyPressValue())
            RigidBody.AddForce(transform.right * 10f);
        if (upKey.KeyPressValue())
            RigidBody.AddForce(transform.up * 10f);
        if (downKey.KeyPressValue())
            RigidBody.AddForce(-transform.up * 10f);
        Quaternion rotation = Quaternion.Euler(EulerAngleVelocity * RotationInput * Time.deltaTime);
        RigidBody.MoveRotation(RigidBody.rotation * rotation);

        if (RigidBody.velocity.magnitude > 10f)
        {
            RigidBody.velocity = Vector3.ClampMagnitude(RigidBody.velocity, 10f);
        }
    }

}
