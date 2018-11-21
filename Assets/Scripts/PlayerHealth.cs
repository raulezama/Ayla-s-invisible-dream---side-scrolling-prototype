using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float fullHealth;
	private float currentHealth;
    public LevelManager levelManager;


	private Animator anim;
	//HUD
	public Slider playerHealthSlider;

	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;	
		playerHealthSlider.maxValue = fullHealth;
		playerHealthSlider.value = currentHealth;
		anim = GetComponent<Animator>();

        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
    /// <summary>
    /// Causa daño a la barra de salud del jugador
    /// </summary>
    /// <param name="damage">Valor del daño a causar</param>
	public void AddDamage(float damage){
		currentHealth -= damage;
		playerHealthSlider.value = currentHealth;
		SaveSystem.health = currentHealth;
		anim.SetTrigger("damaged");
		if(currentHealth <= 0){
			MakeDead();
		}
	}

    /// <summary>
    /// Recupera salud en la barra de vida del jugador
    /// </summary>
    /// <param name="healthRestored">Valor del monto de salud recuperada</param>
	public void AddHealth(float healthRestored)
	{
		currentHealth += healthRestored;
		if(currentHealth > fullHealth)
			currentHealth = fullHealth;
			playerHealthSlider.value = currentHealth;
			SaveSystem.health = currentHealth;
	}

    /// <summary>
    /// Destruye el modelo del jugador de la escena
    /// </summary>
	public void MakeDead(){

        //Destroy(gameObject);
        levelManager.RespawnPlayer();
        currentHealth = fullHealth;
        playerHealthSlider.value = currentHealth;
	}
}
