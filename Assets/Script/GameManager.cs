using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;

    public static GameManager Instance;

    public bool isballMovementStarted = false;
    public bool isGameOver = false;

    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(ScoreIncreaseCoRoutine()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private IEnumerator ScoreIncreaseCoRoutine()
    //{
    //   while(!isGameOver)
    //    {
    //        yield return new WaitForSeconds(1);
    //        Increasescore(1);
    //    }
    //}
    public void Increasescore()
    {
        score = score + 5;
        scoreText.text = score.ToString();  
    }

    public void ChangeScene() 
    {
        SceneManager.LoadScene("GameScene"); 
    }
    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);   
    }
}
