using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class ExperienceCollectible : MonoBehaviour
{
    [SerializeField] Sprite[] xpSprite;

    private void Awake()
    {
        SetSpriteByEra();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerVitals>().AddExperience(1);
            Destroy(transform.parent.gameObject);
        }
    }

    void SetSpriteByEra()
    {
        print((int)AgeManager.age);
        GetComponent<SpriteRenderer>().sprite = xpSprite[(int)AgeManager.age];
    }
}
