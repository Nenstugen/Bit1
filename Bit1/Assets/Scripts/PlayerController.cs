using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public TyyppiKontrolleri controller;
    public Animator anim;

    public float runspeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
   


    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

   

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("IsJumping", true);
        }
      
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

   public void OnLanding ()
    {
        anim.SetBool("IsJumping", false);
    }

    public void OnCrouching (bool isCrouching)
    {
        anim.SetBool("IsCrouching", isCrouching);
    }

   void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }




}