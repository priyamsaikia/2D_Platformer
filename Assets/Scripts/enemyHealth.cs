using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class enemyHealth : MonoBehaviour {
   float currentHealth;
   public float maxEnemyHealth;
   public GameObject enemyDeathFX;
   public Slider enemySlider;
    public bool canDrop;
    public GameObject theDrop;

    public AudioClip deathKnell;//enemyDeath sound

	// Use this for initialization
	void Start () {
        currentHealth = maxEnemyHealth;
        enemySlider.maxValue = maxEnemyHealth;
        enemySlider.value = currentHealth;
        enemySlider.minValue = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void makeDead()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathKnell,transform.position);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if (canDrop)
        {
            Instantiate(theDrop, transform.position, transform.rotation);
        }

    }

    public void addDamage(float damage)
    {
        //show slider when shot
        enemySlider.gameObject.SetActive(true);
        currentHealth -= damage;
        enemySlider.value = currentHealth;
        if (currentHealth <= 0)
            makeDead();
    }

    
}
