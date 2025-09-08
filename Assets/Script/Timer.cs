using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [Header("�������ł��鎞��")]
    [Range(30f,120f)]public float gameDuration = 60f;
    private float timer;

    [Header("Coin�Q��")]
    public Coin coin;



    // Start is called before the first frame update
    void Start()
    {
        //�^�C�}�[������
        timer = gameDuration;
    }

    void Update()
    {
        //�o�ߎ��Ԃ����Z
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Debug.Log("�ԉ΂��ł�������܂��I");


            //�������ƃA�C�e������ێ����Ă���V�[���ڍs
            PlayerPrefs.SetInt("Money",coin.money);
            PlayerPrefs.SetInt("ItemCount", coin.itemCount);
            SceneManager.LoadScene("Result");

        }

    }
}
