using NVIDIA.Flex;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

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
    
    /***************************************************FUNCITONS***********************************************************/
    //Functions


    public void Start()
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
    }

    /***************************************************************COHESION***********************************************************************/
    /*
     Cette fonciton viens modifier la cohesion grace a un slider
    */
    public void ChangeCohesionOnSliderChange()
    {
        flexContainer.cohesion = SliderCohesion.value;
        ChangeInputOnSliderChangeCohesion(SliderCohesion.value);
    }
    /*
     * Cette fonction permet l'update de la valeur de l'inputField en fonction de la valeur du slider
     */

    public void ChangeInputOnSliderChangeCohesion(float newValue)
    {
        IFCohesion.text = newValue.ToString();
    }
    /*
     *Cette fonction viens modifier la cohesion grace a un input
     */
    public void ChangeCohesionOnInputChange()
    {
        flexContainer.cohesion = float.Parse(IFCohesion.text);
        print(IFCohesion.text);
        ChangeSliderOnInputChangeCohesion(float.Parse(IFCohesion.text));
    }

    /*
     * Cette fonction permet l'update de la valeur du slider en fonction de la valeur de l'inputField
     */
    public void ChangeSliderOnInputChangeCohesion(float newValue)
    {
        if (newValue > SliderCohesion.maxValue)
        {
            while (newValue > SliderCohesion.maxValue)
            {
                SliderCohesion.maxValue = SliderCohesion.maxValue * 10;
            }
        }
        else
        {
            while (newValue < SliderCohesion.maxValue)
            {
                SliderCohesion.maxValue = SliderCohesion.maxValue / 10;
            }
        }

        SliderCohesion.value = newValue;
    }

    /******************************************************************TENSION****************************************************/

    /*
     Cette fonciton viens modifier la cohesion grace a un slider
    */
    public void ChangeTensionOnSliderChange()
    {
        flexContainer.surfaceTension = SliderTension.value;
        ChangeInputOnSliderChangeTension(SliderTension.value);
    }
    /*
     * Cette fonction permet l'update de la valeur de l'inputField en fonction de la valeur du slider
     */

    public void ChangeInputOnSliderChangeTension(float newValue)
    {
        IFTension.text = newValue.ToString();
    }
    /*
     *Cette fonction viens modifier la cohesion grace a un input
     */
    public void ChangeTensionOnInputChange()
    {
        flexContainer.surfaceTension = float.Parse(IFTension.text);
        print(IFTension.text);
        ChangeSliderOnInputChangeTension(float.Parse(IFTension.text));
    }

    /*
     * Cette fonction permet l'update de la valeur du slider en fonction de la valeur de l'inputField
     */
    public void ChangeSliderOnInputChangeTension(float newValue)
    {
        if (newValue > SliderTension.maxValue)
        {
            while (newValue > SliderTension.maxValue)
            {
                SliderTension.maxValue = SliderTension.maxValue * 10;
            }
        }
        else
        {
            while (newValue < SliderTension.maxValue)
            {
                SliderTension.maxValue = SliderTension.maxValue / 10;
            }
        }

        SliderTension.value = newValue;
    }

    /***************************************************************VISCOSITY***********************************************************************/
    /*
     Cette fonciton viens modifier la cohesion grace a un slider
    */
    public void ChangeViscosityOnSliderChange()
    {
        flexContainer.viscosity = SliderViscosity.value;
        ChangeInputOnSliderChangeViscosity(SliderViscosity.value);
    }
    /*
     * Cette fonction permet l'update de la valeur de l'inputField en fonction de la valeur du slider
     */

    public void ChangeInputOnSliderChangeViscosity(float newValue)
    {
        IFViscosity.text = newValue.ToString();
    }
    /*
     *Cette fonction viens modifier la cohesion grace a un input
     */
    public void ChangeViscosityOnInputChange()
    {
        flexContainer.viscosity = float.Parse(IFViscosity.text);
        print(IFViscosity.text);
        ChangeSliderOnInputChangeViscosity(float.Parse(IFViscosity.text));
    }

    /*
     * Cette fonction permet l'update de la valeur du slider en fonction de la valeur de l'inputField
     */
    public void ChangeSliderOnInputChangeViscosity(float newValue)
    {
        if (newValue > SliderViscosity.maxValue)
        {
            while (newValue > SliderViscosity.maxValue)
            {
                SliderViscosity.maxValue = SliderViscosity.maxValue * 10;
            }
        }
        else
        {
            while (newValue < SliderViscosity.maxValue)
            {
                SliderViscosity.maxValue = SliderViscosity.maxValue / 10;
            }
        }

        SliderViscosity.value = newValue;
    }

    /***************************************************************ADHESION***********************************************************************/
    /*
     Cette fonciton viens modifier la cohesion grace a un slider
    */
    public void ChangeAdhesionOnSliderChange()
    {
        flexContainer.adhesion = SliderAdhesion.value;
        ChangeInputOnSliderChangeAdhesion(SliderAdhesion.value);
    }
    /*
     * Cette fonction permet l'update de la valeur de l'inputField en fonction de la valeur du slider
     */

    public void ChangeInputOnSliderChangeAdhesion(float newValue)
    {
        IFAdhesion.text = newValue.ToString();
    }
    /*
     *Cette fonction viens modifier la cohesion grace a un input
     */
    public void ChangeAdhesionOnInputChange()
    {
        flexContainer.adhesion = float.Parse(IFAdhesion.text);
        print(IFAdhesion.text);
        ChangeSliderOnInputChangeAdhesion(float.Parse(IFAdhesion.text));
    }

    /*
     * Cette fonction permet l'update de la valeur du slider en fonction de la valeur de l'inputField
     */
    public void ChangeSliderOnInputChangeAdhesion(float newValue)
    {
        if (newValue > SliderAdhesion.maxValue)
        {
            while (newValue > SliderAdhesion.maxValue)
            {
                SliderAdhesion.maxValue = SliderAdhesion.maxValue * 10;
            }
        }
        else
        {
            while (newValue < SliderAdhesion.maxValue)
            {
                SliderAdhesion.maxValue = SliderAdhesion.maxValue / 10;
            }
        }

        SliderAdhesion.value = newValue;
    }

}


