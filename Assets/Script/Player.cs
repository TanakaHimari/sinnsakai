using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private Transform tr;
    
    //勝手に走る
    [SerializeField]
    [Range(1f, 2f)] private float autoSpeed = 2f;
    //3レーン制のランゲームにする
    [SerializeField] private float[] lanePositions = { -2f, 0f,2f };
    //初期位置は中央
    private int currentLane = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
