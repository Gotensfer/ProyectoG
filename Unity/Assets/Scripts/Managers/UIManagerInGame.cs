using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManagerInGame : MonoBehaviour
{
    [SerializeField] Button ScreenButton;
    [SerializeField] CanvasGroup StartText;
    private void Start()
    {
        DOTween.Init();
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
        Text.DOFade(1, 1).OnComplete(() => {
            StartText.DOFade(1, 0.7f)
            .SetEase(Ease.InQuart)
            .SetLoops(-1, LoopType.Yoyo)
            .SetUpdate(true);

            ScreenButton.onClick.AddListener(() => CloseText(Text));
        });
    }

    private void CloseText(CanvasGroup Text)
    {
        Text.DOFade(0, 1);
        StartText.DOKill();
        StartText.gameObject.SetActive(false);
        ScreenButton.gameObject.SetActive(false);

    }
}
