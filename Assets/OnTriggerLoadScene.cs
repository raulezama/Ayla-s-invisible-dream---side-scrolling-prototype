using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnTriggerLoadScene : MonoBehaviour {

    public GameObject guiObject;
    public string levelToLoad;
    public Image fadeImage;
    public Animator anim;


	// Use this for initialization
	void Start () {
        guiObject.SetActive(false);
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            guiObject.SetActive(true);
            if(guiObject.activeInHierarchy == true && Input.GetKeyDown("e"))
            {
                StartCoroutine(Fading());

            }
        }
    }

    
    private void OnTriggerExit()
    {
        guiObject.SetActive(false);
    }

    IEnumerator Fading()
    {
        anim.SetBool("fade", true);
        yield return new WaitUntil(() => fadeImage.color.a == 1);
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
    }
}
