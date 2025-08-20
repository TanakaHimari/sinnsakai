using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour

{
    [Header("���Ƃ����̊z")]
    [Tooltip("��Q���ɂԂ������ۂɏ�����������")]
    [SerializeField]
    [Range(500, 1000)] private int damegeMoney = 500;

    [Header("���Ƃ��A�C�e����")]
    [Tooltip("��Q���ɂԂ������ۂɃA�C�e��������")]
    [SerializeField]
    [Range(1, 5)] private int damegeItem = 1;

    [Header("�ړ����x�ቺ����b��")]
    [Tooltip("��Q���ɂԂ������ۂɈ�莞�ԃf�o�t��������")]
    [SerializeField]
    [Range(1f, 5f)] private float slowDuration = 3f;

    [Header("�ړ����x�̔{��")]
    [Tooltip("��Q���ɂԂ������ۂɂ��̑��x�ő���B\n�b����slowDuration�Ō��肳���B")]
    [SerializeField]
    [Range(0.1f, 0.9f)] private float slowFactor = 0.5f;

    //�v���C���[���l�ɂԂ������ۂ̏���
    private void OnTriggerEnter2D(Collider2D other)
    {
        //�v���C���[�ɐڐG���Ȃ������炱�̏����͂��Ȃ�
        if (!other.CompareTag("Player")) return;

        //Coin.cs��T����coinSystem�Ɋi�[���Ă���
        Coin coinSystem = other.GetComponent<Coin>();

        //Player.cs��T����movement�Ɋi�[���Ă���
        Player movement = other.GetComponent<Player>();

        //�������ƃA�C�e���������炷����
        if (coinSystem != null)
        {
            //�}�C�i�X�ɂȂ�Ȃ��悤�ɂ���
            coinSystem.money = Mathf.Max(0, coinSystem.money - damegeMoney);
            coinSystem.itemCount = Mathf.Max(0,coinSystem.itemCount - damegeItem);

            //UI�X�V
            coinSystem.UpdateUI();
        }

        //�ꎞ�I�Ɉړ����x��ቺ�����鏈��
        if (movement != null)
        {
            movement.ApplySpeedModifier(slowFactor, slowDuration);
        }

        Debug.Log("��Q���ɐڐG�I�������ƃA�C�e���������炵�A���x�ቺ��K�p");

    }

}