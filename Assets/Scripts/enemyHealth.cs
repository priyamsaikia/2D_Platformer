using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {
   float currentHealth;
   public float maxEnemyHealth;

	// Use this for initialization
	void Start () {
        currentHealth = maxEnemyHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void makeDead()
    {
        Destroy(gameObject);
    }

    public void addDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            makeDead();
    }

    
}
