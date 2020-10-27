using UnityEngine;
using System.IO;
using NVIDIA.Flex;
using System;
using System.Collections;
using System.Diagnostics;
using UnityScript.Scripting.Pipeline;
using UnityEngine.UI;

public class UISaveParameters : MonoBehaviour
{
    public FlexContainer flex;

    private float Cohesion;
    private float tension;
    private float viscosity;
    private float adhesion;

    public Button SaveBtn;
    public Button LoadBtn;

    public InputField FileNameToSave;

    public GameObject CanvasToCreate;


    //public Button UpdateParticuleNumber;

    //public UIParameters UIReference;

    private string saveSeparator = "%VALUE%";//Cette valeur est un separateur de données, pour éviter de corrompre une donnée, on va 

    public void onClickSaveBtn()
    {
        if (FileNameToSave.text != "")
        {
            SaveDatas(FileNameToSave.text);
            print("ValueSAved");
            FileNameToSave.text = "";
        }
    }

    public void onClickLoadBtn()
    {
        GameObject Canvas = Instantiate(CanvasToCreate) as GameObject;
    }

    void SaveDatas(string name)
    {
        Cohesion = flex.cohesion;
        tension = flex.surfaceTension;
        viscosity = flex.viscosity;
        adhesion = flex.adhesion;

        print("Les Valeurs : " + " " + Cohesion + " " + tension + " " + viscosity + " " + adhesion);

        string[] content = new string[]
        {
            Cohesion.ToString(),
            tension.ToString(),
            viscosity.ToString(),
            adhesion.ToString()
        };

        string saveString = string.Join(saveSeparator, content);

        File.WriteAllText(Application.dataPath + "/" + name + ".txt", saveString); //Viens creer dans le dossier assets un fichier avec toutes les donées sauvegardées

    }

    void LoadDatas(string name)
    {



    }
    /*void ChangeValue()
    {
        UIReference.IFCohesion.text = Cohesion.ToString();
        UIReference.ChangeSliderOnInputChangeCohesion(float.Parse(UIReference.IFCohesion.text));
        UIReference.IFTension.text = tension.ToString();
        UIReference.ChangeSliderOnInputChangeTension(float.Parse(UIReference.IFTension.text));
        UIReference.IFViscosity.text = viscosity.ToString();
        UIReference.ChangeSliderOnInputChangeViscosity(float.Parse(UIReference.IFViscosity.text));
        UIReference.IFAdhesion.text = adhesion.ToString();
        UIReference.ChangeSliderOnInputChangeAdhesion(float.Parse(UIReference.IFAdhesion.text));
    }*/



}
