using UnityEngine;
using System.IO;
using NVIDIA.Flex;

/*
 * Auteur : Dorian Vidal 
 * 
 * Ce script permet la sauvegarde en local des variables d'un preset
 */


public class Save : MonoBehaviour
{
    public FlexContainer flex;
    public float Cohesion;
    public float tension;
    public float viscosity;
    public float adhesion;

    void SaveDatas()
    {
        Cohesion = flex.cohesion;
        tension = flex.surfaceTension;
        viscosity = flex.viscosity;
        adhesion = flex.adhesion;
        File.WriteAllText(Application.dataPath + "/data.txt", Cohesion, tension, viscosity, adhesion); //Viens creer dans le dossier assets un fichier avec toutes les donées sauvegardées
    }

    void LoadDatas()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveDatas();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveDatas();
        }

    }
}
