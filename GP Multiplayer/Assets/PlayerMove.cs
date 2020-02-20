using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Movement()
    {
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), transform.position.y);
        //transform.position += move * runSpeed * Time.deltaTime;
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        /* if (Input.GetButtonDown("Jump"))
         {

             jump = true;
             animator.SetBool("Jumping", true);
         }*/
    }
}
