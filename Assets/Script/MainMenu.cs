using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu :MonoBehaviour
{
   // private AudioSource audi;
    private void Start()
    {
       // audi = GetComponent<AudioSource>();
    }
    public void Play()
    {
       // audi.Play();
        SceneManager.LoadScene("Play");
     
    }
    public void Quit()
    {
        Application.Quit();
    }
}
