using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public TextMeshProUGUI turnDisplay;
    public Button nextTurnButton;
    public TextMeshProUGUI loseDisplay;
    private int currentPlayer = 1;
    private int totalPlayers => PlayerData.Instance.PlayerCount; // Set this to your desired number of players
    private bool turnChangePossible = false;

    private void Start()
    {
        nextTurnButton.onClick.AddListener(AdvanceTurn);
        UpdateTurnDisplay();
    }

    private void AdvanceTurn()
    {
        if (turnChangePossible)
        {
            currentPlayer = (currentPlayer % totalPlayers) + 1;
            UpdateTurnDisplay();
            turnChangePossible = false;
        }
    }

    private void UpdateTurnDisplay()
    {
        turnDisplay.text = "Player " + currentPlayer;
    }

    public void UpdateTurnChangePossible()
    {
        turnChangePossible = true;
    }

    public void PlayerLoseDisplay()
    {
        loseDisplay.gameObject.SetActive(true);
        StartCoroutine(FadeTextToFullAlpha());
    }
    
    public IEnumerator FadeTextToFullAlpha()
    {
        loseDisplay.color = new Color(loseDisplay.color.r, loseDisplay.color.g, loseDisplay.color.b, 0);
        while (loseDisplay.color.a < 1.0f)
        {
            loseDisplay.color = new Color(loseDisplay.color.r, loseDisplay.color.g, loseDisplay.color.b, loseDisplay.color.a + (Time.deltaTime / 2f));
            yield return null;
        }
    }
}