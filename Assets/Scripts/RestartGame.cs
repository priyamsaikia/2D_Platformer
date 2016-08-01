using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {
    public float RestartTimePeriod;
    bool restartNow=false;
    float resetTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (restartNow && resetTime <= Time.time)
        {
            Application.LoadLevel(Application.loadedLevel );
        }
	}

    public void RestartTheGame()
    {
        restartNow = true;
        resetTime = Time.time + RestartTimePeriod;
    }
}
