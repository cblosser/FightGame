using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public static int currentHealth;
    public Slider healthSlider;
    public Animator anim;
    public Canvas Victory;

	 void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }
    // Update is called once per frame

    void Update()
    {
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && PlayerMovement.playerPunching == true)
        {
            currentHealth -= 10;
          //  anim.SetTrigger("Damaged");
            healthSlider.value -= 10;
         //   anim.ResetTrigger("Damaged");

        }
        
    }


    void Death()
    {
        anim.SetBool("Dead", true);
        Victory.GetComponent<Canvas>().enabled = true;
    }

}
