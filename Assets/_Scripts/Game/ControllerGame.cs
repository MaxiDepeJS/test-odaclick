using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerGame : MonoBehaviour
{
    [HideInInspector] public static ControllerGame INS;
    [HideInInspector] public int points;

    public Text txtPoints;
    public Text txtGameOver;

    public ObjectGame coin;
    public ObjectGame blueSphere;
    public ObjectGame yellowBlock;
    public ObjectGame redBox;
    public ObjectGame shield;
    public ObjectGame targetBrand;

    public Button btnMenu;
    private Canvas canvas;
    private Difficulty difficultySettings;

    private void Awake()
    {
        if (INS == null)
        {
            INS = this;
        }
    }

    private void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        points = 0;

        GetPlayerPrefs();
        btnMenu.onClick.AddListener(GoToMenu);
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void GetPlayerPrefs()
    {
        if (GameManager.INS.difficultySelected == "EASY")
            difficultySettings = JsonUtility.FromJson<Difficulty>(PlayerPrefs.GetString("jsonEasy"));
        else if (GameManager.INS.difficultySelected == "MEDIUM")
            difficultySettings = JsonUtility.FromJson<Difficulty>(PlayerPrefs.GetString("jsonMedium"));
        else
            difficultySettings = JsonUtility.FromJson<Difficulty>(PlayerPrefs.GetString("jsonHard"));

        if (difficultySettings.spawnCoins)
            Invoke("InstantiateCoin", difficultySettings.minimumTimeBetweenSpawnswnsCoins);

        if (difficultySettings.spawnYellowBlock)
            Invoke("InstantiateYellowBlock", difficultySettings.minimumTimeBetweenSpawnswnsYellowBlock);

        if (difficultySettings.spawnBlueSphere)
            Invoke("InstantiateBlueSphere", difficultySettings.minimumTimeBetweenSpawnswnsBlueSphere);

        if (difficultySettings.spawnRedBox)
            Invoke("InstantiateRedBox", difficultySettings.minimumTimeBetweenSpawnswnsRedBox);

        if (difficultySettings.spawnShield)
            Invoke("InstantiateShield", difficultySettings.minimumTimeBetweenSpawnswnsShield);

        if (difficultySettings.spawnTargetBrand)
            Invoke("InstantiateTargetBrand", difficultySettings.minimumTimeBetweenSpawnswnsTargetBrand);
    }

    private void InstantiateCoin()
    {
        int count = GetRandomAmountSpawn(difficultySettings.minimumObjectsSpawnedCoins, difficultySettings.maximumObjectsSpawnedCoins);

        for (int i = 0; i < count; i++)
        {
            ObjectGame objectGame = Instantiate(coin, canvas.transform);
            objectGame.transform.localPosition = GetRandomPosition();

            Invoke("InstantiateCoin",
                GetRandomTimeSpawn(difficultySettings.minimumTimeBetweenSpawnswnsCoins,
                difficultySettings.maximumTimeBetweenSpawnsCoins));
        }
    }

    private void InstantiateYellowBlock()
    {
        int count = GetRandomAmountSpawn(difficultySettings.minimumObjectsSpawnedYellowBlock, difficultySettings.maximumObjectsSpawnedYellowBlock);

        for (int i = 0; i < count; i++)
        {
            ObjectGame objectGame = Instantiate(yellowBlock, canvas.transform);
            objectGame.transform.localPosition = GetRandomPosition();

            Invoke("InstantiateYellowBlock",
                GetRandomTimeSpawn(difficultySettings.minimumTimeBetweenSpawnswnsYellowBlock,
                difficultySettings.maximumTimeBetweenSpawnsYellowBlock));
        }
    }

    private void InstantiateBlueSphere()
    {
        int count = GetRandomAmountSpawn(difficultySettings.minimumObjectsSpawnedBlueSphere,
                                            difficultySettings.maximumObjectsSpawnedBlueSphere);

        for (int i = 0; i < count; i++)
        {
            ObjectGame objectGame = Instantiate(blueSphere, canvas.transform);
            objectGame.transform.localPosition = GetRandomPosition();

            Invoke("InstantiateBlueSphere",
                GetRandomTimeSpawn(difficultySettings.minimumTimeBetweenSpawnswnsBlueSphere,
                difficultySettings.maximumTimeBetweenSpawnsBlueSphere));
        }
    }

    private void InstantiateRedBox()
    {
        int count = GetRandomAmountSpawn(difficultySettings.minimumObjectsSpawnedRedBox,
                                            difficultySettings.maximumObjectsSpawnedRedBox);

        for (int i = 0; i < count; i++)
        {
            ObjectGame objectGame = Instantiate(redBox, canvas.transform);
            objectGame.transform.localPosition = GetRandomPosition();

            Invoke("InstantiateRedBox",
                GetRandomTimeSpawn(difficultySettings.minimumTimeBetweenSpawnswnsRedBox,
                difficultySettings.maximumTimeBetweenSpawnsRedBox));
        }
    }

    private void InstantiateShield()
    {
        int count = GetRandomAmountSpawn(difficultySettings.minimumObjectsSpawnedShield,
                                            difficultySettings.maximumObjectsSpawnedShield);

        for (int i = 0; i < count; i++)
        {
            ObjectGame objectGame = Instantiate(shield, canvas.transform);
            objectGame.transform.localPosition = GetRandomPosition();

            Invoke("InstantiateShield",
                GetRandomTimeSpawn(difficultySettings.minimumTimeBetweenSpawnswnsShield,
                difficultySettings.maximumTimeBetweenSpawnsShield));
        }
    }

    private void InstantiateTargetBrand()
    {
        int count = GetRandomAmountSpawn(difficultySettings.minimumObjectsSpawnedTargetBrand,
                                            difficultySettings.maximumObjectsSpawnedTargetBrand);

        for (int i = 0; i < count; i++)
        {
            ObjectGame objectGame = Instantiate(targetBrand, canvas.transform);
            objectGame.transform.localPosition = GetRandomPosition();

            Invoke("InstantiateTargetBrand",
                GetRandomTimeSpawn(difficultySettings.minimumTimeBetweenSpawnswnsTargetBrand,
                difficultySettings.maximumTimeBetweenSpawnsTargetBrand));
        }
    }


    public void AddPoints(int amount)
    {
        points += amount;
        txtPoints.text = "Points: " + points;

        if (points >= 100)
        {
            Win();
        }
    }

    private void Win()
    {
        FindObjectOfType<Timer>().GetComponent<Timer>().StopTimer();

        btnMenu.gameObject.SetActive(true);
        txtGameOver.gameObject.SetActive(true);
        txtGameOver.text = "YOU WIN THIS LEVEL!";
        CancelInvoke();
    }

    public void SubtractPoints(int amount)
    {
        points -= amount;
        txtPoints.text = "Points: " + points;
    }

    public void GameOver(string text)
    {
        FindObjectOfType<Timer>().GetComponent<Timer>().StopTimer();

        btnMenu.gameObject.SetActive(true);
        CancelInvoke();
        txtGameOver.gameObject.SetActive(true);
        txtGameOver.text = text;
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 position = new Vector3(UnityEngine.Random.Range(-351.0f, 351.0f), UnityEngine.Random.Range(-210.0f, 168.0f), 0);
        return position;
    }

    private float GetRandomTimeSpawn(float secMin, float secMax)
    {
        float sec = UnityEngine.Random.Range(secMin, secMax);
        return sec;
    }

    private int GetRandomAmountSpawn(int min, int max)
    {
        int amount = UnityEngine.Random.Range(min, max);
        return amount;
    }
}
