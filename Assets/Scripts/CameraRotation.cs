using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float RotationSpeed;
    public Transform CameraAxisTransform;
    public float MinAngle;
    public float MaxAngle;
    void Update()
    {
        transform.localEulerAngles = new Vector3(0,transform.localEulerAngles.y + RotationSpeed * Time.deltaTime * Input.GetAxis("Mouse X"),0);
        var newAngleX = CameraAxisTransform.transform.localEulerAngles.x - RotationSpeed * Time.deltaTime * Input.GetAxis("Mouse Y");
        if(newAngleX > 180)
        {
            newAngleX -= 360;
        }
        newAngleX = Mathf.Clamp(newAngleX,MinAngle,MaxAngle);
        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
