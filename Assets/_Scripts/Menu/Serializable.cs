using System.Collections.Generic;

[System.Serializable]
public class ListDifficulty
{
    public List<Difficulty> difficulties = new List<Difficulty>();
}

[System.Serializable]
public class Difficulty
{
    public string name;

    public bool spawnCoins;
    public int minimumTimeBetweenSpawnswnsCoins;
    public int maximumTimeBetweenSpawnsCoins;
    public int minimumObjectsSpawnedCoins;
    public int maximumObjectsSpawnedCoins;

    public bool spawnBlueSphere;
    public int minimumTimeBetweenSpawnswnsBlueSphere;
    public int maximumTimeBetweenSpawnsBlueSphere;
    public int minimumObjectsSpawnedBlueSphere;
    public int maximumObjectsSpawnedBlueSphere;

    public bool spawnYellowBlock;
    public int minimumTimeBetweenSpawnswnsYellowBlock;
    public int maximumTimeBetweenSpawnsYellowBlock;
    public int minimumObjectsSpawnedYellowBlock;
    public int maximumObjectsSpawnedYellowBlock;

    public bool spawnRedBox;
    public int minimumTimeBetweenSpawnswnsRedBox;
    public int maximumTimeBetweenSpawnsRedBox;
    public int minimumObjectsSpawnedRedBox;
    public int maximumObjectsSpawnedRedBox;

    public bool spawnShield;
    public int minimumTimeBetweenSpawnswnsShield;
    public int maximumTimeBetweenSpawnsShield;
    public int minimumObjectsSpawnedShield;
    public int maximumObjectsSpawnedShield;

    public bool spawnTargetBrand;
    public int minimumTimeBetweenSpawnswnsTargetBrand;
    public int maximumTimeBetweenSpawnsTargetBrand;
    public int minimumObjectsSpawnedTargetBrand;
    public int maximumObjectsSpawnedTargetBrand;
}

