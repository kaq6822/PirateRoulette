using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
    public TextMeshProUGUI howToPlayText;
    
    public Button startButton;
    public GameObject holeMenu;
    public GameObject playerMenu;

    void Start()
    {
        Debug.Log("Start How to play");
    }

    public void ToggleHowToPlayText()
    {
        Debug.Log("Toggle how to play");
        howToPlayText.gameObject.SetActive(!howToPlayText.gameObject.activeSelf);
        startButton.gameObject.SetActive(!startButton.gameObject.activeSelf);
        holeMenu.gameObject.SetActive(!holeMenu.gameObject.activeSelf);
        playerMenu.gameObject.SetActive(!playerMenu.gameObject.activeSelf);
    }
}
