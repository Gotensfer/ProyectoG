using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManagerInGame : MonoBehaviour
{
    [SerializeField] Button ScreenButton;
    [SerializeField] CanvasGroup StartText;
    [SerializeField] CanvasGroup Choose1;
    [SerializeField] CanvasGroup Choose2;
    [SerializeField] CanvasGroup Choose3;

    [SerializeField] Image BannerMain;
    [SerializeField] Sprite Banner1;
    [SerializeField] Sprite Banner2;
    [SerializeField] Sprite Banner3;
    [SerializeField] Sprite Banner4;
    private void Start()
    {
        DOTween.Init();
        AgeManager.onAgeChange.AddListener(CheckAgeChange);
    }

    private void OnDisable() //Cierre de tweeners
    {
        DOTween.KillAll(gameObject);
    }


    public void ShowText(CanvasGroup Text)
    {
        StartText.alpha = 0;
        StartText.gameObject.SetActive(true);
        ScreenButton.gameObject.SetActive(true);
        Text.gameObject.SetActive(true);
        Text.gameObject.SetActive(true);

        Time.timeScale = 0;

        Text.DOFade(1, 1).SetUpdate(true).OnComplete(() => {
            StartText.DOFade(1, 0.7f)
            .SetEase(Ease.InQuart)
            .SetLoops(-1, LoopType.Yoyo)
            .SetUpdate(true);

            ScreenButton.onClick.AddListener(() => CloseText(Text));
        });
    }

    private void CloseText(CanvasGroup Text)
    {
        Text.DOFade(0, 1).OnComplete(() => Time.timeScale = 1).SetUpdate(true);
        StartText.DOKill();
        StartText.gameObject.SetActive(false);
        ScreenButton.gameObject.SetActive(false);
        Text.gameObject.SetActive(false);

    }

    public void OpenChoose1()
    {
        CanvasGroup Choose = Choose1;
        StartText.alpha = 0;
        StartText.gameObject.SetActive(true);
        Choose.gameObject.SetActive(true);
        Choose.gameObject.SetActive(true);

        Time.timeScale = 0;

        Choose.DOFade(1, 1).SetUpdate(true).OnComplete(() => {
            StartText.DOFade(1, 0.7f)
            .SetEase(Ease.InQuart)
            .SetLoops(-1, LoopType.Yoyo)
            .SetUpdate(true);
        });
    }    
    public void OpenChoose2()
    {
        CanvasGroup Choose = Choose2;
        StartText.alpha = 0;
        StartText.gameObject.SetActive(true);
        Choose.gameObject.SetActive(true);
        Choose.gameObject.SetActive(true);

        Time.timeScale = 0;

        Choose.DOFade(1, 1).SetUpdate(true).OnComplete(() => {
            StartText.DOFade(1, 0.7f)
            .SetEase(Ease.InQuart)
            .SetLoops(-1, LoopType.Yoyo)
            .SetUpdate(true);

        });
    }    
    public void OpenChoose3()
    {
        CanvasGroup Choose = Choose3;
        StartText.alpha = 0;
        StartText.gameObject.SetActive(true);
        Choose.gameObject.SetActive(true);
        Choose.gameObject.SetActive(true);

        Time.timeScale = 0;

        Choose.DOFade(1, 1).SetUpdate(true).OnComplete(() => {
            StartText.DOFade(1, 0.7f)
            .SetEase(Ease.InQuart)
            .SetLoops(-1, LoopType.Yoyo)
            .SetUpdate(true);

        });
    }

    private void CheckAgeChange()
    {
        switch (AgeManager.age)
        {
            case Age.Primitive:
                ChangeBannerImage(Banner1);
                break;
            case Age.Ancient:
                OpenChoose1();
                ChangeBannerImage(Banner2);
                break;
            case Age.Medieval:
                OpenChoose2();
                ChangeBannerImage(Banner3);
                break;
            case Age.Modern:
                OpenChoose3();
                ChangeBannerImage(Banner4);
                break;
        }
    }

    public void ChangeBannerImage(Sprite Sprite)
    {
        BannerMain.sprite = Sprite;
    }    

    public void Unpause()
    {
        Time.timeScale = 1;
    }

}
