using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script defines which sprite the 'Player" uses and its health.
/// </summary>

[System.Serializable]
public class ShipStats
{
    public int maxHealth = 100;
    public int currentHealth;
}

public class Player : MonoBehaviour
{
    public ShipStats stats;
    public GameObject destructionFX;

    public static Player instance;

	//----------GAME OVER----------
    public LevelController levelController;
	//-------GAME OVER ENDS--------

	private void Awake()
    {
        if (instance == null) 
            instance = this;
    }

    private void Start()
    {
        Debug.Log(stats.maxHealth); //TESTING
        stats.currentHealth = stats.maxHealth;
    }

    private void Update()
    {
        if (stats.currentHealth <= 0)
        {
            //destroys ship when health reaches zero
            Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object
            levelController.GameOver();
            Destroy(gameObject);
        }
    }

    public void GetDamage(int damage)   
    {
        stats.currentHealth -= 20;
    }  
}

/*
public class Player : MonoBehaviour
{
    public GameObject destructionFX;

    public static Player instance; 

    private void Awake()
    {
        if (instance == null) 
            instance = this;
    }

    //method for damage proceccing by 'Player'
    public void GetDamage(int damage)   
    {
        Destruction();
    }    

    //'Player's' destruction procedure
    void Destruction()
    {
        Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object
        Destroy(gameObject);
    }
}
*/
















