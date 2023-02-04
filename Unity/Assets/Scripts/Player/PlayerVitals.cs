using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVitals : MonoBehaviour
{
    [SerializeField] int experience;
    public int Experience { get => experience; }

    [SerializeField] int neededxpForNextLevel = 10;
    public int NeededxpForNextLevel { get => neededxpForNextLevel; }

    [SerializeField] int health;
    public int Health { get => health; }

    [SerializeField] int maxHealth;
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    [SerializeField] int level;
    public int Level { get => level; }

    public void ReceiveDamage(int amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning($"Se intent� agregar el valor negativo de {amount} da�o.");
            return;
        }
        health = Mathf.Clamp(health - amount, 0, maxHealth);
    }

    public void ReceiveHeal(int amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning($"Se intent� agregar el valor negativo de {amount} curaci�n.");
            return;
        }
        health = Mathf.Clamp(health + amount, 0, maxHealth);
    }

    public void AddExperience(int amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning($"Se intent� agregar el valor negativo de {amount} experiencia.");
            return;
        }
        
        experience = Mathf.Clamp(experience + amount, 0, neededxpForNextLevel);

        if (experience == neededxpForNextLevel)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        level++;
        experience = 0;
    }
}
