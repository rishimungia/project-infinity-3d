using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class shipController : MonoBehaviour
{
    public Transform shipModel;

    private float thrustInput;
    private float strafeInput;
    private float rollInput;
    private float pitchInput;

    public float forwardSpeed = 25.0f;
    public float strafeSpeed = 7.5f;
    public float strafeRotation = 4.5f;
    public float pitchSpeed = 10.0f;
    public float rollSpeed = 10.0f;

    private Rigidbody _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        _rigidBody.AddRelativeForce(Vector3.forward * thrustInput * forwardSpeed);

        _rigidBody.AddRelativeTorque(Vector3.up * strafeInput * strafeSpeed);
        shipModel.localEulerAngles = new Vector3(0.0f, strafeInput * strafeRotation, shipModel.localEulerAngles.z);  

        _rigidBody.AddRelativeTorque(Vector3.forward * -rollInput * rollSpeed);

        _rigidBody.AddRelativeTorque(Vector3.right * pitchInput * pitchSpeed);
    }

    void OnThrust(InputValue thrustValue) {
        thrustInput = thrustValue.Get<float>();
    }

    void OnStrafe(InputValue strafeValue) {
        strafeInput = strafeValue.Get<float>();
    }

    void OnRollPitch(InputValue rollPitchValue) {
        rollInput = rollPitchValue.Get<Vector2>().x;
        pitchInput = rollPitchValue.Get<Vector2>().y;
    }
}
