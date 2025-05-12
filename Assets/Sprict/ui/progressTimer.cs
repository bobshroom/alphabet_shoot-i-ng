using System;
using TMPro;
using UnityEngine;

public class progressTimer : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject player;
    private string text;
    [Header("0:経過時間 1:スコア 2:体力レベル 3:攻撃力レベル")]
    [SerializeField] private int type;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(type == 0){
            float time = gameManager.GetComponent<GameManager>().progressTime;
            changeText("ptimer:" + Math.Round(time, 1).ToString());
        } else if (type == 1){
            int score = gameManager.GetComponent<GameManager>().score;
            changeText("score:" + score);
        } else if(type == 2){
            changeText("HP  Lv:" + player.GetComponent<playerStatus>().healthLevel);
        } else if(type == 3){
            changeText("ATK Lv:" + player.GetComponent<playerStatus>().attackLevel);
        }
    }
    void changeText(string text){
        gameObject.GetComponent<TextMeshProUGUI>().text = text;
    }
}
