using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpDownCount : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public int countNumber = 1;
    public int max;
    public int min;
    public int increaseNum;
    void Start()
    {
        UpdateNumberText();
    }
    
    public void IncreaseNumber() {
        if (countNumber < max) {
            countNumber+=increaseNum;
            UpdateNumberText();
        }
    }

    public void DecreaseNumber() {
        if (countNumber > min) {
            countNumber-=increaseNum;
            UpdateNumberText();
        }
    }

    private void UpdateNumberText()
    {
        numberText.text = countNumber.ToString();
    }
}
