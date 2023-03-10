using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManager instance { get; private set; }

    public int score;
    public int health;
    //public TMP_Text scoreText;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;
    public int maxHealth;
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }
    void Start()
    {
        //score = 0;
        health = 5;
        maxHealth = 5;
        //scoreText.text = "SCORE : " + score;
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;

            }
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void AddScore(int amount)
    {
        //score += amount;
        //scoreText.text = "SCORE : " + score;
        //if(score == 10)
        //{
        //    GameManager.Instance.UpdateGameState(GameState.Win);
        //}
    }

    public void TakeDamage(int amount)
    {
        health -= 1;
        SoundManager.Instance.playhitSound();
    }
}
