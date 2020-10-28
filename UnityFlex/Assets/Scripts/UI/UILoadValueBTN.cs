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

    public void LoadValues()
    {
        string FileName = TextReference.text;
        
        string saveString = File.ReadAllText(Application.dataPath + "/" + FileName);
       
        
        string[] content = saveString.Split(new[] { saveSeparator }, System.StringSplitOptions.None);

        Cohesion = float.Parse(content[0]);
        tension = float.Parse(content[1]);
        viscosity = float.Parse(content[2]);
        adhesion = float.Parse(content[3]);
        
        ChangeValues();
    }

    void ChangeValues()
    {
        print(Cohesion);
        print(tension);
        print(viscosity);
        print(adhesion);

        UIReference.IFCohesion.text = Cohesion.ToString();
        UIReference.ChangeSliderOnInputChangeCohesion(float.Parse(UIReference.IFCohesion.text));
        UIReference.IFTension.text = tension.ToString();
        UIReference.ChangeSliderOnInputChangeTension(float.Parse(UIReference.IFTension.text));
        UIReference.IFViscosity.text = viscosity.ToString();
        UIReference.ChangeSliderOnInputChangeViscosity(float.Parse(UIReference.IFViscosity.text));
        UIReference.IFAdhesion.text = adhesion.ToString();
        UIReference.ChangeSliderOnInputChangeAdhesion(float.Parse(UIReference.IFAdhesion.text));


        print(flex.cohesion);
        print(flex.surfaceTension);
        print(flex.viscosity);
        print(flex.adhesion);


        UIReference.UpdateOnLoad(flex);
    }

    public void Delete()
    {
        string FileName = TextReference.text;
        File.Delete(Application.dataPath + "/" + FileName);
        Destroy(this.gameObject);
    }
}
