using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

[CreateAssetMenu(fileName = "enemy", menuName = "Scriptable Objects/enemy")]
public class enemy : ScriptableObject
{
    public GameObject enemyImage;
    public bullet bullet;
    public int hp;
    public float moveSpeed;
    public int contactDamage;
    public int score;
    [Tooltip("自機を強化するポイント 一個目は体力強化、二個目は攻撃力強化")]
    public List<int> point = new List<int>{0, 0};
    [Tooltip("被ダメージ時のリアクションのタイプ。0ならエフェクトなし")]
    public int hitEffectType;
    [Tooltip("1:突進、2:射撃、3:ボス級")]
    public int enemyType = 1;
    public AudioClip audioClip;
    public AudioClip deathSound;
    public float bulletSpeedMulti = 1.0f;
    [Tooltip("1:まっすぐに進む。 2:出現後少し進み停止。行動したのちフェードアウト")]
    public int movementType = 1;
    [Tooltip("プレイヤーを見るかどうか")]
    public bool lookAtPlayer;
    public int rotate;
    [Tooltip("アニメーションさせるかどうか。")]
    public bool animation= false;
    [Tooltip("1:一定時間ごとに発射 2:指定した時間に発射開始 3:チャージ後発射")]
    public int bulletType = 1;
    [Tooltip("チャージにかかる時間"),Header("チャージに関する設定")]
    public float chargeTime = 0;
    [Tooltip("一回のチャージで打てる球の数")]
    public int chargeCount;
    [Tooltip("チャージ発射中のインターバル")]
    public float chargeInterval;
    [Tooltip("弾の発射回数 -1なら無制限"), Header("------------------------------------------------")]
    public int bulletCount = 0;
    [Tooltip("弾の発射間隔")]
    public float bulletInterval = 1.0f;
    [Tooltip("弾のばらつき(角度)")]
    public float shaking;
    [Tooltip("ショットガンがどちらから打ち始めるか trueなら右から"), Header("ここからはショットガンに関する設定")]
    public bool startRight = true;
    [Tooltip("一回の発射で打つ玉の数")]
    public int countShot = 1;
    [Tooltip("角度")]
    public float hirogeru;
    [Tooltip("間隔")]
    public float hirogaruTime;
}