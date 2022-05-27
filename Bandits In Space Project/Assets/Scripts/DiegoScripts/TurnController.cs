using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnController : MonoBehaviour
{
    [SerializeField] private Entity[] entities;

    public Text turnText;

    [SerializeField] private float turnTransistionTimer;
    [SerializeField] private float turnTransistionDuration;

    [SerializeField] private int turnID;
    private int maxEntities;

    [SerializeField] private bool nextTurn;
    [SerializeField] private bool turnTransistionBoolean;

    private void Awake()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Entity[] playerEntities = new Entity[players.Length];

        for (int i = 0; i < players.Length; i++)
        {
             playerEntities[i] = players[i].GetComponent<Entity>();
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Entity[] enemyEntities = new Entity[enemies.Length];

        for (int i = 0; i < enemies.Length; i++)
        {
            enemyEntities[i] = enemies[i].GetComponent<Entity>();
        }

        Array.Resize(ref entities, playerEntities.Length + enemyEntities.Length);
        Array.Copy(playerEntities, entities, playerEntities.Length);
        Array.Copy(enemyEntities, 0, entities, playerEntities.Length, enemyEntities.Length);
    }

    void Start()
    {
        maxEntities = entities.Length;
        turnID = 0;
        turnTransistionTimer = turnTransistionDuration;
        TurnOrder();
        FirstTurn(entities[0]);
    }

    private void FirstTurn(Entity firstActor)
    {
        firstActor.isTurn = true;
        string turnActor = firstActor.gameObject.name;
        turnText.text = "Actor: " + turnActor + "\nTurn: " + turnID;
    }

    private void SwapEntity(int firstIndex, int secondIndex)
    {
        Entity entity = entities[firstIndex];
        Entity otherEntity = entities[secondIndex];
        entities[secondIndex] = entity;
        entities[firstIndex] = otherEntity;
    }

    private int FindLeastAgileEntity(int leastAgileIndex)
    {
        Entity entity = entities[leastAgileIndex];

        for (int i = leastAgileIndex; i < entities.Length; i++)
        {
            entity = entity.CompareEntities(entities[i]);
        }

        return Array.IndexOf(entities, entity);
    }

    private void TurnOrder()
    {
        for (int i = 0; i < entities.Length - 1; i++)
        {
            int currentLeastAgileIndex = FindLeastAgileEntity(i);
            SwapEntity(i, currentLeastAgileIndex);
        }
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

    public void SetArray(Entity removedEntity)
    {
        Debug.Log(removedEntity.gameObject.name);
        int index = 0;

        for (int i = 0; i < entities.Length; i++)
        {
            if (entities[i].Equals(removedEntity))
            {
                if (entities[i].gameObject.name.Equals(removedEntity.gameObject.name))
                {
                    index = i;
                }
            }
        }

        Debug.Log(index);

        for (int i = index; i < entities.Length - 1; i++)
        {
            entities[i] = entities[i + 1];
        }

        Array.Resize(ref entities, entities.Length - 1);
        maxEntities--;
    }

    public void SetTurn()
    {
        turnTransistionBoolean = true;
        turnID++;
    }

    private void NextTurn()
    {
        entities[turnID % maxEntities].isTurn = true;
        turnText.text = "Actor: " + entities[turnID % maxEntities] + "\nTurn: " + turnID;
    }

    private void TurnTransistion()
    {
        foreach (Entity entity in entities)
        {
            entity.isTurn = false;
        }

        turnTransistionTimer -= Time.deltaTime;
    }
}
