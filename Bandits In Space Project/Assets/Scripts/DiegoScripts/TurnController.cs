using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnController : MonoBehaviour
{
    public PlayerBandit[] bandits;
    public EnemyMovement[] enemies;

    public Text turnText;

    [SerializeField] private string[] turnOrder;

    [SerializeField] private float turnTransistionTimer;
    [SerializeField] private float turnTransistionDuration;

    [SerializeField] private int turnID;
    private int maxPlayers;
    private int maxEnemies;

    [SerializeField] private bool nextTurn;
    [SerializeField] private bool turnTransistionBoolean;

    void Start()
    {
        maxPlayers = bandits.Length;
        maxEnemies = enemies.Length;

        turnID = 0;
        turnTransistionTimer = turnTransistionDuration;

        turnOrder = new string[bandits.Length + enemies.Length];

        for (int i = 0; i < bandits.Length; i++)
        {
            turnOrder[i] = bandits[i].gameObject.name;
        }

        for (int i = bandits.Length; i < turnOrder.Length; i++)
        {
            turnOrder[i] = enemies[i - bandits.Length].gameObject.name;
        }

        FirstTurn();
    }


    void Update()
    {
        if (turnTransistionTimer <= 0.0f)
        {
            turnTransistionBoolean = false;
            turnTransistionTimer = turnTransistionDuration;
        }

        if (turnTransistionBoolean)
        {
            TurnTransistion();
        }
        else
        {
            NextTurn();
        }
    }

    public void SetPlayerArray(string turnActor)
    {
        int index = 0;

        for (int i = 0; i < turnOrder.Length; i++)
        {
            if (turnOrder[i].Equals(turnActor))
            {
                index = i;
            }
        }

        for (int i = index; i < bandits.Length - 1; i++)
        {
            bandits[i] = bandits[i + 1];
        }

        Array.Resize(ref bandits, bandits.Length - 1);
    }

    public void SetEnemyArray(string turnActor)
    {
        int index = 0;

        for (int i = 0; i < turnOrder.Length; i++)
        {
            if (turnOrder[i].Equals(turnActor))
            {
                index = i;
            }
        }

        for (int i = index - bandits.Length; i < enemies.Length - 1; i++)
        {
            enemies[i] = enemies[i + 1];
        }

        Array.Resize(ref enemies, enemies.Length - 1);
    }

    public void SetTurn(string turnActor)
    {
        turnTransistionBoolean = true;
        turnID++;
        turnText.text = "Actor: " + turnActor + "\nTurn: " + turnID;
    }

    private void FirstTurn()
    {
        bandits[0].isTurn = true;
        string turnActor = bandits[0].gameObject.name;
        turnText.text = "Actor: " + turnActor + "\nTurn: " + turnID;
    }

    private void NextTurn()
    {
        if (turnID % turnOrder.Length == 0)
        {
            if (bandits.Length < maxPlayers)
            {
                bandits[0].isTurn = true;
            }
            else
            {
                bandits[0].isTurn = true;
                bandits[1].isTurn = false;
            }

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].isTurn = false;
            }
        }
        else if (turnID % turnOrder.Length == 1)
        {
            if (bandits.Length < maxPlayers && enemies.Length == maxEnemies)
            {
                bandits[0].isTurn = true;
            }
            else if (bandits.Length == maxPlayers && enemies.Length < maxEnemies)
            {
                bandits[0].isTurn = false;
                bandits[1].isTurn = true;
            }
            else if (bandits.Length == maxPlayers && enemies.Length == maxEnemies)
            {
                bandits[0].isTurn = false;
                bandits[1].isTurn = true;
            }
            else if (bandits.Length < maxPlayers && enemies.Length < maxEnemies)
            {
                bandits[0].isTurn = true;
            }

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].isTurn = false;
            }
        }
        else if (turnID % turnOrder.Length == 2)
        {
            for (int i = 0; i < bandits.Length; i++)
            {
                bandits[i].isTurn = false;
            }

            if (enemies.Length < maxEnemies)
            {
                enemies[0].isTurn = true;
            }
            else
            {
                enemies[0].isTurn = true;
                enemies[1].isTurn = false;
            }
        }
        else if (turnID % turnOrder.Length == 3)
        {
            for (int i = 0; i < bandits.Length; i++)
            {
                bandits[i].isTurn = false;
            }

            if (enemies.Length < maxEnemies)
            {
                enemies[0].isTurn = true;
            }
            else
            {
                enemies[0].isTurn = false;
                enemies[1].isTurn = true;
            }
        }
    }

    private void TurnTransistion()
    {
        foreach (PlayerBandit player in bandits)
        {
            player.isTurn = false;
        }

        foreach (EnemyMovement enemy in enemies)
        {
            enemy.isTurn = false;
        }

        turnTransistionTimer -= Time.deltaTime;
    }
}
