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

    public void LockPlayerInput()
    {
        player.enabled = false;
    }

    public void UnlockPlayerInput()
    {
        player.enabled = true;
    }
}
