using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public GameObject MainMenuCanvas;
    public GameObject CanvasModifieParameters;
    public GameObject CanvasSavePreset;
    public GameObject ReturnButton;

    public EventSystem eventSystem;

    private string CurrentSceneName;

    private List<GameObject>lstCanvas;

    private void Awake()
    {
        //This if permit the verification to know if the instance is a singleton
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
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
        lstCanvas = new List<GameObject>();

        switch(SceneManager.GetActiveScene().name)
        {
            case "Menu":
                lstCanvas.Add(Instantiate(MainMenuCanvas) as GameObject);
                break;
            case "Aort":
                initialiseAort();
                break;
            case "Array Actor":
                lstCanvas.Add(Instantiate(ReturnButton) as GameObject);
                //eventSystem = Instantiate(eventSystem) as EventSystem;
                break;
            default:
                lstCanvas.Add(Instantiate(ReturnButton) as GameObject);
                //eventSystem = Instantiate(eventSystem) as EventSystem;                
                break;
        }
    }

    private void initialiseAort()
    {
        lstCanvas.Add(Instantiate(CanvasModifieParameters) as GameObject);
        lstCanvas.Add(Instantiate(CanvasSavePreset) as GameObject);
        lstCanvas.Add(Instantiate(ReturnButton) as GameObject);
    }
}
