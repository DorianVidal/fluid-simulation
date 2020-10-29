using NVIDIA.Flex;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Diagnostics;

public class UILoadValueBTN : MonoBehaviour
{
    public Text TextReference;

    public FlexContainer flex;

    private float Cohesion;
    private float tension;
    private float viscosity;
    private float adhesion;

    public UIParameters UIReference;

    private string saveSeparator = "%VALUE%";

    private void Start()
    {
        UIReference = FindObjectOfType<UIParameters>();
    }

    public void LoadValues()
    {
        string FileName = TextReference.text;
        
        string saveString = File.ReadAllText(Application.dataPath + "/" + FileName);
       
        
        string[] content = saveString.Split(new[] { saveSeparator }, System.StringSplitOptions.None);

        Cohesion = float.Parse(content[0]);
        tension = float.Parse(content[1]);
        viscosity = float.Parse(content[2]);
        adhesion = float.Parse(content[3]);
        //Ordre des Paramètre, FLOAT->SLIDER->INPUT_FIELD
        UIReference.LoadValue(Cohesion, tension, viscosity, adhesion);
    }

    public void Delete()
    {
        string FileName = TextReference.text;
        File.Delete(Application.dataPath + "/" + FileName);
        Destroy(this.gameObject);
    }
}
