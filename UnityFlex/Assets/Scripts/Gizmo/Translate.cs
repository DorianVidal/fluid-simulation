using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Translate : XYZ
{
    public override void MouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.parent.parent.position);

        offset = gameObject.transform.parent.parent.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        base.MouseDown();
    }
    public override void MouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        if (X)
            transform.parent.parent.position = new Vector3(curPosition.x, transform.parent.parent.position.y, transform.parent.parent.position.z);
        if (Y)
            transform.parent.parent.position = new Vector3(transform.parent.parent.position.x, curPosition.y, transform.parent.parent.position.z);
        if (Z)
            transform.parent.parent.position = new Vector3(transform.parent.parent.position.x, transform.parent.parent.position.y, curPosition.z);
        base.MouseDrag();
    }
}
