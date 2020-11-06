using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : XYZ
{
    public override void MouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.parent.parent.position);

        offset = Ggizmo.goSelect.transform.localScale - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        base.MouseDown();
    }
    public override void MouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        if (X)
            Ggizmo.V3Scale = new Vector3(curPosition.x, Ggizmo.V3Scale.y, Ggizmo.V3Scale.z);
        if (Y)
            Ggizmo.V3Scale = new Vector3(Ggizmo.V3Scale.x, curPosition.y, Ggizmo.V3Scale.z);
        if (Z)
            Ggizmo.V3Scale = new Vector3(Ggizmo.V3Scale.x, Ggizmo.V3Scale.y, curPosition.z);
        base.MouseDrag();
    }
}
