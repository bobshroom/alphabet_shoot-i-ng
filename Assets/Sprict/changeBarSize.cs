using UnityEngine;

public class changeBarSize : MonoBehaviour
{
    [SerializeField] private int type;
    private playerStatus playerStatus;
    private Vector3 position;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStatus = GameObject.Find("player").GetComponent<playerStatus>();
        position = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(type == 0){
            float size = (playerStatus.healthLevel - 1) * 0.1f + 0.5f;
            gameObject.transform.localScale = new Vector3(size * 72.0f, 72.0f, 72.0f);
            transform.position = new Vector3((6 - playerStatus.healthLevel) * -0.14f + position.x, position.y, position.z);
        }
    }
}
