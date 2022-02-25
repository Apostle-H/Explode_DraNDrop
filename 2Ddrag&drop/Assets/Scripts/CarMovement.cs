using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private WheelJoint2D BackWheel;
    [SerializeField] private WheelJoint2D FrontWheel;

    [SerializeField] private float MotorSpeed;
    [SerializeField] private float MaximumForce;

    private void Update()
    {
        JointMotor2D motorSettings = new JointMotor2D();
        motorSettings.motorSpeed = MotorSpeed * Input.GetAxis("Horizontal");
        motorSettings.maxMotorTorque = MaximumForce;

        BackWheel.motor = motorSettings;
        FrontWheel.motor = motorSettings;
    }
}
