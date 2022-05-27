using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public ScoutBandit scoutBandit;
    public BrawlerBandit brawlerBandit;
    public TileTrigger[] tileTriggers;
    public ParticleSystem[] movementParticleSystems;

    private Color activeColor = Color.blue;
    private Color scoutColor = Color.gray;
    private Color brawlerColor = Color.red;

    private void Start()
    {
        tileTriggers = GetComponentsInChildren<TileTrigger>();
        movementParticleSystems = GetComponentsInChildren<ParticleSystem>();
    }

    private void Update()
    {
        for (int i = 0; i < tileTriggers.Length; i++)
        {
            if (tileTriggers[i].isActive)
            {
                TileActive(i);
            }
            else
            {
                TileUnactive(i);
            }

            if (scoutBandit.isTurn)
            {
                ScoutMovementParticleColor();
            }
            else if (brawlerBandit.isTurn)
            {
                BrawlerMovementParticleColor();
            }
        }
    }

    private void ScoutMovementParticleColor()
    {
        foreach (ParticleSystem particleSystem in movementParticleSystems)
        {
            ParticleSystem.MainModule settings = particleSystem.GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(scoutColor);
        }
    }

    private void BrawlerMovementParticleColor()
    {
        foreach (ParticleSystem particleSystem in movementParticleSystems)
        {
            ParticleSystem.MainModule settings = particleSystem.GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(brawlerColor);
        }
    }

    private void TileActive(int index)
    {
        tileTriggers[index].GetComponent<SpriteRenderer>().color = activeColor;
    }

    private void TileUnactive(int index)
    {
        tileTriggers[index].GetComponent<SpriteRenderer>().color = new Color32(150, 75, 0, 255);
    }
}
