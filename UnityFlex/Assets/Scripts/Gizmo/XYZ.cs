using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XYZ : MonoBehaviour
{
    [HideInInspector] public Vector3 screenPoint;
    [HideInInspector] public Vector3 offset;
    [HideInInspector] public Gizmo Ggizmo;

    public bool X;
    public bool Y;
    public bool Z;

    private void Start()
    {
        Ggizmo = GetComponentInParent<Gizmo>();
    }

    public virtual void MouseDown()
    {

    }

    public virtual void MouseDrag()
    {

    }
}
