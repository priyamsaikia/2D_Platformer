using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {
    float currentHealth;
    public float fullHealth;
    PlayerController controlMovement;
    public GameObject deathFX;
    public Slider healthSlider;
    // Use this for initialization
    void Start () {
        currentHealth = fullHealth;
        controlMovement = GetComponent<PlayerController>();
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;
      	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        
        if (currentHealth <= 0)
            makeDead();
    }

    public void makeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        healthSlider.value = 0;
    }


   /* public void addHealth(float healthAmt)
    {
        currentHealth += healthAmt;
        if (currentHealth > fullHealth)
        {
            currentHealth = fullHealth;
        }
    }*/

}
