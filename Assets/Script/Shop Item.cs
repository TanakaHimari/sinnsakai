using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
   
    [SerializeField] 
    [Range(1,5)]private int rawPrice = 2;

    /// <summary>
    /// ���i�̉��i��500�~�P�ʂŐݒ�
    /// </summary>
    public int Price
    {
       get { return rawPrice * 500; }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //�v���C���[�ɐڐG���Ȃ������炱�̏����͂��Ȃ�
        if (!other.CompareTag("Player")) return;

        //Coin.cs��T����coinSystem�Ɋi�[���Ă���
        Coin coinSystem = other.GetComponent<Coin>();

        //�������������΂��y�Y��������
        if (coinSystem != null && coinSystem.money >= Price)
        {
            //���i�㕪�����������炷
            coinSystem.money -= Price;
            //�y�Y���𑝂₷
            coinSystem.AddItem();
            //UI�X�V
            coinSystem.UpdateUI();


            Debug.Log($"�A�C�e���w�������I{Price}�~�ōw�����܂����I");
            //���i������
            Destroy(gameObject);
        }

        else
        {
            int shortage = Price - coinSystem.money;
            Debug.Log($"������������܂���I���� {shortage} �~�K�v�ł�");

        }

    }

}
