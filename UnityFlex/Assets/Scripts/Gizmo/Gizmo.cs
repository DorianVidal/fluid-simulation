using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Gizmo : MonoBehaviour
{
    public GameObject goGizmo;
    public GameObject goSelect;
    private GameObject goXYZ;
    public bool bIsTranslate = true;
    private bool bMouseDown;
    private float fDistanceCamera;


    [HideInInspector] public Quaternion rotation;

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
            bIsTranslate = !bIsTranslate;
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
        if (goSelect && bIsTranslate)
            goSelect.transform.position = goGizmo.transform.position; //Set Position of selected object
        else if (goSelect)
            goSelect.transform.rotation = rotation; //Set Rotation of selected object
    }

    //When you select
    void SelectGameObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform.gameObject.layer != LayerMask.NameToLayer("Gizmo"))
        {
            ActiveMode();
            if (hit.transform.parent)
            {
                goSelect = hit.transform.parent.gameObject;

                SetPosAndRotGizmo(goSelect.transform.parent.transform);
            }
            else if(hit.transform.gameObject)
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
        gameObject.transform.GetChild(0).gameObject.SetActive(bIsTranslate);
        gameObject.transform.GetChild(1).gameObject.SetActive(!bIsTranslate);
    }

    void SetPosAndRotGizmo(Transform SelectedObject)
    {
        goGizmo.transform.position = SelectedObject.position;
        goGizmo.GetComponent<Gizmo>().rotation = SelectedObject.rotation;
    }
}