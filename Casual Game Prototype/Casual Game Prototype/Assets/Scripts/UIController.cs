using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private UIElementController scoreUIController;
    [SerializeField] private UIElementController pauseUIController;
    [SerializeField] private UIElementController unpauseUIController;
    [SerializeField] private UIElementController startUIController;
    [SerializeField] private UIElementController retryUIController;
    [SerializeField] private Text scoreLabel;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_OVER, OnGameOver);
    }

    private void Start()
    {
        retryUIController.Hide();
        scoreUIController.Hide();
        pauseUIController.Hide();
        unpauseUIController.Hide();
    }

    private void Update()
    {
        scoreLabel.text = "Score: " + ScoreController.Score;
    }

    private void OnGameOver()
    {
        pauseUIController.Hide();
        retryUIController.Show();
    }

    private void OnGameRetry()
    {
        Messenger.Broadcast(GameEvent.GAME_RETRY);

        retryUIController.Hide();
        pauseUIController.Show();
    }

    private void OnGameStarted()
    {
        Messenger.Broadcast(GameEvent.GAME_STARTED);

        startUIController.Hide();
        scoreUIController.Show();
        pauseUIController.Show();
    }

    private void OnGamePaused()
    {
        Messenger.Broadcast(GameEvent.GAME_PAUSED);

        unpauseUIController.Show();
        pauseUIController.Hide();
    }

    private void OnGameUnpaused()
    {
        Messenger.Broadcast(GameEvent.GAME_UNPAUSED);

        unpauseUIController.Hide();
        pauseUIController.Show();
    }
}
