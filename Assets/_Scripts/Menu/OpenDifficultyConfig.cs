using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDifficultyConfig : MonoBehaviour
{
    public string difficulty;

    private Button btnDifficulty;

    private void Start()
    {
        btnDifficulty = this.gameObject.GetComponent<Button>();

        btnDifficulty.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        GameManager.INS.difficultySelected = difficulty;
        GameManager.INS.ShowDifficultyConfig();
    }
}
