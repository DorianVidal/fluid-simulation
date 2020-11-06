using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Gizmo : MonoBehaviour
{
    public GameObject goGizmo;
    public GameObject goSelect;
    private GameObject goXYZ;
    public int iGizmoMode = 0;
    public float fRotationSpeed;
    private bool bMouseDown;
    private float fDistanceCamera;


    [HideInInspector] public Quaternion QRotation;
    [HideInInspector] public Vector3 V3Scale;

    void Start()
    {
        ActiveMode();
        DisableChilds();
        fDistanceCamera = Vector3.Distance(gameObject.transform.position, Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float newValue = Vector3.Distance(gameObject.transform.position, Camera.main.transform.position);
        gameObject.transform.localScale = new Vector3(newValue / fDistanceCamera, newValue / fDistanceCamera, newValue / fDistanceCamera);

        if (bMouseDown && goXYZ)
            goXYZ.GetComponent<XYZ>().MouseDrag();

        if (Input.GetKeyDown(KeyBinding.instance.kChangeGizmo.kcKey))
        {
            if (iGizmoMode == 2)
                iGizmoMode = 0;
            else
                iGizmoMode++;
            SetPosAndRotGizmo(goSelect.transform);
            ActiveMode();
        }

        if (Input.GetKeyUp(KeyBinding.instance.kSelect.kcKey))
        {
            bMouseDown = false;
            goXYZ = null;
        }

        if (Input.GetKeyDown(KeyBinding.instance.kSelect.kcKey) && !KeyBinding.instance.kRotateAroundAndZoom.isDown)
        {
            bMouseDown = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Gizmo")))
            {
                goXYZ = hit.transform.gameObject;
                goXYZ.GetComponent<XYZ>().MouseDown();
            }
            else
            {
                SelectGameObject();
            }
        }
        if (goSelect)
        {
            //print(goSelect.transform.rotation.eulerAngles.y);
            //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, goSelect.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            switch (iGizmoMode)
            {
                case 0:
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    goSelect.transform.position = transform.position; //Set Position of selected object
                    break;
                case 1:
                    transform.rotation = Quaternion.Euler(goSelect.transform.rotation.eulerAngles.x, goSelect.transform.rotation.eulerAngles.y, goSelect.transform.rotation.eulerAngles.z);
                    goSelect.transform.rotation = QRotation; //Set Rotation of selected object
                    break;
                case 2:
                    transform.rotation = Quaternion.Euler(goSelect.transform.rotation.eulerAngles.x, goSelect.transform.rotation.eulerAngles.y, goSelect.transform.rotation.eulerAngles.z);
                    goSelect.transform.localScale = V3Scale; //Set Scale of selected object
                    break;
                default:
                    break;
            }
        }
    }

    //When you select
    void SelectGameObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform.gameObject.layer != LayerMask.NameToLayer("Gizmo") && hit.transform.gameObject.layer != LayerMask.NameToLayer("Background"))
        {
            ActiveMode();
            if (hit.transform.parent != null)
            {
                goSelect = hit.transform.parent.gameObject;

                SetPosAndRotGizmo(goSelect.transform);
            }
            else if (hit.transform.gameObject != null)
            {
                goSelect = hit.transform.gameObject;

                SetPosAndRotGizmo(goSelect.transform);
            }
        }
        else
        {
            DisableChilds();
        }
    }

    void DisableChilds()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

    void ActiveMode()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        switch (iGizmoMode)
        {
            case 0:
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 1:
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    void SetPosAndRotGizmo(Transform SelectedObject)
    {
        goGizmo.transform.position = SelectedObject.position;
        QRotation = SelectedObject.rotation;
        V3Scale = SelectedObject.localScale;
    }
}