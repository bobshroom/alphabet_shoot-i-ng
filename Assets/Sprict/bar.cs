using UnityEngine;

public class bar : MonoBehaviour
{
    private GameObject player;
    private float a;
    private Vector3 barStartPosition;
    [SerializeField] private Vector3 barEndPosition;
    private float barProgress = 0.0f;
    [SerializeField] private int type;
    [SerializeField] private GameObject barEffect;
    private float barProgress2;
    private float test = -0.5f;
    private playerStatus playerStatus;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("player");
        barStartPosition = transform.position;
        barEndPosition = transform.TransformPoint(barEndPosition);
        playerStatus = player.GetComponent<playerStatus>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        barEffect.SetActive(false);
        if(type == 0){
            barProgress = (float)player.GetComponent<playerStatus>().healthPointnow / (float)player.GetComponent<playerStatus>().healthEXP;
        } else if(type == 1){
            barProgress = (float)player.GetComponent<playerStatus>().attackPointnow / (float)player.GetComponent<playerStatus>().attackEXP;
        } else if(type == 2){
            barProgress = (float)player.GetComponent<playerManager>().hp / (float)player.GetComponent<playerManager>().maxHp;
            barProgress = barProgress * ((playerStatus.healthLevel - 1) / 10.0f + 0.5f);
        }
        if(barProgress != barProgress2){
            barEffect.SetActive(true);
        }
        changeBarPosition(barProgress);
        barProgress2 = barProgress;
    }
    void changeBarPosition(float pregress){
        if(type == 2){
            transform.position = barStartPosition + (barEndPosition - barStartPosition) * pregress;
            transform.position = new Vector3(transform.position.x - test * ((6 - playerStatus.healthLevel) / 5.0f), transform.position.y, transform.position.z);
        } else {
            transform.position = barStartPosition + (barEndPosition - barStartPosition) * pregress;
        }
    }
}