using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandAttack : MonoBehaviour
{
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RHB")
        {
           
            anim.SetBool("EHurt", true);
           
        }
    }
}
