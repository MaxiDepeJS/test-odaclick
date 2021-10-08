using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button buttonEasy;
    public Button buttonMedium;
    public Button buttonHard;
    public Button buttonPlay;

    public Image imageButtonPlay;
    public Text txtButtonPlay;

    public Text txtHelp;

    private bool flagPlay = true;
    private void Start()
    {
        buttonPlay.interactable = false;
        buttonEasy.onClick.AddListener(SelectEasy);
        buttonMedium.onClick.AddListener(SelectMedium);
        buttonHard.onClick.AddListener(SelectHard);

        buttonPlay.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        if (flagPlay)
        {
            SceneManager.LoadScene("Game");
        }
    }

    private void SelectEasy()
    {
        SetColorTextButtonPlay("EASY", Color.green, "Play - Easy");
        if (PlayerPrefs.GetString("jsonEasy") == "")
        {
            flagPlay = false;
            txtHelp.gameObject.SetActive(true);
        }
        else
        {
            flagPlay = true;
            txtHelp.gameObject.SetActive(false);
        }
    }

    private void SelectMedium()
    {
        SetColorTextButtonPlay("MEDIUM", Color.cyan, "Play - Medium");
        if (PlayerPrefs.GetString("jsonMedium") == "")
        {
            flagPlay = false;
            txtHelp.gameObject.SetActive(true);
        }
        else
        {
            flagPlay = true;
            txtHelp.gameObject.SetActive(false);
        }
    }

    private void SelectHard()
    {
        SetColorTextButtonPlay("HARD", Color.red, "Play - Hard");
        if (PlayerPrefs.GetString("jsonHard") == "")
        {
            flagPlay = false;
            txtHelp.gameObject.SetActive(true);
        }
        else
        {
            flagPlay = true;
            txtHelp.gameObject.SetActive(false);
        }
    }

    public void SetColorTextButtonPlay(string difficulty, Color color, string text)
    {
        GameManager.INS.difficultySelected = difficulty;
        buttonPlay.interactable = true;
        imageButtonPlay.color = color;
        txtButtonPlay.text = text;
    }
}
