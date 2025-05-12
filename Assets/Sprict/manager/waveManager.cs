using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class waveManager : MonoBehaviour
{
    private float progressTime;
    [SerializeField] int currentWave = 0;
    [SerializeField] int maxWave;
    public float nextWaveTime;
    private List<wave> waves = new List<wave>();
    private List<float> wavesIterval = new List<float>();
    public List<wave> waves0 = new List<wave>();
    public List<float> wavesIterval0 = new List<float>();
    public List<wave> waves1 = new List<wave>();
    public List<float> wavesIterval1 = new List<float>();
    public List<wave> waves2 = new List<wave>();
    public List<float> wavesIterval2 = new List<float>();
    public List<wave> waves3 = new List<wave>();
    public List<float> wavesIterval3 = new List<float>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waves.AddRange(waves0);
        waves.AddRange(waves1);
        waves.AddRange(waves2);
        waves.AddRange(waves3);
        wavesIterval.AddRange(wavesIterval0);
        wavesIterval.AddRange(wavesIterval1);
        wavesIterval.AddRange(wavesIterval2);
        wavesIterval.AddRange(wavesIterval3);

        maxWave = waves.Count;
        nextWaveTime = wavesIterval[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentWave == maxWave){
            return;
        }
        progressTime = gameObject.GetComponent<GameManager>().progressTime;
        if(progressTime > nextWaveTime){
            StartCoroutine(loadWave(waves[currentWave]));
            currentWave++;
            if(currentWave == maxWave){
                return;
            }
            nextWaveTime += wavesIterval[currentWave];
        }
    }
    IEnumerator loadWave(wave wave){
        //Debug.Log("wevaのろーど");
        for(int i=0; i<wave.enemyCount; i++){
            if(wave.positionRandom){
                
                gameObject.GetComponent<enemySummoner>().summonEnemy(GetRandomVector(wave.positionMax, wave.positionMin), wave.enemyInfo);
            if(wave.time > 0){
                yield return new WaitForSeconds(wave.time);
            }
            } else {
                Vector3 kyori = new Vector3(0, 0, 0);
                if(wave.enemyCount != 1){
                    kyori = (wave.positionMax - wave.positionMin) / (wave.enemyCount-1);
                }
                gameObject.GetComponent<enemySummoner>().summonEnemy(wave.positionMin + kyori * i, wave.enemyInfo);
            }
            if(wave.time > 0){
                yield return new WaitForSeconds(wave.time);
            }
        }
        yield return 0;
    }
    
    Vector3 GetRandomVector(Vector3 a, Vector3 b){
        float t = Random.Range(0f, 1f);
        return Vector3.Lerp(a, b, t);
    }
}