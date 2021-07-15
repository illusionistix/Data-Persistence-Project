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
        //Debug.Log(playerNameString);
        SceneManager.LoadScene(1);
    }

}
