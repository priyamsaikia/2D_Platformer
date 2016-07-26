using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {
    public float currentHealt;
    public float maxHealth;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addHealth(float healthAmt)
    {
        currentHealt += healthAmt;
        if (currentHealt > maxHealth)
        {
            currentHealt = maxHealth;
        }
    }
}
