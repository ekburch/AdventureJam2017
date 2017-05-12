using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] string m_mainMenuScene;
    [SerializeField] string m_cityScene;
    [SerializeField] string m_apartmentScene;

    public string MainMenuScene { get { return m_mainMenuScene; } set { m_mainMenuScene = value; } }
    public string CityScene { get { return m_cityScene; } set { m_cityScene = value; } }
    public string ApartmentScene { get { return m_apartmentScene; } set { m_apartmentScene = value; } }

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this);

        SceneManager.LoadScene(MainMenuScene, LoadSceneMode.Additive);
    }

    public void GoToCityScene()
    {
        SceneManager.UnloadSceneAsync(MainMenuScene);
        SceneManager.LoadScene(CityScene, LoadSceneMode.Additive);
    }
}
