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

    public float MinDist, CurrentDist, MaxDist, TranslateSpeed, AngleH, AngleV;


    float x, y;

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
        // Reset View
        if (KeyBinding.instance.kResetView.isDown)
        {
            gameObject.transform.position = v3CameraPos;
            gameObject.transform.rotation = v3CameraRot;
        }

        // ZOOM DEZOOM
        if (Input.mouseScrollDelta.y != 0)
            transform.Translate(Vector3.forward * Input.mouseScrollDelta.y);

        // Last Mouse Pose for PanMove
        if (Input.GetKeyDown(KeyBinding.instance.kPanMove.kcKey))
            v2LastMousePosition = Input.mousePosition;


        // PAN MOVE
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

        // ROTATE Camera
        if (KeyBinding.instance.kRotateView.isDown && !KeyBinding.instance.kRotateAroundAndZoom.isDown)
        {
            float mouseInputX = Input.GetAxis("Mouse X");
            float mouseInputY = Input.GetAxis("Mouse Y");

            Vector3 lookhere = new Vector3(-mouseInputY, mouseInputX, 0);

            transform.Rotate(lookhere);

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }

        // ROTATE Camera AROUND the selected object
        if(target)
        {// A MODIFIER !!!

            x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

            //RaycastHit hit;
            //if (Physics.Linecast(target.position, transform.position, out hit))
            //{
            //    distance -= hit.distance;
            //}
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
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
