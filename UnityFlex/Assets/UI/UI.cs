using NVIDIA.Flex;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{

    
    /***************************************************PROPERTIES***********************************************************/
    //Flex
    public FlexContainer flexContainer;

    //UI**************************

    //SLiders
    public Slider SliderCohesion;
    public Slider SliderTension;
    public Slider SliderViscosity;
    public Slider SliderVorticity;

    //InputFieds
    public InputField IFCohesion;
    public InputField IFTension;
    public InputField IFViscosity;
    public InputField IFVorticity;

    public InputField InputNumber;
    

    /***************************************************FUNCITONS***********************************************************/
    //Functions
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
    }

    public void Start()
    {
        SliderCohesion.minValue = 0;
        SliderCohesion.maxValue = 1;
        IFCohesion.text = "0.22";

        SliderTension.minValue = 0;
        SliderTension.maxValue = 1;
        IFTension.text = "0.22";

        SliderViscosity.minValue = 0;
        SliderViscosity.maxValue = 1;
        IFViscosity.text = "0.22";

        SliderVorticity.minValue = 0;
        SliderVorticity.maxValue = 1;
        IFVorticity.text = "0.22";

    }

    public void ChangeCohesion()
    {
       flexContainer.cohesion = SliderCohesion.value;
    }
   

    public void ChangeTension_Slider()
    {
        flexContainer.surfaceTension = SliderTension.value;
    }

    public void ChangeTension_InputField()
    {
        flexContainer.surfaceTension = int.Parse(SliderTension.value);
    }

    public void ChangeTension_SliderValue(int value)
    {
        float Max = SliderTension.maxValue;
        float NewMax = 
        if()
    }

    public void ChangeTension_IputFieldValue(int value)
    {

    }


}
