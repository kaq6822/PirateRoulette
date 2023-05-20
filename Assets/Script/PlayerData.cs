using System;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private static PlayerData _instance;

    public static PlayerData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerData>();
                
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "PlayerData";
                    _instance = go.AddComponent<PlayerData>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public int PlayerCount { get; set; }
    public int HoleCount { get; set; }

    // Other methods and variables...
}