using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    Transform player;
    NavMeshAgent nav;
    public Animator anim;
    public static bool enemyPunching = false;
   
    

	void Awake ()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        anim.SetBool("Walk Forward", true);
        anim.SetBool("Idle", false);
    }
	// Update is called once per frame
	void Update ()
    {
        if (EnemyHealth.currentHealth > 0 && PlayerHealth.currentHealth > 0)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
        
        //anim.SetBool("Walk Forward", true);
        }

        else
        {
            nav.enabled = false;
        }

        if(anim.GetBool("PunchTrigger") != true)
        {
            enemyPunching = false;
        }
        
	}

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Walk Forward", false);
            anim.SetTrigger("PunchTrigger");
            enemyPunching = true;
        }
    }
}
