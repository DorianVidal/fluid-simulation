using NVIDIA.Flex;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    //Reference de la scene
    Scene scene = SceneManager.GetActiveScene();

    //Reference de tout les éléments de l'UI


    //Reference du FlexArrayActor
    public FlexArrayActor bloodReference;
    public UI UIReference;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    // Start is called before the first frame update
    public void ChangeMaxParticule(InputField maxParticule)
    {
        
        print(int.Parse(maxParticule.text));
        bloodReference.GetComponent<FlexContainer>().maxParticles = int.Parse(maxParticule.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
