using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float walkSpeed = -5.0f;
    int attackModeNum = 0;
    
    bool onAttack = false;
    bool attackPlayer = false;
    bool onWalk = true;
    Animator anim;
    AudioSource audi;
    ParticleSystem particle;

    public bool OnWalk { get => onWalk; set => onWalk = value; }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
        particle = GetComponentInChildren<ParticleSystem>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!onAttack&&OnWalk)
        {
            transform.position += new Vector3(walkSpeed * Time.deltaTime, 0, 0);
          
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right, 50, 1<<7);
        if (!attackPlayer&&Mathf.Abs(hit.point.x-transform.position.x)<0.35f)//attackPlayer防止重复进行攻击
        {
            anim.SetInteger("attackMode", attackModeNum);
            AttackAudio();
            attackPlayer = true;
            onAttack = true;
        }
        if (transform.position.x<-10f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="ShowAttack")
        {
            attackModeNum = Random.Range(1, 5);
            anim.SetInteger("attackMode", attackModeNum);
            AttackAudio();
            onAttack = true;
            
        }
    }
    private void EndAct()
    {
        anim.SetInteger("attackMode", 0);
        onAttack = false;
    }
    private void DestroyEnemy()
    {
      

        Destroy(this.gameObject);
        

    }
     private void AttackAudio()
    {
        audi.clip = Resources.Load<AudioClip>("Audio/Show bist");
        audi.Play();
    }
    private void ShowHurtAudio()
    {
        audi.clip = Resources.Load<AudioClip>("Audio/Hitted");
        audi.Play();
        
    }
    private void ParticlePlay()//播放敌人被打败的特效
    {
        transform.GetChild(4).transform.localPosition = transform.GetChild(attackModeNum - 1).transform.localPosition;//特效位置确定
        particle.Play();
    }

}
