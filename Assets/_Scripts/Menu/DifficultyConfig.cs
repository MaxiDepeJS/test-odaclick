using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyConfig : MonoBehaviour
{
    public Text txtTittlePanel;
    public Button btnSave;
    public Button btnCancel;
    public Text txtError;

    private Difficulty difficultySettings;

    #region UI Data Config
    public Toggle toggleSpawnCoins;
    public InputField inputMinTimeCoins;
    public InputField inputMaxTimeCoins;
    public InputField inputMinObjectsCoins;
    public InputField inputMaxObjectsCoins;

    public Toggle toggleSpawnBlueSphere;
    public InputField inputMinTimeBlueSphere;
    public InputField inputMaxTimeBlueSphere;
    public InputField inputMinObjectsBlueSphere;
    public InputField inputMaxObjectsBlueSphere;

    public Toggle toggleSpawnYellowBlock;
    public InputField inputMinTimeYellowBlock;
    public InputField inputMaxTimeYellowBlock;
    public InputField inputMinObjectsYellowBlock;
    public InputField inputMaxObjectsYellowBlock;

    public Toggle toggleSpawnRedBox;
    public InputField inputMinTimeRedBox;
    public InputField inputMaxTimeRedBox;
    public InputField inputMinObjectsRedBox;
    public InputField inputMaxObjectsRedBox;

    public Toggle toggleSpawnShield;
    public InputField inputMinTimeShield;
    public InputField inputMaxTimeShield;
    public InputField inputMinObjectsShield;
    public InputField inputMaxObjectsShield;

    public Toggle toggleSpawnTargetBrand;
    public InputField inputMinTimeTargetBrand;
    public InputField inputMaxTimeTargetBrand;
    public InputField inputMinObjectsTargetBrand;
    public InputField inputMaxObjectsTargetBrand;
    #endregion

    private void Start()
    {
        txtTittlePanel.text = GameManager.INS.difficultySelected.ToUpper() + " - " + "Difficulty Setting";
        SetData();

        btnSave.onClick.AddListener(SaveConfig);
        btnCancel.onClick.AddListener(ClosePanel);
    }

    private void ClosePanel()
    {
        Destroy(this.gameObject);
    }

    private void SaveConfig()
    {
        if (!ValidateInputs())
        {
            //Debug.Log("There are fields with no data. Please review and try again. Thanks");
            return;
        }
        string keyPlayerPrefs;
        if (GameManager.INS.difficultySelected.ToUpper() == "EASY") keyPlayerPrefs = "jsonEasy";
        else if (GameManager.INS.difficultySelected.ToUpper() == "MEDIUM") keyPlayerPrefs = "jsonMedium";
        else keyPlayerPrefs = "jsonHard";

        GameManager.INS.keyPlayerPrefs = keyPlayerPrefs;

        Difficulty difficulty = new Difficulty();
        difficulty.spawnCoins = toggleSpawnCoins.isOn;
        difficulty.spawnBlueSphere = toggleSpawnBlueSphere.isOn;
        difficulty.spawnYellowBlock = toggleSpawnYellowBlock.isOn;
        difficulty.spawnRedBox = toggleSpawnRedBox.isOn;
        difficulty.spawnShield = toggleSpawnShield.isOn;
        difficulty.spawnTargetBrand = toggleSpawnTargetBrand.isOn;

        difficulty.minimumTimeBetweenSpawnswnsCoins = Int32.Parse(inputMinTimeCoins.text.Trim());
        difficulty.minimumTimeBetweenSpawnswnsBlueSphere = Int32.Parse(inputMinTimeBlueSphere.text.Trim());
        difficulty.minimumTimeBetweenSpawnswnsYellowBlock = Int32.Parse(inputMinTimeYellowBlock.text.Trim());
        difficulty.minimumTimeBetweenSpawnswnsRedBox = Int32.Parse(inputMinTimeRedBox.text.Trim());
        difficulty.minimumTimeBetweenSpawnswnsShield = Int32.Parse(inputMinTimeShield.text.Trim());
        difficulty.minimumTimeBetweenSpawnswnsTargetBrand = Int32.Parse(inputMinTimeTargetBrand.text.Trim());

        difficulty.maximumTimeBetweenSpawnsCoins = Int32.Parse(inputMaxTimeCoins.text.Trim());
        difficulty.maximumTimeBetweenSpawnsBlueSphere = Int32.Parse(inputMaxTimeBlueSphere.text.Trim());
        difficulty.maximumTimeBetweenSpawnsYellowBlock = Int32.Parse(inputMaxTimeYellowBlock.text.Trim());
        difficulty.maximumTimeBetweenSpawnsRedBox = Int32.Parse(inputMaxTimeRedBox.text.Trim());
        difficulty.maximumTimeBetweenSpawnsShield = Int32.Parse(inputMaxTimeShield.text.Trim());
        difficulty.maximumTimeBetweenSpawnsTargetBrand = Int32.Parse(inputMaxTimeTargetBrand.text.Trim());

        difficulty.minimumObjectsSpawnedCoins = Int32.Parse(inputMinObjectsCoins.text.Trim());
        difficulty.minimumObjectsSpawnedBlueSphere = Int32.Parse(inputMinObjectsBlueSphere.text.Trim());
        difficulty.minimumObjectsSpawnedYellowBlock = Int32.Parse(inputMinObjectsYellowBlock.text.Trim());
        difficulty.minimumObjectsSpawnedRedBox = Int32.Parse(inputMinObjectsRedBox.text.Trim());
        difficulty.minimumObjectsSpawnedShield = Int32.Parse(inputMinObjectsShield.text.Trim());
        difficulty.minimumObjectsSpawnedTargetBrand = Int32.Parse(inputMinObjectsTargetBrand.text.Trim());

        difficulty.maximumObjectsSpawnedCoins = Int32.Parse(inputMaxObjectsCoins.text.Trim());
        difficulty.maximumObjectsSpawnedBlueSphere = Int32.Parse(inputMaxObjectsBlueSphere.text.Trim());
        difficulty.maximumObjectsSpawnedYellowBlock = Int32.Parse(inputMaxObjectsYellowBlock.text.Trim());
        difficulty.maximumObjectsSpawnedRedBox = Int32.Parse(inputMaxObjectsRedBox.text.Trim());
        difficulty.maximumObjectsSpawnedShield = Int32.Parse(inputMaxObjectsShield.text.Trim());
        difficulty.maximumObjectsSpawnedTargetBrand = Int32.Parse(inputMaxObjectsTargetBrand.text.Trim());

        string json = JsonUtility.ToJson(difficulty);
        PlayerPrefs.SetString(keyPlayerPrefs, json);

        Destroy(this.gameObject);
    }

    private bool ValidateInputs()
    {
        if (inputMinTimeCoins.text.Trim() == "" ||
            inputMaxTimeCoins.text.Trim() == "" ||
            inputMinObjectsCoins.text.Trim() == "" ||
            inputMaxObjectsCoins.text.Trim() == "" ||

            inputMinTimeBlueSphere.text.Trim() == "" ||
            inputMaxTimeBlueSphere.text.Trim() == "" ||
            inputMinObjectsBlueSphere.text.Trim() == "" ||
            inputMaxObjectsBlueSphere.text.Trim() == "" ||

            inputMinTimeYellowBlock.text.Trim() == "" ||
            inputMaxTimeYellowBlock.text.Trim() == "" ||
            inputMinObjectsYellowBlock.text.Trim() == "" ||
            inputMaxObjectsYellowBlock.text.Trim() == "" ||

            inputMinTimeRedBox.text.Trim() == "" ||
            inputMaxTimeRedBox.text.Trim() == "" ||
            inputMinObjectsRedBox.text.Trim() == "" ||
            inputMaxObjectsRedBox.text.Trim() == "" ||

            inputMinTimeShield.text.Trim() == "" ||
            inputMaxTimeShield.text.Trim() == "" ||
            inputMinObjectsShield.text.Trim() == "" ||
            inputMaxObjectsShield.text.Trim() == "" ||

            inputMinTimeTargetBrand.text.Trim() == "" ||
            inputMaxTimeTargetBrand.text.Trim() == "" ||
            inputMinObjectsTargetBrand.text.Trim() == "" ||
            inputMaxObjectsTargetBrand.text.Trim() == ""
            )
        {
            txtError.gameObject.SetActive(true);
            txtError.text = "There are fields with no data. Please review and try again. Thanks";
            return false;
        }
        else
        {
            txtError.gameObject.SetActive(false);
            return true;
        }
    }

    private void SetData()
    {
        if (GameManager.INS.difficultySelected.ToUpper() == "EASY")
            difficultySettings = JsonUtility.FromJson<Difficulty>(PlayerPrefs.GetString("jsonEasy"));
        else if (GameManager.INS.difficultySelected.ToUpper() == "MEDIUM")
            difficultySettings = JsonUtility.FromJson<Difficulty>(PlayerPrefs.GetString("jsonMedium"));
        else
            difficultySettings = JsonUtility.FromJson<Difficulty>(PlayerPrefs.GetString("jsonHard"));


        if (difficultySettings == null) return;

        inputMinTimeCoins.text = difficultySettings.minimumTimeBetweenSpawnswnsCoins.ToString();
        inputMaxTimeCoins.text = difficultySettings.maximumTimeBetweenSpawnsCoins.ToString();
        inputMinObjectsCoins.text = difficultySettings.minimumObjectsSpawnedCoins.ToString();
        inputMaxObjectsCoins.text = difficultySettings.maximumObjectsSpawnedCoins.ToString();

        inputMinTimeBlueSphere.text = difficultySettings.minimumTimeBetweenSpawnswnsBlueSphere.ToString();
        inputMaxTimeBlueSphere.text = difficultySettings.maximumTimeBetweenSpawnsBlueSphere.ToString();
        inputMinObjectsBlueSphere.text = difficultySettings.minimumObjectsSpawnedBlueSphere.ToString();
        inputMaxObjectsBlueSphere.text = difficultySettings.minimumObjectsSpawnedCoins.ToString();

        inputMinTimeYellowBlock.text = difficultySettings.minimumTimeBetweenSpawnswnsYellowBlock.ToString();
        inputMaxTimeYellowBlock.text = difficultySettings.maximumTimeBetweenSpawnsYellowBlock.ToString();
        inputMinObjectsYellowBlock.text = difficultySettings.minimumObjectsSpawnedYellowBlock.ToString();
        inputMaxObjectsYellowBlock.text = difficultySettings.maximumObjectsSpawnedYellowBlock.ToString();

        inputMinTimeRedBox.text = difficultySettings.minimumTimeBetweenSpawnswnsRedBox.ToString();
        inputMaxTimeRedBox.text = difficultySettings.maximumTimeBetweenSpawnsRedBox.ToString();
        inputMinObjectsRedBox.text = difficultySettings.minimumObjectsSpawnedRedBox.ToString();
        inputMaxObjectsRedBox.text = difficultySettings.maximumObjectsSpawnedRedBox.ToString();

        inputMinTimeShield.text = difficultySettings.minimumTimeBetweenSpawnswnsShield.ToString();
        inputMaxTimeShield.text = difficultySettings.maximumTimeBetweenSpawnsShield.ToString();
        inputMinObjectsShield.text = difficultySettings.minimumObjectsSpawnedShield.ToString();
        inputMaxObjectsShield.text = difficultySettings.maximumObjectsSpawnedShield.ToString();

        inputMinTimeTargetBrand.text = difficultySettings.minimumTimeBetweenSpawnswnsTargetBrand.ToString();
        inputMaxTimeTargetBrand.text = difficultySettings.maximumTimeBetweenSpawnsTargetBrand.ToString();
        inputMinObjectsTargetBrand.text = difficultySettings.minimumObjectsSpawnedTargetBrand.ToString();
        inputMaxObjectsTargetBrand.text = difficultySettings.maximumObjectsSpawnedTargetBrand.ToString();
    }
}
