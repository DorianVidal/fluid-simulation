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
    public Slider SliderAdhesion;
    //public Slider SliderVorticity;

    //InputFieds
    public InputField IFCohesion;
    public InputField IFTension;
    public InputField IFViscosity;
    public InputField IFAdhesion;
    //public InputField IFVorticity;

    //public InputField InputNumber; //Cet attribut influe sur le nombre de particule en temps rééls (pas possible pour le moment)


    /***************************************************FUNCITONS***********************************************************/
    //Functions
    public void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

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
        /*
        SliderVorticity.minValue = 0;
        SliderVorticity.maxValue = 1;
        IFVorticity.text = "0.22";*/

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
        if (newValue > 1)
        {
            SliderCohesion.maxValue = 10;
        }
        else
        {
            SliderCohesion.maxValue = 1;
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
        if (newValue > 1)
        {
            SliderTension.maxValue = 10;
        }
        else
        {
            SliderTension.maxValue = 1;
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
        if (newValue > 1)
        {
            SliderViscosity.maxValue = 10;
        }
        else
        {
            SliderViscosity.maxValue = 1;
        }
        SliderTension.value = newValue;
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
        if (newValue > 1)
        {
            SliderAdhesion.maxValue = 10;
        }
        else
        {
            SliderAdhesion.maxValue = 1;
        }
        SliderAdhesion.value = newValue;
    }

}
