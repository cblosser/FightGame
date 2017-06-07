using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour
{ 
    Animator anim;                          // Reference to the animator component.


    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        // If the player has run out of health...
        if (PlayerHealth.currentHealth <= 0)
        {
            // ... tell the animator the game is over.
            anim.SetTrigger("GameOver");
        }
    }
}