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

    [SerializeField] CanvasGroup Tuto1;
    [SerializeField] CanvasGroup Tuto2;
    [SerializeField] CanvasGroup Tuto3;
    [SerializeField] CanvasGroup TutoBanner;

    private void Start()
    {
        DOTween.Init();
        AgeManager.onAgeChange.AddListener(CheckAgeChange);

        Tutorial();
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

        Time.timeScale = 0;
    }
    public void OpenChoose2()
    {
        CanvasGroup Choose = Choose2;
        StartText.alpha = 0;
        StartText.gameObject.SetActive(true);
        Choose.gameObject.SetActive(true);

        Time.timeScale = 0;
    }
    public void OpenChoose3()
    {
        CanvasGroup Choose = Choose3;
        StartText.alpha = 0;
        StartText.gameObject.SetActive(true);
        Choose.gameObject.SetActive(true);

        Time.timeScale = 0;
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


    #region "Tutorial"
    private void Tutorial()
    {
        StartText.alpha = 0;
        StartText.gameObject.SetActive(true);
        ScreenButton.gameObject.SetActive(true);
        TutoBanner.gameObject.SetActive(true);
        Tuto1.gameObject.SetActive(true);

        Time.timeScale = 0;
        ScreenButton.onClick.AddListener(CloseTutorial);

        TutoBanner.DOFade(1, 1).SetUpdate(true);
        Tuto1.DOFade(1, 3).SetUpdate(true).OnComplete(() => {
            StartText.DOFade(1, 0.7f)
            .SetEase(Ease.InQuart)
            .SetLoops(-1, LoopType.Yoyo)
            .SetUpdate(true);
            Tutorial2();
        }).SetDelay(2);
    }
    private void Tutorial2()
    {
        Tuto2.gameObject.SetActive(true);

        Tuto1.DOFade(0, 1).SetUpdate(true).OnComplete(() => Tuto1.gameObject.SetActive(false));

        Tuto2.DOFade(1, 3).SetUpdate(true).OnComplete(() => Tutorial3());


    }
    private void Tutorial3()
    {
        Tuto3.gameObject.SetActive(true);

        Tuto2.DOFade(0, 1).SetUpdate(true).OnComplete(() => Tuto1.gameObject.SetActive(false));

        Tuto3.DOFade(1, 3).SetUpdate(true).OnComplete(() => {

            Tuto3.DOFade(0, 1).SetUpdate(true);
            TutoBanner.DOFade(0, 1).SetUpdate(true);
            Time.timeScale = 1;
        });
    }

    public void CloseTutorial()
    {
        TutoBanner.DOKill();
        Tuto1.DOKill();
        Tuto2.DOKill();
        Tuto3.DOKill();
        StartText.DOKill();

        TutoBanner.DOFade(0, 1).SetUpdate(true).OnComplete(() => TutoBanner.gameObject.SetActive(false));
        Tuto1.DOFade(0, 1).SetUpdate(true).OnComplete(() => Tuto1.gameObject.SetActive(false));
        Tuto2.DOFade(0, 1).SetUpdate(true).OnComplete(() => Tuto2.gameObject.SetActive(false));
        Tuto3.DOFade(0, 1).SetUpdate(true).OnComplete(() => Tuto3.gameObject.SetActive(false));

        StartText.gameObject.SetActive(false);
        ScreenButton.gameObject.SetActive(false);



        Time.timeScale = 1;
    }

    #endregion
}
