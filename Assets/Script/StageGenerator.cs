using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering;
//using static UnityEditor.Progress;


public class StageGenerator : MonoBehaviour
{
    [Header("ランダム生成するオブジェクト")]
    public GameObject humanPrefab;
    public GameObject coinPrefab;
    public GameObject shopItemPrefab;

    [Header("ステージに何行配置するか")]
    [Range(10, 100)] public int numberOfRows = 30;

    [Header("アイテムの間隔")]
    [Range(1f, 10f)] public float spacing = 3f;

    [Header("レーンごとに間隔を微調整")]
    [SerializeField, Space(5)]
    private string Left = "左レーン";
    [SerializeField] 
    [Range(0f,1f)]private float leftLaneOffset = 0.2f;

    [SerializeField, Space(5)]
    private string center = "中央レーン";
    [SerializeField]
    [Range(0f, 1f)] private float centerLaneOffset = 0f;

    [SerializeField,Space(5)]
    private string right = "右レーン";
    [SerializeField]
    [Range(0f, 1f)] private float rightLaneOffset = 0.2f;

    [Header("humanとcoinをレーン内に生成")]
    [SerializeField]
    private List<int> humancoinXOptions = new List<int> { -1, 0, 1 };

    [Header("shopItemは端にのみ生成")]
    [SerializeField]
    private List<int> shopxOptions = new List<int> { -1, 1 };


    // Start is called before the first frame update
    void Start()
    {
        //選択した行の範囲で繰り返す
        for (int i = 0; i < numberOfRows; i++)

        {
            List<int> hcOptions = new List<int>(humancoinXOptions);
            //hcX = humanとcoinのX座標のposition
            //human or coinの配置位置をランダムに選択
            int hcX = hcOptions[Random.Range(0, hcOptions.Count)];

            float hcY = i * spacing + GetYOffsetByLane(hcX);

            //human or coinをランダムに選んで配置
            Vector3 hcPos = new Vector3(hcX, hcY, 0);
            GameObject hcPrefab = Random.value < 0.3f ? humanPrefab : coinPrefab;
            Instantiate(hcPrefab, hcPos, Quaternion.identity);

            List<int> sOptions = new List<int>(shopxOptions);
            //重複防止
           

            //二回おきに配置
            if (i % 2 == 0) 
            {

                if (sOptions.Count > 0)
                {
                    int sX = shopxOptions[Random.Range(0, shopxOptions.Count)];
                  

                    float sY = i * spacing + GetYOffsetByLane(sX);

                    //ショップアイテムを配置
                    Vector3 sPos = new Vector3(sX, sY, 0);
                    Instantiate(shopItemPrefab, sPos, Quaternion.identity);
                    sOptions.Remove(hcX);
                }

            }
        }

        }

    float GetYOffsetByLane(int X)
    {
        switch (X)
        {
            case 0: return leftLaneOffset;
            case 1: return centerLaneOffset;
            case 2 : return rightLaneOffset;
            default: return 0f;
        }
    }
}

   