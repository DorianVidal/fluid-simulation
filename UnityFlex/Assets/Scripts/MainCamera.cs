using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 2.0f;
    public float xSpeed = 10.0f;
    public float ySpeed = 10.0f;
    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    public float distanceMin = 10f;
    public float distanceMax = 10f;
    public float smoothTime = 2f;
    float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;
    float velocityX = 0.0f;
    float velocityY = 0.0f;
    Vector2 v2LastMousePosition;

    Vector3 v3CameraPos;
    Quaternion v3CameraRot;


    bool mouseClickjudge;
     // Use this for initialization
    void Start()
    {
        v3CameraPos = gameObject.transform.position;
        v3CameraRot = gameObject.transform.rotation;
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;
    }
    void Update()
    {
        if (KeyBinding.instance.kResetView.isDown)
        {
            gameObject.transform.position = v3CameraPos;
            gameObject.transform.rotation = v3CameraRot;
        }

        if (KeyBinding.instance.fWheelMouse != 0)
            transform.Translate(Vector3.forward * KeyBinding.instance.fWheelMouse);

        if (Input.GetKeyDown(KeyBinding.instance.kPanMove.kcKey))
            v2LastMousePosition = Input.mousePosition;

        if (KeyBinding.instance.kPanMove.isDown)
        {
            if (Input.GetKeyDown(KeyBinding.instance.kPanMove.kcKey))
            {
                v2LastMousePosition = Input.mousePosition;
            }
            Vector2 delta = new Vector2(v2LastMousePosition.x - Input.mousePosition.x, v2LastMousePosition.y - Input.mousePosition.y);
            transform.Translate(delta.x * KeyBinding.instance.fMouseSensitivity, delta.y * KeyBinding.instance.fMouseSensitivity, 0);
            v2LastMousePosition = Input.mousePosition;
        }            

        if (target)
        { 
            if (KeyBinding.instance.kRotateView.isDown && KeyBinding.instance.kRotateAroundAndZoom.isDown)
            {
                Camera.main.transform.LookAt(target.position);
                transform.Translate(Vector3.right * Input.mousePosition.x * Time.deltaTime);
                /* transform.RotateAround(target.position, target.up, Input.GetAxis("Mouse X") * 5);

                print(transform.rotation.eulerAngles.y + "        " + -Mathf.Cos(transform.rotation.eulerAngles.y));
                transform.RotateAround(target.position, new Vector3(-Mathf.Cos(transform.rotation.eulerAngles.y), 0, 0), Input.GetAxis("Mouse Y") * 5);

                if (transform.rotation.eulerAngles.y < 270 && transform.rotation.eulerAngles.y > 90)
                 {
                     transform.RotateAround(target.position, new Vector3(0,0,Mathf.Cos(transform.rotation.eulerAngles.y)), Input.GetAxis("Mouse Y") * 5);
                 }
                 if (transform.rotation.eulerAngles.y > 270 || transform.rotation.eulerAngles.y < 90)
                 {
                     transform.RotateAround(target.position, -target.right, Input.GetAxis("Mouse Y") * 5);
                 }*/
            }
            if (Input.GetMouseButton(1))
            {
                velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.02f;
                velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
            }
                /* rotationYAxis += velocityX;
                 rotationXAxis -= velocityY;
                 rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
                 Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
                 Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
                 Quaternion rotation = toRotation;
                 transform.rotation = rotation;
                 velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
                 velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);*/
            }
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
