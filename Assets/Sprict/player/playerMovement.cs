using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private alphabetInfo alphabetInfo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject obj = Instantiate(alphabetInfo.alphabet, transform.position, Quaternion.identity);
        obj.transform.parent = transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetKey(KeyCode.W)){
            movePlayer(transform.up);
            if(transform.position.y >= 4.5f){
                transform.position = new Vector3(transform.position.x, 4.5f, 0);
            }
        }
        if(Input.GetKey(KeyCode.D)){
            movePlayer(transform.right);
            if(transform.position.x >= 3.7f){
                transform.position = new Vector3(3.7f, transform.position.y, 0);
            }
        }
        if(Input.GetKey(KeyCode.S)){
            movePlayer(transform.up * -1);
            if(transform.position.y <= -4.5f){
                transform.position = new Vector3(transform.position.x, -4.5f, 0);
            }
        }
        if(Input.GetKey(KeyCode.A)){
            movePlayer(transform.right * -1);
            if(transform.position.x <= -3.7f){
                transform.position = new Vector3(-3.7f, transform.position.y, 0);
            }
        }
    }

    void movePlayer(Vector3 tr)
    {
        if(Input.GetKey(KeyCode.LeftShift)){
            transform.position += tr * alphabetInfo.moveSpeed * Time.deltaTime * 0.3f;
        } else {
            transform.position += tr * alphabetInfo.moveSpeed * Time.deltaTime;
        }
    }
}
