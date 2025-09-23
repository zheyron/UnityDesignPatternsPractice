using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour

{
    public static ScoreManager Instance;

    public static event Action<float> OnCoinsChanged;
    public static float Coins { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public static void AddCoins(float amount = 1)
    {
        Coins += amount;
        Debug.Log($"Added coin. Current Coins: {Coins}");
        OnCoinsChanged?.Invoke(Coins); // Si OnCoinsChanged no es nulo, avisa

        if (Coins % 3 == 0)
        {
            SceneManagerSimple.Instance.LoadNextLevel();
        }
    }

    public static void Reset()
    {
        Coins = 0;
        OnCoinsChanged?.Invoke(Coins);
        Debug.Log($"Coins reseted. Current Coins: {Coins}");
    }
}
