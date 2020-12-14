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
    bool toggle = true;
    bool toggle2 = true;

    //Flex
    public FlexContainer flexContainer;

    //LineTrace   
    private GameObject lineParticles;
    private GameObject PressionParticles;

    //Materials
    private Renderer rd;
    public GameObject aort;

    //UI**************************

    //SLiders
    public Slider SliderCohesion;
    public Slider SliderTension;
    public Slider SliderViscosity;
    public Slider SliderAdhesion;

    public Slider SliderTransparency;
    

    //InputFieds
    public InputField IFCohesion;
    public InputField IFTension;
    public InputField IFViscosity;
    public InputField IFAdhesion;

    //Toggle
    public Toggle TGTrajectories;

    //Buttons
    public Button BtnCalculTraj;
    public Button BtnCalculPression;
    /***************************************************FUNCTIONS***********************************************************/
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


        lineParticles = GameObject.FindObjectOfType<DrawLinesParticles>().gameObject;
        lineParticles.SetActive(toggle);

        PressionParticles = GameObject.FindObjectOfType<DrawParticlesSoft>().gameObject;
        PressionParticles.SetActive(toggle2);

        rd.material.SetFloat("Transparency", 1.0f);

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
        //rd.material.SetFloat("Transparency", sliderTransparency.value);
        rd.material.color = new Color(rd.material.color.r, rd.material.color.g, rd.material.color.b, sliderTransparency.value);
        //rd.material.color.a = sliderTransparency.value;
        
    }

    public void DisplayLineTrace()
    {
        toggle = !toggle;

        //BtnCalculTraj.interactable(TGTrajectories.GetComponent<Toggle>().isOn);
        BtnCalculTraj.interactable = toggle;
        lineParticles.SetActive(toggle);    
    }
    public void DisplayPression()
    {
        toggle2 = !toggle2;

        //BtnCalculTraj.interactable(TGTrajectories.GetComponent<Toggle>().isOn);
        BtnCalculPression.interactable = toggle2;
        PressionParticles.SetActive(toggle2);
    }

    public void CalculLines()
    {
        lineParticles.GetComponent<DrawLinesParticles>().CalculeTraj();
    }

    public void CalculPression()
    {
        PressionParticles.GetComponent<DrawParticlesSoft>().CalculePression();
    }
}