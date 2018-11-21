using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour {

    public Transform Player;
    public Transform CameraS;
    private int firstSave;
    private int checkSave;
    
    void Awake()
    {
        firstSave = 0;

        Debug.Log(PlayerPrefs.GetFloat("x"));
        Debug.Log(PlayerPrefs.GetFloat("y"));
        Debug.Log(PlayerPrefs.GetFloat("z"));

        Debug.Log(PlayerPrefs.GetFloat("camx"));
        Debug.Log(PlayerPrefs.GetFloat("camy"));
        Debug.Log(PlayerPrefs.GetFloat("camz"));

        checkSave = PlayerPrefs.GetInt("save");
        
        if (checkSave > 0)
        {
            Player.position = new Vector3((PlayerPrefs.GetFloat("x")), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
            CameraS.position = new Vector3((PlayerPrefs.GetFloat("camx")), (PlayerPrefs.GetFloat("camy")), PlayerPrefs.GetFloat("camz"));
        }
        else
        {
            PlayerPrefs.DeleteAll();
        }
        
    }

    public void SaveGameProgress(bool Quit)
    {
        PlayerPrefs.SetFloat("x", Player.position.x);
        PlayerPrefs.SetFloat("y", Player.position.y);
        PlayerPrefs.SetFloat("z", Player.position.z);

        PlayerPrefs.SetFloat("camx", CameraS.position.x);
        PlayerPrefs.SetFloat("camy", CameraS.position.y);
        PlayerPrefs.SetFloat("camz", CameraS.position.z);

        PlayerPrefs.SetFloat("camrotx", CameraS.rotation.x);
        PlayerPrefs.SetFloat("camroty", CameraS.rotation.y);
        PlayerPrefs.SetFloat("camrotz", CameraS.rotation.z);
        PlayerPrefs.SetFloat("camrotw", CameraS.rotation.w);


        PlayerPrefs.SetFloat("Cam_y", Player.eulerAngles.y);

        firstSave = 1;
        PlayerPrefs.SetInt("save", firstSave);

        Debug.Log(Player.position + "PlayerPos");
        Debug.Log(CameraS.position + " CameraPos");

        if (Quit)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Menu");
        }

    }
}



