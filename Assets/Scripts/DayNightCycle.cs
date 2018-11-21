using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

    public Material firstLight;
    public Material dayMat;
    public Material midDay;
    public Material nightMat;

    public List<GameObject> torchList;

	// Use this for initialization
	void Start () {
		
	}


	
	// Update is called once per frame

        /// <summary>
        /// Llama a la función paulatinamente para verificar la hora en tiempo real
        /// </summary>
	void Update () {
        changeSky();
	}

    /// <summary>
    /// Esta función compara la hora del ordenador 
    /// para poder escoger entre un skybox u otro
    /// </summary>

    public void changeSky()
    {
        float hours = System.DateTime.Now.Hour;

        if(hours >= 7 && hours < 11)
        {
            RenderSettings.skybox = firstLight;
            TorchControlOff();
        }
        else if(hours >= 11 && hours < 17)
        {
            RenderSettings.skybox = dayMat;
            TorchControlOff();
        }
        else if(hours >= 17 && hours < 22)
        {
            RenderSettings.skybox = midDay;
            TorchControlOn();
        }
        else
        {
            RenderSettings.skybox = nightMat;
            TorchControlOn();
        }
    }

    void TorchControlOn()
    {
        foreach (var item in torchList)
        {
            item.SetActive(true);
        }
    }

    void TorchControlOff()
    {
        foreach (var item in torchList)
        {
            item.SetActive(false);
        }
    }


}
