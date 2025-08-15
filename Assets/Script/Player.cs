using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private Transform tr;
    
    //����ɑ���
    [SerializeField]
    [Range(1f, 2f)] private float autoSpeed = 2f;
    //3���[�����̃����Q�[���ɂ���
    [SerializeField] private float[] lanePositions = { -2f, 0f,2f };
    //�����ʒu�͒���
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
