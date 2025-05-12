using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.Animations;

public class playerManager : MonoBehaviour
{
    [SerializeField] private alphabetInfo alphabetInfo;
    public int startHp;
    public int maxHp;
    public int hp;
    private float invincible = 0.0f;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    public AudioClip hitSound;
    private playerStatus playerStatus;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startHp = alphabetInfo.hp;
        hp = maxHp = startHp;
        audioSource = GetComponent<AudioSource>();
        playerStatus = gameObject.GetComponent<playerStatus>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        maxHp = startHp + (int)((playerStatus.healthLevel - 1) * startHp * 0.1f);
        invincible -= Time.deltaTime;
        if(invincible < 0){
            spriteRenderer.enabled = false;
        }
        hp = Mathf.Min(hp, maxHp);
    }
    void hit(int damage){
        if(invincible < 0){
            audioSource.volume = 1;
            audioSource.clip = hitSound;
            audioSource.Play();
            hp -= damage;
            StartCoroutine(blinking(alphabetInfo.invincibleTime));
            if(hp <= 0){
                death();
            } else {
                invincible = alphabetInfo.invincibleTime;
            }
        }
    }
    void death(){
        Destroy(gameObject);
    }
    IEnumerator blinking(float time){
        for(int i=0; i<(int)(time*5); i++){
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(0.2f);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemyBody"){
            Transform aparent = collision.transform;
            while(aparent.GetComponent<enemyManager>() == null){
                aparent = aparent.transform.parent;
            }
            int damage = aparent.GetComponent<enemyManager>().enemyInfo.contactDamage;
            hit(damage);
            
        } else if(collision.tag == "enemyBullet"){
            Transform aparent = collision.transform.parent;
            int damage = aparent.GetComponent<bulletManager>().bulletInfo.damage;
            hit(damage);
        }
    }
}
