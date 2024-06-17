using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public EnemyPool enemyPool;
    private Text scoredisplay;
    private Text combodisplay;
    private int combo = 0;
    private int maxCombo=0;
    private int score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        scoredisplay = GetComponent<Text>();
        combodisplay = transform.GetChild(0).GetComponent<Text>();
        enemyPool.GetScore += ScoreManager;
        score = PlayerPrefs.GetInt("PlayerScore", 0);
        maxCombo = PlayerPrefs.GetInt("ComboSave", 0);
        scoredisplay.text = score.ToString();
        combodisplay.text = maxCombo.ToString();



    }

    private void ScoreManager(int temp)
    {
        
        score += temp;
        scoredisplay.text = score.ToString();
        PlayerPrefs.SetInt("PlayerScore", score);
        combo += temp;
        combodisplay.text = combo.ToString();
        PlayerPrefs.SetInt("Combo", combo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
