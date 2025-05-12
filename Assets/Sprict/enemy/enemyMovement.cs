using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class enemyMovement : MonoBehaviour
{
    private RuntimeAnimatorController animator;
    public enemy enemyInfo;
    
    public bool isTitleAlphabet = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(enemyInfo.movementType == 2){
            StartCoroutine("MoveType2");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(enemyInfo.movementType == 1){
            transform.position += transform.up * enemyInfo.moveSpeed * -Time.deltaTime;
        }
        
    }

    IEnumerator MoveType2(){
        float nowSpeed = enemyInfo.moveSpeed;
        while(nowSpeed > 0){
            transform.position += transform.up * nowSpeed * -Time.deltaTime;
            nowSpeed -= enemyInfo.moveSpeed * 0.5f * Time.deltaTime;
            yield return null;
        }
        if(enemyInfo.bulletType == 2){
            yield return new WaitForSeconds(1);
            StartCoroutine(gameObject.GetComponent<enemyManager>().shot(enemyInfo.bulletCount, 180, enemyInfo.bulletInterval, 0));
        } else if (enemyInfo.bulletType == 3){
            for(int i=0; i<enemyInfo.bulletCount; i++){
                if(enemyInfo.animation){
                    Animator anime = transform.GetChild(0).gameObject.GetComponent<Animator>();
                    Debug.Log("アニメーション開始");
                    anime.SetTrigger("a");
                }
                yield return new WaitForSeconds(enemyInfo.chargeTime);
                StartCoroutine(gameObject.GetComponent<enemyManager>().shot(enemyInfo.chargeCount, 180, enemyInfo.chargeInterval, 0));
                yield return new WaitForSeconds(enemyInfo.bulletInterval);
            }
        }
        if(enemyInfo.bulletCount < -1){
            yield return new WaitForSeconds(3);
        } else {
            if(enemyInfo.countShot == 1){
                yield return new WaitForSeconds(enemyInfo.bulletCount * enemyInfo.bulletInterval + 1);
            } else {
                yield return new WaitForSeconds(enemyInfo.bulletCount * (enemyInfo.bulletInterval + enemyInfo.hirogaruTime * enemyInfo.countShot) + 1);
            }
        }
        while(true){
            transform.position += transform.up * nowSpeed * Time.deltaTime;
            nowSpeed += enemyInfo.moveSpeed * 0.5f * Time.deltaTime;
            yield return null;
        }
    }
}
