using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tr;
    [SerializeField] private Coin coin;


    [Header("通常の前進速度")]
    [Tooltip("プレイヤーはこの速度で自動で走る")]
    [SerializeField]
    [Range(1f, 100f)] private float baseSpeed = 2f;

    //実際に使われる移動速度
    private float currentSpeed;

    //速度低下中かどうかのフラグ
    private bool isSlowed = false;


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

        //初期速度を設定
        currentSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0f, baseSpeed);


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

    /// <summary>
    /// 一時的に速度を変更する関数
    /// </summary>
    /// <param name="factor">速度の倍率</param>
    /// <param name="duration">持続時間</param>
    public void ApplySpeedModifier(float factor,float duration)
    {
        //すでに低下中なら重複しない
        if (!isSlowed)
        {
            StartCoroutine(SlowDownTemporarily(factor,duration));
        }
    }

    private IEnumerator SlowDownTemporarily(float factor, float duration)
    {
        isSlowed = true;
        //移動速度を低下
        currentSpeed = baseSpeed * factor;
        //指定時間待つ
        yield return new WaitForSeconds(duration);

        //元の速度に戻す
        currentSpeed = baseSpeed;
        isSlowed = false;
    }


}


