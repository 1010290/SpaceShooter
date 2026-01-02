using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script defines 'Enemy's' health and behavior. 
/// </summary>
public class Enemy : MonoBehaviour {

    #region FIELDS
    [Tooltip("Health points in integer")]
    public int health;

    [Tooltip("Enemy's projectile prefab")]
    public GameObject Projectile;

    [Tooltip("VFX prefab generating after destruction")]
    public GameObject destructionVFX;
    public GameObject hitEffect;
    
    [HideInInspector] public int shotChance; //probability of 'Enemy's' shooting during tha path
    [HideInInspector] public float shotTimeMin, shotTimeMax; //max and min time for shooting from the beginning of the path
    #endregion

    //------------FOR SCORING SYSTEM-------------
    public int scoreValue;    
    private LevelController levelController; //this was set to private so we won't see it in inspector
    //---------FOR SCORING SYSTEM ENDS-----------    

    private void Start()
    {
        Invoke("ActivateShooting", Random.Range(shotTimeMin, shotTimeMax));

        //------------FOR SCORING SYSTEM-------------
        //Game Object that holds Level Controller Script
        GameObject levelControllerObject = GameObject.FindWithTag("LevelController"); //Finds first object in scene with tag
        //if object was found and checked by testing reference to object
        if(levelControllerObject != null)
        {
            //sets levelcontroller reference to level controller component on level controller object
            levelController = levelControllerObject.GetComponent<LevelController>();
        }
        //FOR TESTING (if not found)
        if(levelController == null)
        {
            Debug.Log("Cannot find 'LevelController' script");
        }

        Debug.Log("Score Value: " + scoreValue); //FOR TESTING
        //---------FOR SCORING SYSTEM ENDS-----------  
    }

    //coroutine making a shot
    void ActivateShooting() 
    {
        if (Random.value < (float)shotChance / 100)                             //if random value less than shot probability, making a shot
        {                         
            Instantiate(Projectile,  gameObject.transform.position, Quaternion.identity);             
        }
    }

    //method of getting damage for the 'Enemy'
    public void GetDamage(int damage) 
    {
        health -= damage;           //reducing health for damage value, if health is less than 0, starting destruction procedure
        if (health <= 0)
            Destruction();
        else
            Instantiate(hitEffect,transform.position,Quaternion.identity,transform);
    }    

    //if 'Enemy' collides 'Player', 'Player' gets the damage equal to projectile's damage value
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Projectile.GetComponent<Projectile>() != null)
                Player.instance.GetDamage(Projectile.GetComponent<Projectile>().damage);
            else
                Player.instance.GetDamage(1);
        }
    }

    //method of destroying the 'Enemy'
    void Destruction()                           
    {        
        //------------FOR SCORING SYSTEM-------------    
        levelController.AddScore(scoreValue);
        //---------FOR SCORING SYSTEM ENDS-----------    
        Instantiate(destructionVFX, transform.position, Quaternion.identity); 
        Destroy(gameObject);
    }
}
