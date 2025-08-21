using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tr;
    [SerializeField] private Coin coin;


    [Header("�ʏ�̑O�i���x")]
    [Tooltip("�v���C���[�͂��̑��x�Ŏ����ő���")]
    [SerializeField]
    [Range(1f, 100f)] private float baseSpeed = 2f;

    //���ۂɎg����ړ����x
    private float currentSpeed;

    //���x�ቺ�����ǂ����̃t���O
    private bool isSlowed = false;


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

        //�������x��ݒ�
        currentSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0f, baseSpeed);


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

    /// <summary>
    /// �ꎞ�I�ɑ��x��ύX����֐�
    /// </summary>
    /// <param name="factor">���x�̔{��</param>
    /// <param name="duration">��������</param>
    public void ApplySpeedModifier(float factor,float duration)
    {
        //���łɒቺ���Ȃ�d�����Ȃ�
        if (!isSlowed)
        {
            StartCoroutine(SlowDownTemporarily(factor,duration));
        }
    }

    private IEnumerator SlowDownTemporarily(float factor, float duration)
    {
        isSlowed = true;
        //�ړ����x��ቺ
        currentSpeed = baseSpeed * factor;
        //�w�莞�ԑ҂�
        yield return new WaitForSeconds(duration);

        //���̑��x�ɖ߂�
        currentSpeed = baseSpeed;
        isSlowed = false;
    }


}


