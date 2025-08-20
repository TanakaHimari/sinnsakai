using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tr;
    [SerializeField] private Coin coin;


    [Header("前進する速度")]
    [Tooltip("プレイヤーはこの速度で自動で走る")]
    [SerializeField]
    [Range(1f, 2f)] private float autoSpeed = 2f;

    [Header("レーン数")]
    [Tooltip("プレイヤーはこの位置にしか移動しない")]
    //3レーン制のランゲームにする
    [SerializeField] private float[] lanePositions = { -2f, 0f,2f };
    //初期位置は中央
    private int currentLane = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0f, autoSpeed);


        //Sキーで真ん中へ
        if (Input.GetKeyDown(KeyCode.S))
        {

            currentLane = 1;
            Debug.Log("Sキーで中央に戻る！ currentLane = " + currentLane);
            Debug.Log("中央のX座標 = " + lanePositions[currentLane]);


        }
            //Aキーで左レーンへ
            //左端にいない場合実行
          else  if (Input.GetKeyDown(KeyCode.A) && currentLane > 0)
            {
                currentLane--;
            }


            //Dキーで右レーンへ
            //右端にいない場合実行
            else if (Input.GetKeyDown(KeyCode.D) && currentLane < lanePositions.Length - 1)
            {
                currentLane++;
            }
        
        //レーンに合わせて座標を更新
        Vector2 newPosition = new Vector2(lanePositions[currentLane], tr.position.y);
        tr.position = newPosition;   
    }
 
}


