    using Unity.VisualScripting;
    using UnityEngine;
    using TMPro;
    using UnityEngine.UI;
    //using System.Collections;

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
    
        public int leftPlayerScore=0;
        public int rightPlayerScore=0;

        public TMP_Text leftScoreText;
        public TMP_Text rightScoreText;
        public TMP_Text winText;


        private static object GetInstance()
        {
            return Instance;
        }
        public Button restartButton;
        public Button playButton;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            winText.gameObject.SetActive(false); // Hide win text initially
            restartButton.gameObject.SetActive(false);

        }
        public void RestartGame()
        {
            Time.timeScale = 1;
            leftPlayerScore = 0;
            rightPlayerScore = 0;
            leftScoreText.text = "0";
            rightScoreText.text = "0";

            winText.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(false );
            playButton.gameObject.SetActive(false);

            Ball.Instance.ResetBall();
        }
        public void AddScore(string player)
        {
            if(player == "Left")
            {
                leftPlayerScore++;
                Debug.Log("Left Player Score: " + leftPlayerScore);

                leftScoreText.text = leftPlayerScore.ToString();
                Debug.Log("Updated UI: Left = " + leftScoreText.text + ", Right = " + rightScoreText.text);
            winGame();

            }
            if (player == "Right")
            {
                rightPlayerScore++;
                Debug.Log("Right Player Score: " + rightPlayerScore);

                rightScoreText.text = rightPlayerScore.ToString();
                Debug.Log("Updated UI: Left = " + leftScoreText.text + ", Right = " + rightScoreText.text);
            winGame();

            }
        //if (leftPlayerScore >= 1 || rightPlayerScore >= 1)
        //{
        //    StartCoroutine(WinSequence());
        //}
    }
        public void winGame()
        {
            if (leftPlayerScore == 1)
            {

                Debug.Log("Left Player Wins");
                winText.text = "Left Player Wins!";
                
            }
            if (rightPlayerScore == 1)
            {
                Debug.Log("Right Player Wins");
                winText.text = "Right Player Wins!";

            }
        
        winScreen();
        

        }
    public void winScreen()
    {
        restartButton.gameObject.SetActive(true);
        winText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Start()
    {
        Time.timeScale = 0;
        leftPlayerScore = 0;
        rightPlayerScore = 0;
        leftScoreText.text = "0";
        rightScoreText.text = "0";

        winText.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);


    }
    public void Play()
    {
        Time.timeScale = 1;
        playButton.gameObject.SetActive(false);
        Ball.Instance.ResetBall();
    }

}
