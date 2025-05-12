using UnityEngine;

[CreateAssetMenu(fileName = "bullet", menuName = "Scriptable Objects/bullet")]
public class bullet : ScriptableObject
{
    public GameObject bulletImage;
    public int damage;
    public float moveSpeed;
    public int attackDiray;
    public bool isThrough;
    [Header("1:直進 2:サインカーブ 3:回転")]
    public int movementType = 1;
}
