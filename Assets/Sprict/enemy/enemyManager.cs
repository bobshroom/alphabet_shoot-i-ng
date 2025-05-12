using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
using Unity.Mathematics;
using System;
using System.Runtime.InteropServices;

public class enemyManager : MonoBehaviour
{
    public GameObject point;
    public Transform bulletParent;
    [SerializeField] private GameObject gameManager;
    public GameObject bullet;
    public bullet bulletInfo;
    public enemy enemyInfo;
    private float maxHp;
    private float hp;
    private Transform pointParent;
    private bool colorChangeFlag = true;
    private AudioClip audioClip;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        pointParent = GameObject.Find("effect/point").transform;
        bulletParent = GameObject.Find("bullet/enemy").transform;
        gameManager = GameObject.Find("GameManager");
        GameObject obj = Instantiate(enemyInfo.enemyImage, transform.position, Quaternion.identity);
        obj.transform.parent = transform;
        obj.tag = "enemyBody";
        obj.name = enemyInfo.enemyImage.name;
        maxHp = enemyInfo.hp;
        hp = maxHp;
        bulletInfo = enemyInfo.bullet;

        if(enemyInfo.enemyType == 2){
            if(enemyInfo.bulletType == 1){
                StartCoroutine(shot(enemyInfo.bulletCount, 180, enemyInfo.bulletInterval, 2));
            } else if(enemyInfo.bulletType == 3){

            }
        }
        if(enemyInfo.audioClip != null){
            audioClip = enemyInfo.audioClip;
            audioSource.clip = audioClip;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(colorChangeFlag){
            changeColor(Color.black);
            colorChangeFlag = false;
        }
        /*if(changedColor){
            changedColor = false;
            foreach (Transform child in gameObject.transform){
                if(child.GetComponent<SpriteRenderer>() != null){
                    child.GetComponent<SpriteRenderer>().color = Color.black;
                }
            }
        }*/
    }
    public void hit(float damage){
        hp -= damage;
        changeColor(Color.white);
        colorChangeFlag = true;
        
        if(hp <= 0){
            hitReact(enemyInfo.hitEffectType);
            death();
        } else {

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "playerAttack"){
            hit(collision.transform.parent.GetComponent<bulletManager>().damage);
            if(!collision.transform.parent.GetComponent<bulletManager>().bulletInfo.isThrough){
                collision.transform.parent.GetComponent<bulletManager>().destroy();
            }
        }
    }
    void death(){
        gameManager.GetComponent<GameManager>().score += enemyInfo.score;
        int count = 0;
        int health = enemyInfo.point[0];
        int attack = enemyInfo.point[1];
        while(health != 0 | attack != 0){
            count += 1;
            GameObject instant = Instantiate(point, transform.position, quaternion.identity);
            pointManager pointManager = instant.GetComponent<pointManager>();
            if(health > 20){
                pointManager.healthPoint = 20;
                health -= 20;
            } else if (health > 5){
                pointManager.healthPoint = 5;
                health -= 5;
            } else if (health > 0){
                pointManager.healthPoint = health;
                health = 0;
            } else if (attack > 20){
                pointManager.attackPoint = 20;
                attack -= 20;
            } else if (attack > 5){
                pointManager.attackPoint = 5;
                attack -= 5;
            } else if (attack > 0){
                pointManager.attackPoint = attack;
                attack = 0;
            }
            if(count >= 1000000){
                break;
            }
            instant.GetComponent<pointManager>().count = count;
            instant.transform.parent = pointParent;
        }
        audioSource.volume = 1;
        AudioSource.PlayClipAtPoint(enemyInfo.deathSound, transform.position);
        Destroy(gameObject);
    }
    void hitReact(int i){
        if(i == 1){
            
        }
    }
    void gunShot(float kakudo){
        GameObject instant = Instantiate(bullet, gameObject.transform.position, Quaternion.identity, bulletParent);
        float bure = UnityEngine.Random.Range(enemyInfo.shaking, -enemyInfo.shaking);
        instant.GetComponent<bulletMovement>().bulletSpeedMulti = enemyInfo.bulletSpeedMulti;
        instant.transform.Rotate(0, 0, kakudo + bure);
        instant.GetComponent<bulletMovement>().bulletInfo = enemyInfo.bullet;
        instant.tag = "enemyBullet";
        instant.transform.position += new Vector3(0, -0.3f, 0);
    }
    public IEnumerator shot(int count, float mokuhyoukakudo, float interval, float waitTime){
        yield return new WaitForSeconds(waitTime);
        while(count != 0){
            if(audioClip != null){
                audioSource.Play();
            }
            int muki = 1;
            if(enemyInfo.startRight){
                muki = -1;
            }
            float startMuki = enemyInfo.hirogeru * (enemyInfo.countShot - 1);
            float startKakudo = mokuhyoukakudo + startMuki / 2 * muki * -1;
            for(int i=0; i<enemyInfo.countShot; i++){
                gunShot(startKakudo);
                startKakudo += enemyInfo.hirogeru * muki;
                if(enemyInfo.hirogaruTime > 0){
                    audioSource.Play();
                    yield return new WaitForSeconds(enemyInfo.hirogaruTime);
                }
            }
            count -= 1;
            yield return new WaitForSeconds(interval);
        }
    }


    void OnTriggerExit2D(Collider2D collider) {
        if(collider.tag == "mainArea"){
            Destroy(gameObject);
        }
    }
    void changeColor(Color color){
        foreach(Transform children in transform){
            SpriteRenderer sprite = children.GetComponent<SpriteRenderer>();
            if(sprite != null){
                sprite.color = color;
            }
            foreach(Transform children2 in children){
                SpriteRenderer sprite2 = children2.GetComponent<SpriteRenderer>();
                if(sprite2 != null){
                    sprite2.color = color;
                }
            }
        }
    }
}

