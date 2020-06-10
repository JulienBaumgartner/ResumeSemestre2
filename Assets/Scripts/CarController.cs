using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AxisInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class CarController : MonoBehaviour
{
    [SerializeField] private List<AxisInfo> axisInfos;
    [SerializeField] private float maxMotorTorque;
    [SerializeField] private float maxSteeringAngle;
    [SerializeField] private float maxBrake;
    [SerializeField] public GameObject playerSkin;
    //private CamerasManager camerasManager;

    [HideInInspector] public bool controlCar = false;

    // Start is called before the first frame update
    void Start()
    {
        //camerasManager = GameObject.FindObjectOfType<CamerasManager>();
    }

    public void ApplyLocalPositionVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.position = position;
        visualWheel.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(controlCar)
        { 
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        float brake = maxBrake * Input.GetAxis("Jump");

        if (Input.GetAxis("Vertical") < -0.1f)
        {
            //camerasManager.ShowSpecial(0);
        }
        else
        {
            //camerasManager.HideSpecial();
        }

            foreach (AxisInfo axisInfo in axisInfos)
            {
                if (axisInfo.motor)
                {
                    axisInfo.leftWheel.motorTorque = motor;
                    axisInfo.rightWheel.motorTorque = motor;

                    axisInfo.leftWheel.brakeTorque = brake;
                    axisInfo.rightWheel.brakeTorque = brake;
                }
                if (axisInfo.steering)
                {
                    axisInfo.leftWheel.steerAngle = steering;
                    axisInfo.rightWheel.steerAngle = steering;
                }

                ApplyLocalPositionVisuals(axisInfo.leftWheel);
                ApplyLocalPositionVisuals(axisInfo.rightWheel);
            }
        }
    }
}
