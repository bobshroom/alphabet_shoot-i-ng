using UnityEngine;

[CreateAssetMenu(fileName = "wave", menuName = "Scriptable Objects/weve")]
public class wave : ScriptableObject
{
    public enemy enemyInfo;
    public Vector3 positionMax;
    public Vector3 positionMin;
    public bool positionRandom = false;
    [Header("数")] public int enemyCount;
    [Header("間隔")] public float time;
}