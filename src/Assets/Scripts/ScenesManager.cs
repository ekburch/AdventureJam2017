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

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
