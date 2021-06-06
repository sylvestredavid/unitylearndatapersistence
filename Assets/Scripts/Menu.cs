using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_Text bestScoreTxt;

    private void Start()
    {
        bestScoreTxt.text = $"Best Score : {GameManager.Instance.bestScore.name} : {GameManager.Instance.bestScore.score}";

    }

    public void StartGame()
    {
        if(GameManager.Instance.Name != "")
            SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ChangeName(TMP_InputField field)
    {
        Debug.Log(field.text);
        GameManager.Instance.Name = field.text;
    }
}