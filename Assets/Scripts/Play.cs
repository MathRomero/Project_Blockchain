using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Object game;

    void Start() => playButton.onClick.AddListener(PlayGame);

    private void PlayGame() => SceneManager.LoadScene(game.name);
}
