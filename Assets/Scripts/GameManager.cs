using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverGO;
    public GameObject scoreUITextGo;
    public GameObject TimeCounterGo;
    public enum GameManagerState
    {
        Opening,
        GamePlay,
        GameOver,
    }
    GameManagerState GMState;
    // Use this for initialization
    void Start()
    {
        GMState = GameManagerState.Opening;
    }
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                GameOverGO.SetActive(false);
                playButton.SetActive(true);
                //playerShip.GetComponent<PlayerControl>().Init();
                //playerShip.SetActive(false);
                break;
            case GameManagerState.GamePlay:
                scoreUITextGo.GetComponent<GameScore>().Score = 0;
                playButton.SetActive(false);
                playerShip.GetComponent<PlayerControl>().Init();
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
                TimeCounterGo.GetComponent<TimeCounter>().StartTimeCounter();
                break;
            case GameManagerState.GameOver:
                TimeCounterGo.GetComponent<TimeCounter>().StopTimeCounter();
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();
                GameOverGO.SetActive(true);
                Invoke("ChangeToOpeningState", 8f);
                break;
        }
    }
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }
    public void StartGamePlay()
    {
        GMState = GameManagerState.GamePlay;
        UpdateGameManagerState();
    }
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
