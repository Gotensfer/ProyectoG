using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] RectTransform Buttons;
    [SerializeField] RectTransform Config;
    [SerializeField] CanvasGroup StartText;
    [SerializeField] Button ScreenButton;

    [SerializeField] RectTransform CreditsInfo;
    [SerializeField] CanvasGroup CreditsPanel;

    [SerializeField] RectTransform Logo;


    void Start()
    {
        Config.transform.localScale = Vector2.zero;

        ScreenButton.gameObject.SetActive(false);

        DOTween.Init();
        Welcome();
    }

    private void OnDisable() //Cierre de tweeners
    {
        DOTween.KillAll(gameObject);
    }

    public void Begin()
    {
        SceneManager.LoadScene(2);
    }

    private void Welcome()
    {
        StartText.alpha = 0;
        StartText.gameObject.SetActive(true);
        ScreenButton.gameObject.SetActive(true);
        Logo.gameObject.SetActive(true);
        
        Logo.DOAnchorPosY(-1650, 6).OnComplete(() => {
            StartText.DOFade(1, 0.6f)
            .SetEase(Ease.InQuart)
            .SetLoops(-1, LoopType.Yoyo)
            .SetUpdate(true);
            ScreenButton.onClick.AddListener(CloseWelcome);
        });        
    }

    private void CloseWelcome()
    {
        StartText.gameObject.SetActive(false);
        Buttons.gameObject.SetActive(true);
        StartText.DOKill();
        Buttons.DOAnchorPos(new Vector2(0, -300), 1);

        ScreenButton.onClick.RemoveListener(CloseWelcome);
        ScreenButton.gameObject.SetActive(false);
    }

    //Config Button
    public void ConfigUIButton()
    {
        Config.gameObject.SetActive(true);
        Config.DOScale(Vector3.one, 0.8f).SetEase(Ease.OutExpo);

    }
    public void BackFromConfigUIButton()
    {
        Config.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack).OnComplete(() => Config.gameObject.SetActive(false));
    }


    #region "Creditos"

    public void OpenCredits()
    {
        CreditsInfo.gameObject.GetComponent<CanvasGroup>().DOFade(1, 0);
        ScreenButton.gameObject.SetActive(true);
        CreditsInfo.gameObject.SetActive(true);

        CreditsPanel.gameObject.SetActive(true);
        CreditsPanel.DOFade(1, 1).OnComplete(() => {
            ScreenButton.onClick.AddListener(CloseCredits);
            CreditsInfo.DOAnchorPosY(3700, 15).OnComplete(EndCredits);
        });
    }

    public void CloseCredits()
    {
        CreditsInfo.DOKill();
        CreditsPanel.DOFade(0, 1).SetEase(Ease.InOutBack).OnComplete(() => CreditsPanel.gameObject.SetActive(false));
        CreditsInfo.gameObject.GetComponent<CanvasGroup>().DOFade(0, 1).SetEase(Ease.InOutBack).OnComplete(() => {
            CreditsInfo.gameObject.SetActive(false);
            CreditsInfo.DOAnchorPosY(-2200, 0);
        });

        ScreenButton.gameObject.SetActive(false);
        ScreenButton.onClick.RemoveAllListeners();
    }

    public void EndCredits()
    {
        CreditsInfo.gameObject.GetComponent<CanvasGroup>().DOFade(0, 1).SetDelay(3).SetEase(Ease.InOutBack).OnComplete(() => {
            CreditsInfo.gameObject.SetActive(false);
        });
        CreditsPanel.DOFade(0, 1).SetDelay(3).SetEase(Ease.InOutBack).OnComplete(() =>
        {

            CreditsPanel.gameObject.SetActive(false);
            ScreenButton.gameObject.SetActive(false);
            ScreenButton.onClick.RemoveAllListeners();
            CreditsInfo.DOAnchorPosY(-2200, 0);
        });
    }

    #endregion

}
