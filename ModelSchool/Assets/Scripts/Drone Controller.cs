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
        ClampingSpeedValues();
        Swerve();

        Drone.AddRelativeForce(Vector3.up * upForce);
        Drone.rotation = Quaternion.Euler(new Vector3(tiltAmountForward, currentYRotation, tiltAmountSidways));
    }
    public float upForce;
    void MovementUpDown()
    {
        if (Input.GetKey(KeyCode.E))
        {
            upForce = 20f;
        }
        else if(Input.GetKey(KeyCode.Q))
        {
            upForce = -20f;
        }
        else if(!Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.Q))
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
    [HideInInspector]public float currentYRotation;
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

    private Vector3 velocityToSmoothDampToZero;
    void ClampingSpeedValues()
    {
        if(Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            Drone.velocity = Vector3.ClampMagnitude(Drone.velocity, Mathf.Lerp(Drone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            Drone.velocity = Vector3.ClampMagnitude(Drone.velocity, Mathf.Lerp(Drone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            Drone.velocity = Vector3.ClampMagnitude(Drone.velocity, Mathf.Lerp(Drone.velocity.magnitude, 5.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            Drone.velocity = Vector3.SmoothDamp(Drone.velocity, Vector3.zero, ref velocityToSmoothDampToZero, 0, 95f);
        }
    }

    private float sideMovementAmount = 50f;
    private float tiltAmountSidways;
    private float tiltAmountVelocity;
    void Swerve()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f) 
        {
            Drone.AddRelativeForce(Vector3.right * Input.GetAxis("Horizontal") * sideMovementAmount);
            tiltAmountSidways = Mathf.SmoothDamp(tiltAmountSidways, -20 * Input.GetAxis("Horizontal"), ref tiltAmountVelocity, 0.1f);
        }
        else
        {
            tiltAmountSidways = Mathf.SmoothDamp(tiltAmountSidways, 0, ref tiltAmountVelocity, 0.1f);
        }
    }

}