using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TextureChanger : MonoBehaviour
{
    // Start is called before the first frame update
    float secondBGp, thirdBG, fourthBG = 0; //Valor de interpolación entre mapas
    private SpriteRenderer textureBG;
    [SerializeField] float transitionStrenght = 1f;
    float time;

    [SerializeField] bool condicion1, condicion2, condicion3;

    void Start()
    {
        time = 0;

        textureBG = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (condicion1 == true)
        {
            ChangeFisrtEra();

            if (time > 1)
            {
                condicion1 = false;
                time = 0;
            }
        }

        if (condicion2 == true)
        {
            ChangeSecondEra();
            if (time > 1)
            {
                condicion2 = false;
                time = 0;
            }
        }

        if (condicion3 == true)
        {
            ChangeThirdEra();
            if (time > 1)
            {
                condicion3 = false;
                time = 0;
            }
        }

    }

    void ChangeFisrtEra()
    {
        time += Time.deltaTime * transitionStrenght;
        secondBGp = Mathf.Lerp(0, 1, time);
        Debug.Log(time);
        textureBG.material.SetFloat("_Condicional_1", secondBGp);
    }

    void ChangeSecondEra()
    {
        time += Time.deltaTime * transitionStrenght;
        thirdBG = Mathf.Lerp(0, 1, time);
        textureBG.material.SetFloat("_Condicional_2", thirdBG);
    }

    void ChangeThirdEra()
    {
        time += Time.deltaTime * transitionStrenght;
        fourthBG = Mathf.Lerp(0, 1, time);
        textureBG.material.SetFloat("_Condicional_3", fourthBG);
    }

    public void ChangeCondition1()
    {
        condicion1 = true;
    }

    public void ChangeCondition2()
    {
        condicion2 = true;
    }

    public void ChangeCondition3()
    {
        condicion3 = true;
    }
}