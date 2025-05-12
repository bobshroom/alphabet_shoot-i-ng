using Unity.VisualScripting;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    [HideInInspector] public bullet bulletInfo;
    [HideInInspector] public float bulletSpeedMulti;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<bulletManager>().bulletInfo = bulletInfo;
    }

    // Update is called once per frame
    void Update()
    {
        if(bulletInfo.movementType == 1){
            transform.position += bulletInfo.moveSpeed * Time.deltaTime * transform.up * bulletSpeedMulti;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "playerBulletArea"){
            Destroy(gameObject);
        }
    }
}
