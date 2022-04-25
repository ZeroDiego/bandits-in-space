using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public Bandit bandit;
    public EnemyMovement enemyMovement;

    private int turnID;

    [SerializeField] private bool playerTurn;
    [SerializeField] private bool enemyTurn;

    void Start()
    {
        turnID = 0;
        playerTurn = true;
    }

    
    void Update()
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

    public void setPlayerTurn(bool value)
    {
        playerTurn = value;

        if (!value)
            enemyTurn = true;
    }

    public void setEnemyTurn(bool value)
    {
        enemyTurn = value;

        if (!value)
            playerTurn = true;
    }

    private void PlayerTurn()
    {
        bandit.isTurn = true;
        enemyMovement.isTurn = false;
        turnID++;
    }

    private void EnemyTurn()
    {
        enemyMovement.isTurn = true;
        bandit.isTurn = false;
        turnID++;
    }
}
