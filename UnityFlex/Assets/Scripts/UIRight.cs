using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class UIRight : MonoBehaviour
{
    public GameObject Panel;
    private void Update()
    {
        print(Panel.GetComponent<Animator>().GetBool("Open"));
        if (Input.mousePosition.x / Screen.width > 0.794f)
        {
            Panel.GetComponent<Animator>().SetBool("Open", true);
        }
        else
        {
            Panel.GetComponent<Animator>().SetBool("Open", false);
        }
    }
}
