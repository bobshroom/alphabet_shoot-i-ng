using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float time;
    public float progressTime;
    public bool isTime;
    public bool isProgressTime;
    public int score = 0;
    [SerializeField] private GameObject hint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(isProgressTime){
            progressTime += Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("game");
        }
        if(!isProgressTime & time >= 5.0f){
            hint.SetActive(true);
        } else {
            hint.SetActive(false);
        }
    }
    public IEnumerator gameStart(){
        yield return new WaitForSeconds(1);
        isProgressTime = true;
    }
}
