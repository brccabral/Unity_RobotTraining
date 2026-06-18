using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Player player;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        player.GetComponent<HealthModule>().OnDeath += GameOver;
        LockPlayerInput();
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
