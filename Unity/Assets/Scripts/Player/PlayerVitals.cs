using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    public int MaxHealth { get => maxHealth; }

    [SerializeField] int level;
    public int Level { get => level; }

    [SerializeField] Age age;
    public Age Era { get => age; }

    [SerializeField] GameObject weapon;
    

    public bool isDead = false;
    private void Start()
    {
        health = maxHealth;
    }

    public void ReceiveDamage(int amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning($"Se intentó agregar el valor negativo de {amount} daño.");
            return;
        }
        health = Mathf.Clamp(health - amount, 0, maxHealth);
        if (health == 0)
        {
            isDead = true;
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                if (child.CompareTag("Weapon"))
                {
                    Destroy(child.gameObject);
                }
               
            }
        }
    }

    public void ReceiveHeal(int amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning($"Se intentó agregar el valor negativo de {amount} curación.");
            return;
        }
        health = Mathf.Clamp(health + amount, 0, maxHealth);
    }

    public void AddExperience(int amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning($"Se intentó agregar el valor negativo de {amount} experiencia.");
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

        // Operación de módulo ya que cada 10 niveles se cambia de era
        if (level%10 == 0)
        {
            AgeManager.age++; // Sorprendentemente, se puede realizar aritmetica a los enums lmao
            AgeManager.onAgeChange.Invoke();
            health = maxHealth;
        }
    }

   
}
