using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager INS;
    [HideInInspector] public string difficultySelected;
    [HideInInspector] public string keyPlayerPrefs;

    [HideInInspector] public Difficulty DifficultyConfig;
    public GameObject panelDifficultyConfig;

    private Canvas canvas;

    private void Awake()
    {
        if (INS == null)
        {
            INS = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (INS != this)
        {
            Destroy(gameObject);
        }
    }

    public void ShowDifficultyConfig()
    {
        canvas = FindObjectOfType<Canvas>();
        Instantiate(panelDifficultyConfig, canvas.transform);
    }
}
