using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] RectTransform Buttons;
    [SerializeField] CanvasGroup StartText;
    [SerializeField] Button screenButton;

    void Start()
    {
        DOTween.Init();
        Welcome();
    }

    private void OnDisable() //Cierre de tweeners
    {
        DOTween.KillAll(gameObject);
    }

    private void Welcome()
    {
        StartText.alpha = 0;
        StartText.gameObject.SetActive(true);
        screenButton.gameObject.SetActive(true);

        StartText.DOFade(1, 0.6f)
            .SetEase(Ease.InQuart)
            .SetLoops(-1, LoopType.Yoyo)
            .SetUpdate(true);

        screenButton.onClick.AddListener(CloseWelcome);
    }

    private void CloseWelcome()
    {
        StartText.gameObject.SetActive(false);
        Buttons.gameObject.SetActive(true);
        StartText.DOKill();

        Buttons.DOAnchorPos(new Vector2(0, 0), 1);

        screenButton.onClick.RemoveListener(CloseWelcome);
    }
}
