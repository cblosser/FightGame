using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public static int currentHealth;
    public Slider healthSlider;
    public Canvas GameOver;

    Animator anim;
    PlayerMovement playerMovement;
    bool isDead;
    bool isDamaged;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = startingHealth;
    }
    

    void Update()
    {
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Opponent") && EnemyMovement.enemyPunching == true)
        {
            currentHealth -= 2;
            healthSlider.value -= 2;
        }
        
    }

    void Death()
    {
        anim.SetBool("Death", true);
        playerMovement.enabled = false;
        GameOver.GetComponent<Canvas>().enabled = true;
        
    }

	
}
