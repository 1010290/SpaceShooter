using UnityEngine;

[System.Serializable]

public class GameData
{
    public int highScore;

    //default values game starts with when there's no data to load
    public GameData()
    {
        this.highScore = 0;
    }
}
