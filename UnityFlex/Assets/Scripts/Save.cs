using UnityEngine;
using System.IO;
using NVIDIA.Flex;
using System;
using System.Collections;
using System.Diagnostics;
using UnityScript.Scripting.Pipeline;
using UnityEngine.UI;

/*
 * Auteur : Dorian Vidal 
 * 
 * Ce script permet la sauvegarde en local des variables d'un preset
 *
 * Utilisation : Creer un empty Game Object et lui ajouter le script
 */


public class Save : MonoBehaviour
{
    public FlexContainer flex;

    private float Cohesion;
    private float tension;
    private float viscosity;
    private float adhesion;

    public Button SaveBtn;
    public Button LoadBtn;

    public Button UpdateParticuleNumber;

    public UI UIReference;

    private string saveSeparator = "%VALUE%";//Cette valeur est un separateur de données, pour éviter de corrompre une donnée, on va 
    //ArrayList<float>[4](Cohesion, tension, viscosity; adhesion);

    public void onClickSaveBtn()
    {
        SaveDatas();
        print("ValueSAved");
    }

    public void onClickLoadBtn()
    {
        LoadDatas();
        flex.cohesion = Cohesion;
        flex.surfaceTension = tension;
        flex.viscosity = viscosity;
        flex.adhesion = adhesion;
        // Penser a ajouter cette ligne pour tout les sliders l'UI
        print("Value Loaded" + Cohesion);

        ChangeValue();
    }

    void SaveDatas()
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

        File.WriteAllText(Application.dataPath + "/data.txt", saveString); //Viens creer dans le dossier assets un fichier avec toutes les donées sauvegardées
        
    }

    void LoadDatas()
    {
        string saveString = File.ReadAllText(Application.dataPath + "/data.txt");

        string[] content = saveString.Split(new[] { saveSeparator }, System.StringSplitOptions.None);

        Cohesion = float.Parse(content[0]);
        tension = float.Parse(content[1]);
        viscosity = float.Parse(content[2]);
        adhesion = float.Parse(content[3]);

    }
    void ChangeValue()
    {
        UIReference.IFCohesion.text = Cohesion.ToString();
        UIReference.ChangeSliderOnInputChangeCohesion(float.Parse(UIReference.IFCohesion.text));
        UIReference.IFTension.text = tension.ToString();
        UIReference.ChangeSliderOnInputChangeTension(float.Parse(UIReference.IFTension.text));
        UIReference.IFViscosity.text = viscosity.ToString();
        UIReference.ChangeSliderOnInputChangeViscosity(float.Parse(UIReference.IFViscosity.text));
        UIReference.IFAdhesion.text = adhesion.ToString();
        UIReference.ChangeSliderOnInputChangeAdhesion(float.Parse(UIReference.IFAdhesion.text));
    }
}
