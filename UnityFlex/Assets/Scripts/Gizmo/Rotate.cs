using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public class Rotate : XYZ
{
    public int speed = 10;
    public override void MouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.parent.parent.parent.position);

        offset = Ggizmo.goSelect.transform.rotation.eulerAngles - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        base.MouseDown();
    }
    public override void MouseDrag()
    {
        print("OFFSET: " + offset);
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curRotation = new Vector3(Camera.main.ScreenToWorldPoint(curScreenPoint).x * speed + offset.x, Camera.main.ScreenToWorldPoint(curScreenPoint).y * speed + offset.y, Camera.main.ScreenToWorldPoint(curScreenPoint).z * speed + offset.z);
        
        if (X)
            Ggizmo.rotation = Quaternion.Euler(curRotation.x, Ggizmo.goSelect.transform.rotation.eulerAngles.y, Ggizmo.goSelect.transform.rotation.eulerAngles.z); //X
        if (Y)
            Ggizmo.rotation = Quaternion.Euler(Ggizmo.goSelect.transform.rotation.eulerAngles.x, curRotation.y, Ggizmo.goSelect.transform.rotation.eulerAngles.z); //Y
        if (Z)
            Ggizmo.rotation = Quaternion.Euler(Ggizmo.goSelect.transform.rotation.eulerAngles.x, Ggizmo.goSelect.transform.rotation.eulerAngles.y, curRotation.z); //Z
        base.MouseDrag();
    }
}
