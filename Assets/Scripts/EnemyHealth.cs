using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float enemyMaxHealth;
    public float damageModifier;
    //public GameObject damageParticles;
    public bool drops;
    public GameObject drop;
    public bool canBurn;
    public float burnDamage;
    public GameObject burnEffects;
    public float burnTime;
    public GameObject wall;

    public GameObject hitEffect;

    bool onFire;
    float nextBurn;
    float burnInterval = 1f;
    float endBurn;

    float currentHealth;
    bool stun;

    AudioSource enemyAS;
    public AudioClip deathSound;
    public Slider enemyHealthIndicator;
    

	// Use this for initialization
	void Start () {
        currentHealth = enemyMaxHealth;
        enemyHealthIndicator.maxValue = enemyMaxHealth;
        enemyHealthIndicator.value = currentHealth;
        enemyAS = GetComponent<AudioSource>();
        stun = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(onFire && Time.time > nextBurn)
        {
            addDamage(burnDamage);
            nextBurn += burnInterval;
        }

        if(onFire && Time.time > endBurn)
        {
            onFire = false;
            burnEffects.SetActive(false);
        }
	}

    public void addDamage(float damage)
    {
        enemyHealthIndicator.gameObject.SetActive(true); //turns on the visibility of the floating enemy hud
        damage = damage * damageModifier;

        if (damage <= 0) return;
        currentHealth -= damage;
        enemyHealthIndicator.value = currentHealth;
        stun = true;
        //enemyAS.Play();
        if (currentHealth <= 0) {
            makeDead();
            wall.SetActive(false);
            
        } 
        Instantiate(hitEffect, gameObject.transform);
    }

    /*public void damageFX(Vector3 point, Vector3 rotation)
    {
        Instantiate(damageParticles, point, Quaternion.Euler(rotation));
    }*/

    public void addFire()
    {
        if (!canBurn) return;
        onFire = true;
        burnEffects.SetActive(true);
        endBurn = Time.time + burnTime;
        nextBurn = Time.time + burnInterval;

    }

    void makeDead()
    {
        //Turn off movement and create ragdoll
        AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.15f);

        Destroy(gameObject.transform.root.gameObject);
        if (drops) Instantiate(drop, transform.position, Quaternion.identity);

    }

    public bool GetStun()
    {
        return stun;
    }
}
