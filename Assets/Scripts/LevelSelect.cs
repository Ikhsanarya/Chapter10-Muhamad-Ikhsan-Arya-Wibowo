using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct LevelData
{
    public int levelNumber;
    public bool isCleared;
}

public class LevelSelect : MonoBehaviour
{
    private static LevelSelect _instance;

    public static LevelSelect Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LevelSelect>();
            }

            return _instance;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public List<LevelData> levelList = new List<LevelData>();

    public LevelData activeLevel;

    public void LoadLevel(int levelNumber)
    {
        activeLevel = levelList.Find(l => l.levelNumber == levelNumber);
        SceneManager.LoadScene(levelNumber);
    }

    public void UpdateLevel(bool isWin)
    {
        activeLevel.isCleared = isWin;
        
        for(int i = 0; i < levelList.Count; i++)
        {
            if (levelList[i].levelNumber == activeLevel.levelNumber)
            {
                levelList[i] = activeLevel;
            }
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}