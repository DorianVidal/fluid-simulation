using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 2.0f;
    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    public float smoothTime = 0.1f;

    Vector2 v2LastMousePosition;

    Vector3 v3CameraPos;
    Quaternion v3CameraRot;


    float x, y;

    private float xSpeed = 10.0f;
    private float ySpeed = 10.0f;

    private float xSmooth = 0.0f;
    private float ySmooth = 0.0f;
    private float xVelocity = -10.0f;
    private float yVelocity = -10.0f;


    void Start()
    {
        v3CameraPos = gameObject.transform.position;
        v3CameraRot = gameObject.transform.rotation;
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
        {
            transform.Translate(Vector3.forward * Input.mouseScrollDelta.y);
            distance = Vector3.Distance(transform.position, target.position);
        }
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
        if (target && KeyBinding.instance.kRotateAroundAndZoom.isDown)
        {
            if (Input.GetKeyDown(KeyBinding.instance.kSelect.kcKey))
            {
                distance = Vector3.Distance(target.position, transform.position);
                //x = transform.rotation.x;
                //y = transform.rotation.y;
            }
            if (KeyBinding.instance.kSelect.isDown)
            {
                x += Input.GetAxis("Mouse X") * xSpeed;
                y -= Input.GetAxis("Mouse Y") * ySpeed;

                y = Mathf.Clamp(y, yMinLimit, yMaxLimit);

                /*x += Input.GetAxis("Mouse X") * distance * 0.52f;
                y -= Input.GetAxis("Mouse Y") * 2.04f;

                y = ClampAngle(y, -90, 90);

                Quaternion rotation = Quaternion.Euler(y, x, 0);

                Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
                Vector3 position = rotation * negDistance + target.position;

                transform.rotation = rotation;
                transform.position = position;*/
            }
        }
        if ((int)xVelocity != 0 && (int)yVelocity != 0 || KeyBinding.instance.kRotateAroundAndZoom.isDown && KeyBinding.instance.kSelect.isDown)
        {
            xSmooth = Mathf.SmoothDamp(xSmooth, x, ref xVelocity, smoothTime);
            ySmooth = Mathf.SmoothDamp(ySmooth, y, ref yVelocity, smoothTime);

            transform.localRotation = Quaternion.Euler(ySmooth, xSmooth, 0);
            transform.position = transform.rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;
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
