using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class CameraManager : MonoBehaviour
{

    public CinemachineVirtualCamera closeUpCamera;
    public CinemachineVirtualCamera CompleteCamera;
    public CinemachineVirtualCamera MiddleCamera;
    public CinemachineVirtualCamera OrthographicCamera;
    public CinemachineVirtualCamera FirstPersonCamera;
    public CinemachineVirtualCamera TourCamera;
    public Transform trackball;
    public float Speed = 20f;
    public float verticalInput;

    private CinemachineVirtualCamera activeCamera;

    public float MouseSensitivity = 2.0f;
    private float cameraVerticalRotation = 0.0f;
    private float cameraHorizontalRotation = 0.0f;
    public PlayableDirector director;
    

    // Start is called before the first frame update
    void Start()
    {
        CompleteCamera.Priority = 11;
        activeCamera = CompleteCamera;
        director.playOnAwake = false;
    }

   
    void Update()
    {

        float inputX = Input.GetAxis("Mouse X") * MouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * MouseSensitivity;
        verticalInput = Input.GetAxis("Vertical");


        if (Input.GetKeyDown("1"))
        {
            closeUpCamera.Priority = 10;
            CompleteCamera.Priority = 11;
            MiddleCamera.Priority = 10;
            OrthographicCamera.Priority = 10;
            FirstPersonCamera.Priority = 10;
            TourCamera.Priority = 10;

            activeCamera = CompleteCamera;

        }

        if (Input.GetKeyDown("2"))
        {
            closeUpCamera.Priority = 11;
            CompleteCamera.Priority = 10;
            MiddleCamera.Priority = 10;
            OrthographicCamera.Priority = 10;
            FirstPersonCamera.Priority = 10;
            TourCamera.Priority = 10;

            activeCamera = closeUpCamera;
             
        }

        if (Input.GetKeyDown("3"))
        {
            closeUpCamera.Priority = 10;
            CompleteCamera.Priority = 10;
            MiddleCamera.Priority = 11;
            OrthographicCamera.Priority = 10;
            FirstPersonCamera.Priority = 10;
            TourCamera.Priority = 10;


            activeCamera = MiddleCamera;

        }

        if (Input.GetKeyDown("4"))
        {
            closeUpCamera.Priority = 10;
            CompleteCamera.Priority = 10;
            MiddleCamera.Priority = 10;
            OrthographicCamera.Priority = 11;
            FirstPersonCamera.Priority = 10;
            TourCamera.Priority = 10;

            activeCamera = OrthographicCamera;

        }

        if (Input.GetKeyDown("5"))
        {
            closeUpCamera.Priority = 10;
            CompleteCamera.Priority = 10;
            MiddleCamera.Priority = 10;
            OrthographicCamera.Priority = 10;
            FirstPersonCamera.Priority = 11;
            TourCamera.Priority = 10;

            activeCamera = FirstPersonCamera;

        }

        if (Input.GetKeyDown("6"))
        {
            closeUpCamera.Priority = 10;
            CompleteCamera.Priority = 10;
            MiddleCamera.Priority = 10;
            OrthographicCamera.Priority = 10;
            FirstPersonCamera.Priority = 10;
            TourCamera.Priority = 11;

            activeCamera = TourCamera;

        }

        if (activeCamera == FirstPersonCamera)
        {
                cameraVerticalRotation -= inputY;
                cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f,90f);
                FirstPersonCamera.transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
                cameraHorizontalRotation -= inputX;

                trackball.Rotate(Vector3.up * inputX);

                trackball.transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * Speed);
 
        }

        if (activeCamera == FirstPersonCamera)
        {
            cameraVerticalRotation -= inputY;
            cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
            FirstPersonCamera.transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
            cameraHorizontalRotation -= inputX;

            trackball.Rotate(Vector3.up * inputX);

            trackball.transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * Speed);

        }
        

       if (Input.GetKey(KeyCode.M))
       {
            MiddleCamera.m_Lens.FieldOfView -= 1f;
       }
        
       if (Input.GetKey(KeyCode.N))
        {
            MiddleCamera.m_Lens.FieldOfView += 1f;
        }


       if (TourCamera == activeCamera)
       {
            director.Play();
       }

       if (TourCamera != activeCamera)
        {
            director.Stop();    
        }





    }
}
