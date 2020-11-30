using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIPresetsList : MonoBehaviour
{

    public GameObject ButtonPrefabsReference;
    public GameObject ListReference;
    
    private void Start()
    {
        DirectoryInfo dir = new DirectoryInfo(Application.dataPath);
        FileInfo[] info = dir.GetFiles("*.txt");

        foreach (FileInfo file in info)
        {
            GameObject NewBtn = Instantiate(ButtonPrefabsReference) as GameObject;
            NewBtn.transform.SetParent(ListReference.transform, false);
            Text TxtBtn = NewBtn.GetComponentInChildren<Text>();
            TxtBtn.text = file.Name;
            print("Nouveau Bouton Ajouté :" + TxtBtn.text);
        }        
    }
    public void DeleteList()
    {
        Destroy(gameObject);
    }
}
