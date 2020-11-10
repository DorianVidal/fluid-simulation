using NVIDIA.Flex;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;

public class UIParameters : MonoBehaviour
{
    /***************************************************PROPERTIES***********************************************************/
    //Flex
    public FlexContainer flexContainer;

    //UI**************************

    //SLiders
    public Slider SliderCohesion;
    public Slider SliderTension;
    public Slider SliderViscosity;
    public Slider SliderAdhesion;
    

    //InputFieds
    public InputField IFCohesion;
    public InputField IFTension;
    public InputField IFViscosity;
    public InputField IFAdhesion;


    //Materials
    private Renderer rd;
    public GameObject aort;
    
    /***************************************************FUNCITONS***********************************************************/
    //Functions


    private void Start()
    {
        SliderCohesion.minValue = 0;
        SliderCohesion.maxValue = 1;
        IFCohesion.text = "0";

        SliderTension.minValue = 0;
        SliderTension.maxValue = 1;
        IFTension.text = "0";

        SliderViscosity.minValue = 0;
        SliderViscosity.maxValue = 1;
        IFViscosity.text = "0";

        SliderAdhesion.minValue = 0;
        SliderAdhesion.maxValue = 1;
        IFAdhesion.text = "0";


        rd = GameObject.FindGameObjectWithTag("aort").GetComponent<Renderer>();
        Debug.Log(rd);
    }

    public void InputChange(InputField inputField)
    {

        //COHESION
        if(inputField.name == IFCohesion.name)
        {
            flexContainer.cohesion = float.Parse(inputField.text);
            if (flexContainer.cohesion > SliderCohesion.maxValue)
            {
                while (flexContainer.cohesion > SliderCohesion.maxValue)
                {
                    SliderCohesion.maxValue = SliderCohesion.maxValue * 10;
                }
            }
            else
            {
                while (flexContainer.cohesion < SliderAdhesion.maxValue)
                {
                    SliderCohesion.maxValue = SliderCohesion.maxValue / 10;
                }
            }
            SliderCohesion.value = flexContainer.cohesion;
        }

        //TENSION
        if (inputField.name == IFTension.name)
        {
            flexContainer.surfaceTension = float.Parse(inputField.text);
            if (flexContainer.surfaceTension > SliderTension.maxValue)
            {
                while (flexContainer.surfaceTension > SliderTension.maxValue)
                {
                    SliderTension.maxValue = SliderTension.maxValue * 10;
                }
            }
            else
            {
                while (flexContainer.surfaceTension < SliderTension.maxValue)
                {
                    SliderTension.maxValue = SliderTension.maxValue / 10;
                }
            }
            SliderTension.value = flexContainer.surfaceTension;
        }

        //VISCOSITY
        if (inputField.name == IFViscosity.name)
        {
            flexContainer.viscosity = float.Parse(inputField.text);
            if (flexContainer.viscosity > SliderViscosity.maxValue)
            {
                while (flexContainer.viscosity > SliderViscosity.maxValue)
                {
                    SliderViscosity.maxValue = SliderViscosity.maxValue * 10;
                }
            }
            else
            {
                while (flexContainer.viscosity < SliderViscosity.maxValue)
                {
                    SliderViscosity.maxValue = SliderViscosity.maxValue / 10;
                }
            }
            SliderViscosity.value = flexContainer.viscosity;
        }

        //ADHESION
        if (inputField.name == IFAdhesion.name)
        {
            flexContainer.adhesion = float.Parse(inputField.text);
            if (flexContainer.adhesion > SliderAdhesion.maxValue)
            {
                while (flexContainer.adhesion > SliderAdhesion.maxValue)
                {
                    SliderAdhesion.maxValue = SliderAdhesion.maxValue * 10;
                }
            }
            else
            {
                while (flexContainer.adhesion < SliderAdhesion.maxValue)
                {
                    SliderAdhesion.maxValue = SliderAdhesion.maxValue / 10;
                }
            }
            SliderAdhesion.value = flexContainer.adhesion;
        }

    }


    //Cette fonction permet la modification en temps réel du container quand un slider est modifier,
    //elle permet aussi la modification de la valeur du champ de texte quand un slider et modifié
    public void SliderChange(Slider slider)
    {
        //Cohesion
        if (slider.name == SliderCohesion.name)
        {
            flexContainer.cohesion = slider.value;
            IFCohesion.text = slider.value.ToString();
        }
        //Tension
        if (slider.name == SliderTension.name)
        {
            flexContainer.surfaceTension = slider.value;
            IFTension.text = slider.value.ToString();
        }
        //Viscosity
        if (slider.name == SliderViscosity.name)
        {
            flexContainer.viscosity = slider.value;
            IFViscosity.text = slider.value.ToString();
        }
        //Adhesion
        if (slider.name == SliderAdhesion.name)
        {
            flexContainer.adhesion = slider.value;
            IFAdhesion.text = slider.value.ToString();
        }
    }

    public void LoadValue(float cohesion, float tension, float viscosity, float adhesion)
    {
        //Reattribution des valeur pour le containeur
        flexContainer.cohesion = cohesion;
        flexContainer.surfaceTension = tension;
        flexContainer.viscosity = viscosity;
        flexContainer.adhesion = adhesion;       

        //Mis à jour des valeur dse input field
        IFCohesion.text = cohesion.ToString();
        IFTension.text = tension.ToString();
        IFViscosity.text = viscosity.ToString();
        print(IFViscosity.text);
        IFAdhesion.text = adhesion.ToString();

        //mise à jour des sliders
        updateSlider(SliderCohesion, cohesion);
        updateSlider(SliderTension, tension);
        updateSlider(SliderViscosity, viscosity);
        updateSlider(SliderAdhesion, adhesion);

    }

    private void updateSlider(Slider slider, float value)
    {
        if (value > slider.maxValue)
        {
            while(value > slider.maxValue)
            {
                slider.maxValue = slider.maxValue * 10;
            }
        }
        if (value < slider.maxValue)
        {
            slider.maxValue = slider.maxValue / 10;
        }
        slider.value = value;
    }


    public void ChangeTransparency(Slider sliderTransparency)
    {        
       rd.material.SetFloat("Transparency", sliderTransparency.value);
    }
}