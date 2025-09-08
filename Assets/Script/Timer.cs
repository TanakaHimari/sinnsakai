using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [Header("買い物できる時間")]
    [Range(30f,120f)]public float gameDuration = 60f;
    private float timer;

    [Header("Coin参照")]
    public Coin coin;



    // Start is called before the first frame update
    void Start()
    {
        //タイマー初期化
        timer = gameDuration;
    }

    void Update()
    {
        //経過時間を減算
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Debug.Log("花火が打ちあがります！");


            //所持金とアイテム数を保持してからシーン移行
            PlayerPrefs.SetInt("Money",coin.money);
            PlayerPrefs.SetInt("ItemCount", coin.itemCount);
            SceneManager.LoadScene("Result");

        }

    }
}
