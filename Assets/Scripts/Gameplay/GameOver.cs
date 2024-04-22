using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private RawImage _gameOverImage;

    [SerializeField]
    private RawImage _barFGImage;

    [SerializeField]
    private RawImage _barBGImage;

    private static bool _playerHasLost = false;

    public bool Lost
    {
        get => _playerHasLost;
        set => Lost = value;
    }

    public void GameOverCall()
    {
        _gameOverImage.enabled = true;
        _barFGImage.enabled = false;
        _barBGImage.enabled = false;

        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (_playerHasLost)
            return;

        GameOverCall();
    }
}
