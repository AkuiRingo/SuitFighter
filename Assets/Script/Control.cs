using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    //bool onDefence = false;
    Animator anim;
    Collider2D col;
    AudioSource audi;
    GameObject LH;
    GameObject RH;
    GameObject LK;
    GameObject RK;
    bool isHurt=false;
    bool isPauseC = false;

    public bool IsHurt { get => isHurt; set => isHurt = value; }//封装isHurt
    public bool IsPauseC { get => isPauseC; set => isPauseC = value; }




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        audi = GetComponent<AudioSource>();
        LH = transform.GetChild(0).gameObject;
        RH = transform.GetChild(1).gameObject;
        LK = transform.GetChild(2).gameObject;
        RK = transform.GetChild(3).gameObject;
    }
        // Update is called once per frame
        void Update()
    {
       
        
    }
    public void Play(string animeName)
    {
        //if (!onDefence)
        //{
        if (!isPauseC)
        {
            anim.SetBool(animeName, true);
        }
        //audi.clip = Resources.Load<AudioClip>("Audio/Def");
        //audi.Play();
        //    onDefence = true;
        ////}
    }

    public void ActionEnd(string animeNam)
    {
        anim.SetBool(animeNam, false);
        //onDefence = false;
        

    }
    private void HurtStop()
    {
        IsHurt = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!LH.activeInHierarchy&&!RH.activeInHierarchy&&!LK.activeInHierarchy&&!RK.activeInHierarchy)//防御判定均未被激活时
        {
            if (collision.tag == "LHA" || collision.tag == "RHA" || collision.tag == "LKA" || collision.tag == "RKA")//防止敌人人体collider
            {

                anim.SetBool("HurtActive", true);

                audi.clip = Resources.Load<AudioClip>("Audio/ouch 1");
                audi.Play();
               // Debug.Log("KO1");
            }
        }
        else if(LH.activeInHierarchy)
        {
            if (collision.tag == "LHA" || /*collision.tag == "RHA" ||*/ collision.tag == "LKA" || collision.tag == "RKA")
            {
                anim.SetBool("HurtActive", true);

                audi.clip = Resources.Load<AudioClip>("Audio/ouch 1");
                audi.Play();
               // Debug.Log("KO2");
            }
        }
        else if (RH.activeInHierarchy)
        {
            if (/*collision.tag == "LHA" || */collision.tag == "RHA" || collision.tag == "LKA" || collision.tag == "RKA")
            {
                anim.SetBool("HurtActive", true);

                audi.clip = Resources.Load<AudioClip>("Audio/ouch 1");
                audi.Play();
               // Debug.Log("KO3");
            }
        }
        else if (LK.activeInHierarchy)
        {
            if (collision.tag == "LHA" || collision.tag == "RHA" || collision.tag == "LKA"/*||collision.tag=="RKA"*/)
            {
                anim.SetBool("HurtActive", true);

                audi.clip = Resources.Load<AudioClip>("Audio/ouch 1");
                audi.Play();
                //Debug.Log("KO4");
            }
        }
        else if(RK.activeInHierarchy)
        {
            if (collision.tag == "LHA" || collision.tag == "RHA" /*|| collision.tag == "LKA"*/ || collision.tag == "RKA")
            {
                anim.SetBool("HurtActive", true);

                audi.clip = Resources.Load<AudioClip>("Audio/ouch 1");
                audi.Play();
              //  Debug.Log("KO5");
            }
        }
      
    }
    void DamageColliderActive()
    {
        col.enabled = true;
       // onDef = false;

    }
    void DamageColliderUnactive()
    {
        col.enabled = false;//防御时取消碰撞避免伤害和防御成功同时判断
        //onDef = true;
    }
}
