using UnityEngine;
using UnityEngine.UIElements;

public class enemySummoner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private enemy enemyInfo;
    private Transform parent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parent = GameObject.Find("alphabet/enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)){
            summonEnemy(new Vector2(0, 6), enemyInfo);
        }
    }
    public void summonEnemy(Vector2 position, enemy enemyInfo){
        GameObject enemyObj = Instantiate(enemyPrefab, position, Quaternion.identity);
        enemyObj.GetComponent<enemyMovement>().enemyInfo = enemyInfo;
        enemyObj.GetComponent<enemyManager>().enemyInfo = enemyInfo;
        enemyObj.GetComponent<enemyManager>().bulletInfo = enemyInfo.bullet;
        enemyObj.name = enemyPrefab.name;
        enemyObj.transform.parent = parent;
    }
}
