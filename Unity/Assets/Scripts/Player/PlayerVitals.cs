using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

    [SerializeField] GameObject getHitVfx;
    [SerializeField] ParticleSystem deathVfx;
    [SerializeField] ParticleSystem lvlUpVfx;
    
    //SFX
    [SerializeField] protected DamageSFX damageSfx;
    [SerializeField] protected DieSFX dieSfx;
    [SerializeField] protected GetEXP_SFX expSfx;
    [SerializeField] protected LevelUpSFX levelSfx;
    
    //Music 
    [SerializeField] protected MusicChanger music;

    [SerializeField] GameObject endgamestuff;


    public UnityEvent onDeath = new();
    public UnityEvent onLevelup = new();

    public bool isDead = false;
    private void Start()
    {
        health = maxHealth;
    }

    public void ReceiveDamage(int amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning($"Se intent� agregar el valor negativo de {amount} da�o.");
            return;
        }
        damageSfx.Hit();
        health = Mathf.Clamp(health - amount, 0, maxHealth);
        Destroy(Instantiate(getHitVfx, transform.position, Quaternion.identity), 0.6f);

        if (health == 0)
        {
            isDead = true;
            deathVfx.Play();
            dieSfx.Die();
            onDeath.Invoke();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                if (child.CompareTag("Weapon"))
                {
                    Destroy(child.gameObject);
                }
               
            }

            Invoke(nameof(BackToMainMenu), 3);
        }
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
        expSfx.Add();
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
        lvlUpVfx.Play();
        levelSfx.LevelUp();
        onLevelup.Invoke();

        if (level == 5)
        {
            endgamestuff.SetActive(true);

            isDead = true;
            deathVfx.Play();
            dieSfx.Die();
            onDeath.Invoke();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                if (child.CompareTag("Weapon"))
                {
                    Destroy(child.gameObject);
                }

            }

            Invoke(nameof(BackToMainMenu), 3);
        }
        else
        {
            AgeManager.age++; // Sorprendentemente, se puede realizar aritmética a los enums lmao
            AgeManager.onAgeChange.Invoke();
            health = maxHealth;

            RecalculateMaxExperienceForNextAge();
        }
    }

    void RecalculateMaxExperienceForNextAge()
    {
        switch (AgeManager.age) // todo: pasarse a un scriptableobject con los settings
        {
            case Age.Primitive:
                neededxpForNextLevel = 10;
                break;
            case Age.Ancient:
                neededxpForNextLevel = 25;
                break;
            case Age.Medieval:
                neededxpForNextLevel = 50;
                break;
            case Age.Modern:
                neededxpForNextLevel = 100;
                break;
        }
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
