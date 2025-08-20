using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tr;
    [SerializeField] private Coin coin;


    [Header("�O�i���鑬�x")]
    [Tooltip("�v���C���[�͂��̑��x�Ŏ����ő���")]
    [SerializeField]
    [Range(1f, 2f)] private float autoSpeed = 2f;

    [Header("���[����")]
    [Tooltip("�v���C���[�͂��̈ʒu�ɂ����ړ����Ȃ�")]
    //3���[�����̃����Q�[���ɂ���
    [SerializeField] private float[] lanePositions = { -2f, 0f,2f };
    //�����ʒu�͒���
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


        //S�L�[�Ő^�񒆂�
        if (Input.GetKeyDown(KeyCode.S))
        {

            currentLane = 1;
            Debug.Log("S�L�[�Œ����ɖ߂�I currentLane = " + currentLane);
            Debug.Log("������X���W = " + lanePositions[currentLane]);


        }
            //A�L�[�ō����[����
            //���[�ɂ��Ȃ��ꍇ���s
          else  if (Input.GetKeyDown(KeyCode.A) && currentLane > 0)
            {
                currentLane--;
            }


            //D�L�[�ŉE���[����
            //�E�[�ɂ��Ȃ��ꍇ���s
            else if (Input.GetKeyDown(KeyCode.D) && currentLane < lanePositions.Length - 1)
            {
                currentLane++;
            }
        
        //���[���ɍ��킹�č��W���X�V
        Vector2 newPosition = new Vector2(lanePositions[currentLane], tr.position.y);
        tr.position = newPosition;   
    }
 
}


