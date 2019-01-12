using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player; //specifying to go to player
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav; // nav mesh with Artificial intelligence


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform; //follow the object tagged in that way
        //playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> (); //UnityEnginge.AI.NavMeshAgent is the location of nav mesh which is needed because Nav Mesh Agent is saved with spaces in between
    }


    void Update ()
    {
        //if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
            nav.SetDestination (player.position); //loop and follow
        //}
        //else
        //{
        //    nav.enabled = false;
        //}
    }
}
