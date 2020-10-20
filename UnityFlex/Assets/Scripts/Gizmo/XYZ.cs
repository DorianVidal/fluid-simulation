using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XYZ : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    public bool X;
    public bool Y;
    public bool Z;

    public void MouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.parent.position);

        offset = gameObject.transform.parent.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    public void MouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        if (X)
            transform.parent.position = new Vector3(curPosition.x, transform.parent.position.y, transform.parent.position.z);
        if (Y)
            transform.parent.position = new Vector3(transform.parent.position.x, curPosition.y, transform.parent.position.z);
        if (Z)
            transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, curPosition.z);
    }
}
