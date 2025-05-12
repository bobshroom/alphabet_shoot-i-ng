using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerAttackment : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private bullet bulletInfo;
    [SerializeField] private alphabetInfo alphabetInfo;
    private float diray;
    [SerializeField] private List<float> dirayMultiList;
    private float time;
    private Transform bulletParent;
    private AudioSource audioSource;
    public AudioClip bulletClip;
    private playerStatus playerStatus;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diray = bulletInfo.attackDiray * alphabetInfo.attackDirayMulti;
        bulletParent = GameObject.Find("bullet/player").transform;
        audioSource = gameObject.GetComponent<AudioSource>();
        playerStatus = gameObject.GetComponent<playerStatus>();

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime * 60.0f;
        if(Input.GetKey(KeyCode.Space)){
            if(time < 0){
                shot(bulletInfo);
            }
        }
    }
    void shot(bullet bulletInfo)
    {
        audioSource.volume = 0.15f;
        audioSource.clip = bulletClip;
        audioSource.Play();
        time = diray * dirayMultiList[playerStatus.attackLevel-1];
        if(playerStatus.attackLevel <= 4){
            GameObject instant = Instantiate(bullet, transform.position, Quaternion.identity);
            instant.GetComponent<bulletMovement>().bulletInfo = bulletInfo;
            instant.transform.position += new Vector3(0, 0.34f, 0);
            instant.tag = "playerAttack";
            instant.GetComponent<bulletMovement>().bulletSpeedMulti = 1.0f;
            instant.transform.parent = bulletParent;
            instant.transform.eulerAngles = new Vector3(0, 0, 0);
        } else if (playerStatus.attackLevel <= 9){
            for(int i=0; i<2; i++){
                GameObject instant = Instantiate(bullet, transform.position, Quaternion.identity);
                instant.GetComponent<bulletMovement>().bulletInfo = bulletInfo;
                instant.transform.position += new Vector3(0, 0.34f, 0);
                instant.tag = "playerAttack";
                instant.GetComponent<bulletMovement>().bulletSpeedMulti = 1.0f;
                instant.transform.parent = bulletParent;
                instant.transform.eulerAngles = new Vector3(0, 0, -3 + 6 * i);
            }
        } else {
            for(int i=0; i<3; i++){
                GameObject instant = Instantiate(bullet, transform.position, Quaternion.identity);
                instant.GetComponent<bulletMovement>().bulletInfo = bulletInfo;
                instant.transform.position += new Vector3(0, 0.34f, 0);
                instant.tag = "playerAttack";
                instant.GetComponent<bulletMovement>().bulletSpeedMulti = 1.0f;
                instant.transform.parent = bulletParent;
                instant.transform.eulerAngles = new Vector3(0, 0, -5 + 5 * i);
            }
        }
    }
}
