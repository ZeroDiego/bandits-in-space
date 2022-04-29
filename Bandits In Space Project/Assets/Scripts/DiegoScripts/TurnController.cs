using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public PlayerBandit[] bandits;
    public EnemyMovement enemyMovement;

    [SerializeField] private float turnTransistionTimer;
    private float turnTransistionDuration = 1.5f;

    private int turnID;

    [SerializeField] private bool playerTurn;
    [SerializeField] private bool enemyTurn;
    [SerializeField] private bool turnTransistionBoolean;

    void Start()
    {
        turnID = 0;
        turnTransistionTimer = turnTransistionDuration;
        playerTurn = true;
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
            if (playerTurn)
            {
                PlayerTurn();
            }
            else if (enemyTurn)
            {
                EnemyTurn();
            }
        }
    }

    public void setPlayerTurn(bool value)
    {
        turnTransistionBoolean = true;
        playerTurn = value;
        enemyTurn = !value;
    }

    public void setEnemyTurn(bool value)
    {
        turnTransistionBoolean = true;
        enemyTurn = value;
        playerTurn = !value;
    }

    private void PlayerTurn()
    {
        //bandits.isTurn = true;
        enemyMovement.isTurn = false;
        turnID++;
    }

    private void EnemyTurn()
    {
        enemyMovement.isTurn = true;
        //bandits.isTurn = false;
        turnID++;
    }

    private void TurnTransistion()
    {
        //bandits.isTurn = false;
        enemyMovement.isTurn = false;
        turnTransistionTimer -= Time.deltaTime;
    }
}
