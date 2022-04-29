using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public PlayerBandit[] bandits;
    public EnemyMovement[] enemies;

    public string[] turnOrder;

    [SerializeField] private float turnTransistionTimer;
    private float turnTransistionDuration = 1.5f;

    [SerializeField] private int turnID;

    [SerializeField] private bool nextTurn;
    [SerializeField] private bool turnTransistionBoolean;

    void Start()
    {
        turnID = 0;
        turnTransistionTimer = turnTransistionDuration;

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

    public void SetTurn()
    {
        turnTransistionBoolean = true;
        turnID++;
    }

    private void FirstTurn()
    {
        bandits[0].isTurn = true;
        turnID++;
    }

    private void NextTurn()
    {
        if (turnID % turnOrder.Length == 0)
        {
            bandits[0].isTurn = true;
            bandits[1].isTurn = false;
            enemies[0].isTurn = false;
            enemies[1].isTurn = false;
        }
        else if (turnID % turnOrder.Length == 1)
        {
            bandits[0].isTurn = false;
            bandits[1].isTurn = true;
            enemies[0].isTurn = false;
            enemies[1].isTurn = false;
        }
        else if (turnID % turnOrder.Length == 2)
        {
            bandits[0].isTurn = false;
            bandits[1].isTurn = false;
            enemies[0].isTurn = true;
            enemies[1].isTurn = false;
        }
        else if (turnID % turnOrder.Length == 3)
        {
            bandits[0].isTurn = false;
            bandits[1].isTurn = false;
            enemies[0].isTurn = false;
            enemies[1].isTurn = true;
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
