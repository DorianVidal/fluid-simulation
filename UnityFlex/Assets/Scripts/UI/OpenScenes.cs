﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenScenes : MonoBehaviour
{
    public Button ArrayActor_btn;
    public void OnClickBtn(Text BtnName)
    {
        print(BtnName.text);
        SceneManager.LoadScene(BtnName.text);
    }
}