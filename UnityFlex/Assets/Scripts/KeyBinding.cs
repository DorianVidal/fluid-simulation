using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBinding : MonoBehaviour
{
    public static KeyBinding instance;


    [SerializeField] private KeyCode kcRotateAroundAndZoom;
    [SerializeField] private KeyCode kcRotateView;
    [SerializeField] private KeyCode kcSelect;
    [SerializeField] private KeyCode kcPanMove;
    [SerializeField] private KeyCode kcResetView;
    [SerializeField] private KeyCode kcChangeGizmo;

    public Key kRotateAroundAndZoom;
    public Key kRotateView;
    public Key kSelect;
    public float fWheelMouse;
    public float fMouseSensitivity;
    public Key kPanMove;
    public Key kResetView;
    public Key kChangeGizmo;

    void Awake()
    {
        if (instance != null)
            GameObject.Destroy(instance);
        else
            instance = this;

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        kRotateAroundAndZoom.kcKey = kcRotateAroundAndZoom;
        kRotateView.kcKey = kcRotateView;
        kSelect.kcKey = kcSelect;
        kPanMove.kcKey = kcPanMove;
        kResetView.kcKey = kcResetView;
        kChangeGizmo.kcKey = kcChangeGizmo;
    }

    public void Update()
    {
        fWheelMouse += Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetKeyDown(kResetView.kcKey))
            kResetView.isDown = true;
        if (Input.GetKeyUp(kResetView.kcKey))
            kResetView.isDown = false;

        if (Input.GetKeyDown(kPanMove.kcKey))
            kPanMove.isDown = true;
        if (Input.GetKeyUp(kPanMove.kcKey))
            kPanMove.isDown = false;

        if (Input.GetKeyDown(kRotateAroundAndZoom.kcKey))
            kRotateAroundAndZoom.isDown = true;
        if (Input.GetKeyUp(kRotateAroundAndZoom.kcKey))
            kRotateAroundAndZoom.isDown = false;

        if (Input.GetKeyDown(kRotateView.kcKey))
            kRotateView.isDown = true;
        if (Input.GetKeyUp(kRotateView.kcKey))
            kRotateView.isDown = false;

        if (Input.GetKeyDown(kSelect.kcKey))
            kSelect.isDown = true;
        if (Input.GetKeyUp(kSelect.kcKey))
            kSelect.isDown = false;
    }
}

public struct Key
{
    public KeyCode kcKey;
    public bool isDown;
}