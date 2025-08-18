using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText; // UI�\���p
    private int money = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            money += 500;
            UpdateUI();
            Destroy(other.gameObject); // �R�C��������
        }
    }

    private void UpdateUI()
    {
        if (moneyText != null)
        {
            moneyText.text = $"�������F{money} �~";
        }
        else
        {
            Debug.LogWarning("moneyText ���ݒ肳��Ă��܂���I");
        }
    }
}