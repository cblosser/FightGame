using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;
    public Animator anim;
    Rigidbody playerRigidbody;
    public static bool playerPunching = false;
    int floorMask;                     
    float camRayLength = 100f;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Turning()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation(newRotatation);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(v ,h);
        Turning();
        Fight();
        playerRigidbody.AddForce(movement * speed);
    }
    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
        if(h > 0 || v > 0)
        {
            anim.SetBool("Walk Forward", true);
            anim.SetBool("Walk Backward", false);
        }
        if (h < 0 || v < 0)
        {
            anim.SetBool("Walk Backward", true);
            anim.SetBool("Walk Forward", false);
        }
        if(h == 0 && v == 0)
        {
            anim.SetBool("Walk Backward", false);
            anim.SetBool("Walk Forward", false);
        }
    }

    void Fight()
    {
        if(Input.GetKeyDown("e"))
        {
            anim.SetBool("PunchTrigger", true);
            playerPunching = true;

        }
        if(!Input.GetKeyDown("e"))
        {
            anim.SetBool("PunchTrigger", false);
            playerPunching = false;
        }
    }

   
}
