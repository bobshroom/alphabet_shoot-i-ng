using UnityEngine;

[CreateAssetMenu(fileName = "alphabetInfo", menuName = "Scriptable Objects/alphabetInfo")]
public class alphabetInfo : ScriptableObject
{
    public GameObject alphabet;
    public int hp;
    public int moveSpeed;
    public float attackMulti;
    public float attackDirayMulti;
    public float invincibleTime;
}
