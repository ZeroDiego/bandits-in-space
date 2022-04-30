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
    private float turnTransistionDuration = 1.5f;

    [SerializeField] private int turnID;

    [SerializeField] private bool nextTurn;
    [SerializeField] private bool turnTransistionBoolean;

    void Start()
    {
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

    public void SetTurn()
    {
        turnTransistionBoolean = true;
        turnID++;
        turnText.text = "Turn: " + turnID;
    }

    private void FirstTurn()
    {
        bandits[0].isTurn = true;
        turnID++;
        turnText.text = "Turn: " + turnID;
    }

    private void NextTurn()
    {
        if (turnID % turnOrder.Length == 0)
        {
            if (bandits[0] != null)
                bandits[0].isTurn = true;
            if (bandits[1] != null)
                bandits[1].isTurn = false;
            
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].isTurn = false;
            }
        }
        else if (turnID % turnOrder.Length == 1)
        {
            if (bandits[0] != null)
                bandits[0].isTurn = false;
            if (bandits[1] != null)
                bandits[1].isTurn = true;

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

            if (enemies.Length < 2)
            {
                enemies[0].isTurn = true;
            }
            else
            {
                if (enemies[0] != null)
                    enemies[0].isTurn = true;
                if (enemies[1] != null)
                    enemies[1].isTurn = false;
            }
        }
        else if (turnID % turnOrder.Length == 3)
        {
            for (int i = 0; i < bandits.Length; i++)
            {
                bandits[i].isTurn = false;
            }

            if (enemies.Length < 2)
            {
                enemies[0].isTurn = true;
            }
            else
            {
                if (enemies[0] != null)
                    enemies[0].isTurn = false;
                if (enemies[1] != null)
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
