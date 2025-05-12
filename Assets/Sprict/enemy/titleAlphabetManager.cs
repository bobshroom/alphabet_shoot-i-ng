using UnityEngine;
using System.Collections;

public class titleAlphabetManager : MonoBehaviour
{
    private GameObject gameManager;
    [SerializeField] private int maxHealth;
    private int health;
    private bool colorChangeFlag = true;
    private bool running = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        transform.GetChild(0).tag = "titleAlphabet";
        health = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(colorChangeFlag){
            changeColor(Color.black);
        }
        if(gameManager.GetComponent<GameManager>().isProgressTime & !running){
            running = true;
            StartCoroutine("runAway");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "playerAttack"){
            changeColor(Color.white);
            colorChangeFlag = true;
            health -= 10;
            if(health <= 0){
                gameManager.GetComponent<GameManager>().StartCoroutine("gameStart");
                Destroy(gameObject);
            }
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
    IEnumerator runAway(){
        GameObject target = GameObject.Find("player");
        yield return new WaitForSeconds(UnityEngine.Random.Range(0, 0.5f));
        float speed = UnityEngine.Random.value * 1.0f + 2.0f;
        Vector3 direction2 = (target.transform.position - transform.position).normalized;
        StartCoroutine("panic");
        while(true){
            gameObject.transform.position += direction2 * speed * -Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator panic(){
        gameObject.transform.eulerAngles = new Vector3(0,0,10.0f);
        while(true){
            gameObject.transform.eulerAngles = -gameObject.transform.GetChild(0).eulerAngles;
            yield return new WaitForSeconds(0.1f);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "mainArea"){
            Destroy(gameObject);
        }
    }

}
