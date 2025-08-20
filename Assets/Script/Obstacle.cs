using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour

{
    [Header("落とす金の額")]
    [Tooltip("障害物にぶつかった際に所持金が減る")]
    [SerializeField]
    [Range(500, 1000)] private int damegeMoney = 500;

    [Header("落とすアイテム数")]
    [Tooltip("障害物にぶつかった際にアイテムが減る")]
    [SerializeField]
    [Range(1, 5)] private int damegeItem = 1;

    [Header("移動速度低下する秒数")]
    [Tooltip("障害物にぶつかった際に一定時間デバフがかかる")]
    [SerializeField]
    [Range(1f, 5f)] private float slowDuration = 3f;

    [Header("移動速度の倍率")]
    [Tooltip("障害物にぶつかった際にこの速度で走る。\n秒数はslowDurationで決定される。")]
    [SerializeField]
    [Range(0.1f, 0.9f)] private float slowFactor = 0.5f;

    //プレイヤーが人にぶつかった際の処理
    private void OnTriggerEnter2D(Collider2D other)
    {
        //プレイヤーに接触しなかったらこの処理はしない
        if (!other.CompareTag("Player")) return;

        //Coin.csを探してcoinSystemに格納している
        Coin coinSystem = other.GetComponent<Coin>();

        //Player.csを探してmovementに格納している
        Player movement = other.GetComponent<Player>();

        //所持金とアイテム数を減らす処理
        if (coinSystem != null)
        {
            //マイナスにならないようにする
            coinSystem.money = Mathf.Max(0, coinSystem.money - damegeMoney);
            coinSystem.itemCount = Mathf.Max(0,coinSystem.itemCount - damegeItem);

            //UI更新
            coinSystem.UpdateUI();
        }

        //一時的に移動速度を低下させる処理
        if (movement != null)
        {
            movement.ApplySpeedModifier(slowFactor, slowDuration);
        }

        Debug.Log("障害物に接触！所持金とアイテム数を減らし、速度低下を適用");

    }

}