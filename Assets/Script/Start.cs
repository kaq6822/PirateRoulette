using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start : MonoBehaviour
{
    public Button startButton;
    public TextMeshProUGUI playerCountText;
    public TextMeshProUGUI holeCountText;

    public void StartButtonClick()
    {
        // 문자열을 정수로 변환하려면 int.Parse()나 int.TryParse() 메서드를 사용합니다.
        if (playerCountText != null)
        {
            int playerCount = 2;
            int.TryParse(playerCountText.text, out playerCount);
            PlayerData.Instance.PlayerCount = playerCount;
        }
        else
        {
            PlayerData.Instance.PlayerCount = 2;
        }

        if (holeCountText != null)
        {
            int holeCount = 16;
            int.TryParse(holeCountText.text, out holeCount);
            
            Debug.Log(holeCount);
            PlayerData.Instance.HoleCount = holeCount;
        }
        else
        {
            PlayerData.Instance.HoleCount = 16;
        }
        
        SceneManager.LoadScene("GameScene");
    }
}
