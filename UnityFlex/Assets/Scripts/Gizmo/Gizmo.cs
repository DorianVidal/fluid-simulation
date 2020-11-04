using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Gizmo : MonoBehaviour
{
    public GameObject goGizmo;
    private GameObject goSelect;
    private GameObject goXYZ;
    private bool bMouseDown;
    private float fDistanceCamera;

    void Start()
    {
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

        if (Input.GetKeyUp(KeyBinding.instance.kSelect.kcKey))
        {
            bMouseDown = false;
            goXYZ = null;
        }

        if(Input.GetKeyDown(KeyBinding.instance.kSelect.kcKey) && !KeyBinding.instance.kRotateAroundAndZoom.isDown)
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
        if(goSelect)
            goSelect.transform.position = goGizmo.transform.position;
    }


    void SelectGameObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform.gameObject.layer != LayerMask.NameToLayer("Gizmo"))
        {
            EnableChilds();
            if (hit.transform.parent)
            {
                goGizmo.transform.position = hit.transform.parent.position;
                goSelect = hit.transform.parent.gameObject;
            }
            else if(hit.transform.gameObject)
            {
                goGizmo.transform.position = hit.transform.position;
                goSelect = hit.transform.gameObject;
            }
        }
        else
        {
            DisableChilds();
        }
    }


    void EnableChilds()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }
    void DisableChilds()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }
}
