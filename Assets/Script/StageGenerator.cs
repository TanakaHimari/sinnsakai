using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering;
//using static UnityEditor.Progress;


public class StageGenerator : MonoBehaviour
{
    [Header("�����_����������I�u�W�F�N�g")]
    public GameObject humanPrefab;
    public GameObject coinPrefab;
    public GameObject shopItemPrefab;

    [Header("�X�e�[�W�ɉ��s�z�u���邩")]
    [Range(10, 100)] public int numberOfRows = 30;

    [Header("�A�C�e���̊Ԋu")]
    [Range(1f, 10f)] public float spacing = 3f;

    [Header("���[�����ƂɊԊu�������")]
    [SerializeField, Space(5)]
    private string Left = "�����[��";
    [SerializeField] 
    [Range(0f,1f)]private float leftLaneOffset = 0.2f;

    [SerializeField, Space(5)]
    private string center = "�������[��";
    [SerializeField]
    [Range(0f, 1f)] private float centerLaneOffset = 0f;

    [SerializeField,Space(5)]
    private string right = "�E���[��";
    [SerializeField]
    [Range(0f, 1f)] private float rightLaneOffset = 0.2f;

    [Header("human��coin�����[�����ɐ���")]
    [SerializeField]
    private List<int> humancoinXOptions = new List<int> { -1, 0, 1 };

    [Header("shopItem�͒[�ɂ̂ݐ���")]
    [SerializeField]
    private List<int> shopxOptions = new List<int> { -1, 1 };


    // Start is called before the first frame update
    void Start()
    {
        //�I�������s�͈̔͂ŌJ��Ԃ�
        for (int i = 0; i < numberOfRows; i++)

        {
            List<int> hcOptions = new List<int>(humancoinXOptions);
            //hcX = human��coin��X���W��position
            //human or coin�̔z�u�ʒu�������_���ɑI��
            int hcX = hcOptions[Random.Range(0, hcOptions.Count)];

            float hcY = i * spacing + GetYOffsetByLane(hcX);

            //human or coin�������_���ɑI��Ŕz�u
            Vector3 hcPos = new Vector3(hcX, hcY, 0);
            GameObject hcPrefab = Random.value < 0.3f ? humanPrefab : coinPrefab;
            Instantiate(hcPrefab, hcPos, Quaternion.identity);

            List<int> sOptions = new List<int>(shopxOptions);
            //�d���h�~
           

            //��񂨂��ɔz�u
            if (i % 2 == 0) 
            {

                if (sOptions.Count > 0)
                {
                    int sX = shopxOptions[Random.Range(0, shopxOptions.Count)];
                  

                    float sY = i * spacing + GetYOffsetByLane(sX);

                    //�V���b�v�A�C�e����z�u
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

   