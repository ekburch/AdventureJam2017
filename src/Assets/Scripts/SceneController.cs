using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
using AdventureJam.Reactions;
using System;

public class SceneController : MonoBehaviour
{
    #region Singleton
    private static SceneController _instance = null;
    public static SceneController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SceneController>();

                if (_instance == null)
                {
                    var newScenesManager = new GameObject("Scene Controller");
                    _instance = newScenesManager.AddComponent<SceneController>();
                }
            }

            return _instance;
        }
    }
    #endregion

    [SerializeField]
    private SceneChangeReaction _startingScene;

    private bool _isFading;
    [SerializeField]
    private float _fadeDuration = 1f;           // How long it should take to fade out and in from black.
    public CanvasGroup _fadeCanvasGroup;        // The CanvasGroup that controls the Image used for fading

    // Use this for initialization
    private void Start()
    {
        // Set the initial alpha to start off with a black screen.
        _fadeCanvasGroup.alpha = 1f;

        // Start the first scene loading and wait for it to finish
        if (_startingScene != null)
        {
            _startingScene.Initialize();
            _startingScene.React(this);
        }
    }

    public void LoadScene(SceneChangeReaction sceneChange)
    {
        if (!_isFading)
        {
            StartCoroutine(FadeAndSwitchScenes(sceneChange));
        }
    }

    private IEnumerator LoadSceneAndSetActive(SceneChangeReaction sceneChange)
    {
        yield return SceneManager.LoadSceneAsync(sceneChange.SceneName, LoadSceneMode.Additive);

        var newlyLoadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);

        SceneManager.SetActiveScene(newlyLoadedScene);
    }

    private IEnumerator FadeAndSwitchScenes(SceneChangeReaction sceneChange)
    {
        yield return StartCoroutine(FadeOut(1f));

        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        yield return StartCoroutine(LoadSceneAndSetActive(sceneChange));

        yield return StartCoroutine(FadeOut(0f));
    }

    private IEnumerator FadeOut(float fadeToAlpha)
    {
        _isFading = true;

        _fadeCanvasGroup.blocksRaycasts = true;

        var fadeSpeed = Mathf.Abs(_fadeCanvasGroup.alpha - fadeToAlpha) / _fadeDuration;

        while (!Mathf.Approximately(_fadeCanvasGroup.alpha, fadeToAlpha))
        {
            _fadeCanvasGroup.alpha = Mathf.MoveTowards(_fadeCanvasGroup.alpha, fadeToAlpha, fadeSpeed * Time.deltaTime);

            yield return null;
        }

        _isFading = false;

        _fadeCanvasGroup.blocksRaycasts = false;
    }
}
