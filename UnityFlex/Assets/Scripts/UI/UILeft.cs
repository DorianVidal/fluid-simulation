using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILeft : MonoBehaviour
{
    public GameObject Panel;
    private void Update()
    {
        if (Input.mousePosition.x / Screen.width < 0.206f)
        {
            Panel.GetComponent<Animator>().SetBool("Open", true);
            //print("Open");
        }
        else
        {
            Panel.GetComponent<Animator>().SetBool("Open", false);
            //print("Close");
        }
    }
}
