using System.Collections.Generic;
using System.Threading;
using NUnit.Framework.Internal;
using UnityEngine;

public class playerStatus : MonoBehaviour
{
    public int healthPointnow;
    public int attackPointnow;
    public int healthLevel = 1;
    public int attackLevel = 1;
    public int healthEXP;
    public List<int> healthEXPList = new List<int>();
    public int attackEXP;
    public List<int> attackEXPList = new List<int>();
    public float healMulti;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthEXP = healthEXPList[0];
        attackEXP = attackEXPList[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    public void getPoint(int type, int point){
        if(UnityEngine.Random.Range(0, 100) < point * healMulti){
            gameObject.GetComponent<playerManager>().hp++;
        } 
        if(type == 0){
            healthPointnow += point;
            
        }
        if(type == 1){
            attackPointnow += point;
        }

        if(healthPointnow >= healthEXP){
            if(healthLevel == healthEXPList.Count + 1){
                healthEXP = 1;
                healthPointnow = 1;
            } else {
                levelUp(0);
                healthLevel += 1;
                if(healthLevel == healthEXPList.Count + 1){
                    healthEXP = 1;
                    healthPointnow = 1;
                } else {
                    healthPointnow -= healthEXPList[healthLevel-2];
                    healthEXP = healthEXPList[healthLevel-1];
                }
            }
        }
        if(attackPointnow >= attackEXP){
            if(attackLevel == attackEXPList.Count + 1){
                attackEXP = 1;
                attackPointnow = 1;
            } else {
                levelUp(1);
                attackLevel += 1;
                if(attackLevel == attackEXPList.Count + 1){
                    attackEXP = 1;
                    attackPointnow = 1;
                } else {
                    attackPointnow -= attackEXPList[attackLevel-2];
                    attackEXP = attackEXPList[attackLevel-1];
                }
            }
        }
    }
    void levelUp(int type){

    }
}
