using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f; //defintion for minimum time of the player in trigger zone
    public int attackDamage = 10;


    Animator anim;
    GameObject player; 
    PlayerHealth playerHealth; //importing player health script
    //EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other) //when something enters the sphere capsule
    {
        if(other.gameObject == player) //check if the one that enters the sphere capsule is the player
        {
            playerInRange = true;
        }
    }

    //note, if the trigger is still there in the trigger area then there is TriggerStay function
    void OnTriggerExit (Collider other) 
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime; //frame/sec in computer will result in 60 hits instead of one, to control this, we need to increment time 

        if(timer >= timeBetweenAttacks && playerInRange/* && enemyHealth.currentHealth > 0*/) //discrete attack definition
        {
            Attack ();
        }

        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead"); //animator control trigger of enemy
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
    }
}
