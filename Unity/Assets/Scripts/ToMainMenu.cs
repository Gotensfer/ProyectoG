using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(ChangeScene), 3.2f);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }
}
