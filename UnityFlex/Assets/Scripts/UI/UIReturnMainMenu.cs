using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIReturnMainMenu : MonoBehaviour
{
    public void onClick()
    {
        SceneManager.UnloadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Menu");
    }
}
