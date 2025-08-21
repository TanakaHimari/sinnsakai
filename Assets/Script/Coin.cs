using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    [Tooltip("��������\������e�L�X�g")]
    [SerializeField] private TextMeshProUGUI moneyText;

    [Tooltip("���y�Y����\������e�L�X�g")]
    [SerializeField] private TextMeshProUGUI itemText;

    public  int money = 0;
    public int itemCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //�R�C���ɐG�ꂽ�珊�����𑝂₷
        if (other.CompareTag("Coin"))
        {
            money += 500;
            UpdateUI();
            //�G�ꂽ�R�C���͏�����
            Destroy(other.gameObject); 
        }
    }

    public void UpdateUI()
    {
        if (moneyText != null)
        {
            moneyText.text = $"������:\n{money} �~";
        }
        else
        {
            Debug.LogWarning("moneyText ���ݒ肳��Ă��܂���I");
        }

        if (itemText != null)
        {
            itemText.text = $"���y�Y:\n{itemCount}��";
        }
        else
        {
            Debug.LogWarning("ItemText ���ݒ肳��Ă��܂���I");
        }

    }
   /// <summary>
   /// �A�C�e�����X�V
   /// </summary>
    public void AddItem()
    {
        itemCount++;
        UpdateUI();
    }
}