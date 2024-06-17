using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spR;
    void Start()
    {
        spR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Enemy")
        {
            Texture2D Tex = (Texture2D)Resources.Load("DoorControl/dooropen");
            spR.sprite = Sprite.Create(Tex, new Rect(0.0f, 0.0f, Tex.width, Tex.height), new Vector2(0.5f, 0.5f));
       
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
          
            Texture2D Tex = (Texture2D)Resources.Load("DoorControl/doorclose");
            spR.sprite = Sprite.Create(Tex, new Rect(0.0f, 0.0f, Tex.width, Tex.height), new Vector2(0.5f, 0.5f));
         
        }
       
    }
}
