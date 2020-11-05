using UnityEngine;


public class singleton : MonoBehaviour
{
    private static singleton _instance;
    //This if permit the verification to know if the instance is a singleton
    private void Awake()
    {
        //This if permit the verification to know if the instance is a singleton
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
}

