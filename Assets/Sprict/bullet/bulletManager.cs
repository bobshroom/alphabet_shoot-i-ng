using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

public class bulletManager : MonoBehaviour
{
    [HideInInspector] public bullet bulletInfo;
    public float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject obj = Instantiate(bulletInfo.bulletImage, transform.position, Quaternion.identity);
        obj.transform.parent = transform;
        obj.tag = transform.tag;
        damage = bulletInfo.damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemyBody" && transform.tag == "playerAttack"){
            Destroy(gameObject);
        } else if(collision.tag == "titleAlphabet"){
            Destroy(gameObject);
        }
    }
    public void destroy(){
        Destroy(gameObject);
    }
}
