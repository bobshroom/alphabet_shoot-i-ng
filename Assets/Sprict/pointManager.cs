using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class pointManager : MonoBehaviour
{
    public int healthPoint;
    public int attackPoint;
    private float kakudo;
    private GameObject target;
    [HideInInspector] public int count;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        kakudo = UnityEngine.Random.value * 360.0f;
        StartCoroutine(move(kakudo));
        target = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator move(float muki){
        float radian = muki * Mathf.Deg2Rad;
        float speed = UnityEngine.Random.value * 2.0f + 2.0f * (count * 0.01f + 1.0f);
        Vector2 direction = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
        while (speed > 0){
            gameObject.transform.position += (Vector3)direction * speed * Time.deltaTime;
            speed -= 0.075f / 2.0f * Time.deltaTime * 100.0f;
            yield return new WaitForSeconds(1/30);
        }
        yield return new WaitForSeconds(UnityEngine.Random.value * 0.8f + 0.2f);
        speed = -0.025f;
        while(true){
            speed += 0.1f * Time.deltaTime;
            Vector3 direction2 = (target.transform.position - transform.position).normalized;
            
            transform.position += direction2 * speed * Time.deltaTime * 100.0f;
            yield return new WaitForSeconds(1/30);

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player"){
            collision.GetComponent<playerStatus>().getPoint(0, healthPoint);
            collision.GetComponent<playerStatus>().getPoint(1, attackPoint);
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.pitch = UnityEngine.Random.Range(0.75f, 1.25f);
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            Destroy(gameObject);
        }
    }

}
