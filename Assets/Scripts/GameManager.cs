using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Player player;
    [SerializeField] private UnityEvent OnStart;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        // player.GetComponent<HealthModule>().OnDeath += GameOver;
        OnStart?.Invoke();
    }

    public void LockPlayerInput()
    {
        player.enabled = false;
    }

    public void UnlockPlayerInput()
    {
        player.enabled = true;
    }

    public Player GetPlayer()
    {
        return player;
    }

    public void GameOver()
    {
        LockPlayerInput();
        // Register Score
        // Respawn Player
        // Respawn Enemies
    }
}
