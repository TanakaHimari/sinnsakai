using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText; // UI表示用
    private int money = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            money += 500;
            UpdateUI();
            Destroy(other.gameObject); // コインを消す
        }
    }

    private void UpdateUI()
    {
        if (moneyText != null)
        {
            moneyText.text = $"所持金：{money} 円";
        }
        else
        {
            Debug.LogWarning("moneyText が設定されていません！");
        }
    }
}