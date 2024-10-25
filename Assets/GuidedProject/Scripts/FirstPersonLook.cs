using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{

    public float MouseSensitivity = 2.0f;
    private float cameraVerticalRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxis("Mouse X") * MouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * MouseSensitivity;

        cameraVerticalRotation = inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90.0f, 90.0f); ;
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
    }
}
