using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {
    float currentHealth;
    public float fullHealth;
    PlayerController controlMovement;
    public GameObject deathFX;
    // Use this for initialization
    void Start () {
        currentHealth = fullHealth;
        controlMovement = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;
        if (currentHealth <= 0)
            makeDead();
    }

    public void makeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }


    public void addHealth(float healthAmt)
    {
        currentHealth += healthAmt;
        if (currentHealth > fullHealth)
        {
            currentHealth = fullHealth;
        }
    }
}
