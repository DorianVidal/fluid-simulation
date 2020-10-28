using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public GameObject MainMenuCanvas;
    public GameObject CanvasModifieParameters;
    public GameObject CanvasSavePreset;
    public GameObject ReturnButton;

    public string CurrentSceneName;

    private GameObject Canvas;
    private GameObject Canvas2;
    private GameObject Canvas3;

    private void Awake()
    {
        //This if permit the verification to know if the instance is a singleton
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            //AJOUTER ICI LE CODE SUPPLEMENTAIRE DE L'AWAKE
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if (CurrentSceneName != SceneManager.GetActiveScene().name)
        {
            updateCanvas(SceneManager.GetActiveScene().name);
            CurrentSceneName = SceneManager.GetActiveScene().name;
        }        
    }
    public void updateCanvas(string name)
    {      

        switch(SceneManager.GetActiveScene().name)
        {
            case "Menu":
                Canvas = Instantiate(MainMenuCanvas) as GameObject;
                break;
            case "Aort":
                initialiseAort();
                break;            
            default:
                Canvas = Instantiate(ReturnButton) as GameObject;
                break;
        }
    }

    private void initialiseAort()
    {
        Canvas = Instantiate(CanvasModifieParameters) as GameObject;
        Canvas2 = Instantiate(CanvasSavePreset) as GameObject;
        Canvas3 = Instantiate(ReturnButton) as GameObject;
    }
}
