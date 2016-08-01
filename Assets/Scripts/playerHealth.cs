using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {
    float currentHealth;
    public float fullHealth;
    PlayerController controlMovement;
    public GameObject deathFX;
    //health Indicator
    public Slider healthSlider;
    //damage Indicator
    float smoothColor = 15f;
    Color damagedColor= new Color(0f, 0f, 0f, 0.5f);
    bool damaged = false;
    public Image damageScreen;

    public AudioClip playerDeathSound;
    public Text gameOverText;
    public Text gameWinText;


    //sound effects
    public AudioClip playerHurt;
    AudioSource playerAS;

    public RestartGame restartGame;
    
    // Use this for initialization
    void Start () {
        currentHealth = fullHealth;
        controlMovement = GetComponent<PlayerController>();
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

        playerAS = GetComponent<AudioSource>();
      	}
	
	// Update is called once per frame
	void Update () {
        if (damaged)
        {
            damageScreen.color = damagedColor;
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor);
        }
        damaged = false;
	}

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        damaged = true;

        playerAS.clip = playerHurt;
        playerAS.Play();
        
        if (currentHealth <= 0)
            makeDead();
    }

    public void makeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(playerDeathSound, transform.position);
        
        healthSlider.value = 0;

        damageScreen.color = damagedColor;
        Animator gameOverAnimator = gameOverText.GetComponent<Animator>();
        gameOverAnimator.SetTrigger("gameOver");
        restartGame.RestartTheGame();
    }


   /* public void addHealth(float healthAmt)
    {
        currentHealth += healthAmt;
        if (currentHealth > fullHealth)
        {
            currentHealth = fullHealth;
        }
    }*/

    public void addHealth(float healthAmout)
    {
        currentHealth += healthAmout;
        if (currentHealth > fullHealth)
            currentHealth = fullHealth;

        healthSlider.value = currentHealth;
    }


    public void WinGame()
    {
        Destroy(gameObject);
        restartGame.RestartTheGame();
        Animator winGameAnimator = gameWinText.GetComponent<Animator>();
        winGameAnimator.SetTrigger("gameOver");
    }
}
