using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    [SerializeField] private Text playerNameText;
    public string playerNameString;
    public string topScorerNameString;
    public int topScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        playerNameString = playerNameText.text;
        LoadUserData();
        SceneManager.LoadScene(1);
    }

    [System.Serializable]
    class SaveData
    {
        public string topScorerNameString;
        public int topScore;
    }

    public void SaveUserData()
    {
        SaveData data = new SaveData();
        data.topScorerNameString = topScorerNameString;
        data.topScore = topScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadUserData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            topScore = data.topScore;
            topScorerNameString = data.topScorerNameString;
        }
    }

}
