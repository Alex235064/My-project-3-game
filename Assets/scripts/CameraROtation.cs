using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraROtation : MonoBehaviour
{
    public float rotationSpeed;

    public Transform CameraAxisTransform;

    public float minAngle;
    public float maxAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * rotationSpeed * Input.GetAxis("Mouse X"), 0);

        var newAngle = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * rotationSpeed * Input.GetAxis("Mouse Y");
        if (newAngle > 180)
            newAngle -= 360;

        newAngle = Mathf.Clamp(newAngle, minAngle, maxAngle);

        CameraAxisTransform.localEulerAngles = new Vector3(newAngle, 0, 0);
    }
}
