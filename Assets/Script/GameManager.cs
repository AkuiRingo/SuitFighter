using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cha;
    public GameObject eny;
    public GameObject ui;
    private AudioSource audi;
    

    int intAudio=1;//保存音乐设定状态
    bool isPause = false;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        //重置场景后保存声音设定状态
        if (PlayerPrefs.GetInt("Audio",1)==1)
        {
            ui.transform.GetChild(7).GetComponent<Image>().overrideSprite = Resources.Load("Audio/audio", typeof(Sprite)) as Sprite;
            GetComponent<AudioListener>().enabled = true;
            intAudio = 1;
        }
        else
        {
            ui.transform.GetChild(7).GetComponent<Image>().overrideSprite = Resources.Load("Audio/audioOff", typeof(Sprite)) as Sprite;
            GetComponent<AudioListener>().enabled = false;
            intAudio = 0;
        }
        audi = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cha.GetComponent<Control>().IsHurt == true) 
        {
            //延迟调用GameOver菜单并暂定游戏
            Invoke("StopGame", 0.5f);
            if (PlayerPrefs.GetInt("ComboSave",0)<= PlayerPrefs.GetInt("Combo", 0))
            {
                PlayerPrefs.SetInt("ComboSave", PlayerPrefs.GetInt("Combo", 0));
            }
           
            PlayerPrefs.SetInt("Combo", 0);
        }
      
    }
    public void ReStart()
    {
        SceneManager.LoadScene("Play");
    }
    public void AudioControl()
    {
        if (intAudio == 1)
        {
            ui.transform.GetChild(7).GetComponent<Image>().overrideSprite = Resources.Load("Audio/audioOff", typeof(Sprite)) as Sprite;
            AudioListener.pause = true;
            //cha.GetComponent<AudioSource>().volume = 0;
            
            intAudio = 0;
        }
        else
        {
            ui.transform.GetChild(7).GetComponent<Image>().overrideSprite = Resources.Load("Audio/audio", typeof(Sprite)) as Sprite;
            AudioListener.pause = false;
           // cha.GetComponent<AudioSource>().volume = 1;

            intAudio = 1;
        }
        PlayerPrefs.SetInt("Audio", intAudio);
    }
    public void StopGame()
    {
        ui.transform.GetChild(6).gameObject.SetActive(true);
        eny.SetActive(false);
        //eny.GetComponent<EnemyPool>().StopEnemy();
        //if (eny.transform.GetChild(0) != null)
        //{
        //    eny.transform.GetChild(0).GetComponent<Enemy>().OnWalk = false;
        //}

        //if (eny.transform.GetChild(1) != null)
        //{
        //    eny.transform.GetChild(1).GetComponent<Enemy>().OnWalk = false;
        //}
    }
    public void Pause()
    {
        if (!isPause)
        {
            Time.timeScale = 0;
            isPause = true;
            cha.GetComponent<Control>().IsPauseC = true;
        }
        else
        {
            Time.timeScale = 1;
            isPause = false;
            cha.GetComponent<Control>().IsPauseC = false;
        }
        
    }
}
