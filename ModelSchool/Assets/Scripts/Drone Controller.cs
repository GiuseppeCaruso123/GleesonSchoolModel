using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    Rigidbody Drone;

    void Awake()
    {
        Drone = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovementUpDown();
        MovementForward();
        Rotation();

        Drone.AddRelativeForce(Vector3.up * upForce);
        Drone.rotation = Quaternion.Euler(new Vector3(tiltAmountForward, currentYRotation, Drone.rotation.z));
    }
    public float upForce;
    void MovementUpDown()
    {
        if (Input.GetKey(KeyCode.D))
        {
            upForce = 20f;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            upForce = -20f;
        }
        else if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            upForce = 8f;
        }
    }

    private float movementForwardSpeed = 20f;
    private float tiltAmountForward = 0f;
    private float tiltVelocityForward;

    void MovementForward()
    {
        if(Input.GetAxis("Vertical") != 0)
        {
            Drone.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * movementForwardSpeed);
            tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 20 * Input.GetAxis("Vertical"), ref tiltVelocityForward, 0.1f);
        }
    }

    private float wantedYRotation;
    private float currentYRotation;
    private float rotateAmountByKeys = 2.5f;
    private float rotationYVelocity;
    void Rotation()
    {
        if(Input.GetKey(KeyCode.J))
        {
            wantedYRotation -= rotateAmountByKeys;
        }
        if(Input.GetKey(KeyCode.K))
        {
            wantedYRotation += rotateAmountByKeys;
        }
        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);
    }

}