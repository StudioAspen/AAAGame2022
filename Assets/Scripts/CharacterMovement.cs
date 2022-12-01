using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    public Animator anim;

    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        anim =GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();
        rb.velocity = new Vector3(moveInput.x*moveSpeed, rb.velocity.y, moveInput.y*moveSpeed);

        if(moveInput != Vector2.zero) {
            anim.SetFloat("Xinput", moveInput.x);
            anim.SetFloat("Yinput", moveInput.y);
            if (moveInput.magnitude==0) //use vector3.mag
            {
                anim.SetBool("Walking", false); 
            }
            else
            {
                anim.SetBool("Walking", true);
            }

          
        }
        
        
        




    }
}