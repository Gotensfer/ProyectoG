using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LocalizacionImage : MonoBehaviour
{
    [SerializeField] private Sprite textSpanish, textEnglish;

    private Image text;
    private ChangeLanguage cl;

    private void Awake()
    {
        cl = GameObject.Find("ChangeLanguage").GetComponent<ChangeLanguage>();
        text = gameObject.GetComponent<Image>();
    }

    private void Start()
    {
        cl.ChangeEnglish.AddListener(ChangeToEnglish);
        cl.ChangeSpanish.AddListener(ChangeToSpanish);
    }

    private void OnEnable()
    {
        if (ChangeLanguage.Language == 1)
        {
            ChangeToSpanish();
        }        
        if (ChangeLanguage.Language == 0)
        {
            ChangeToEnglish();
        }
    }

    void ChangeToSpanish()
    {
        text.sprite = textSpanish;
    }
    
    void ChangeToEnglish()
    {
        text.sprite = textEnglish;
    }
}
