using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UILeave : MonoBehaviour
{
    public void OnClick()
    {
        Application.Quit(0);
    }
}