using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;
using UnityEditor;
using System;
using UnityEngine.Networking;

[CustomEditor(typeof(ScenesManager), true)]
[CanEditMultipleObjects]
public class ScenesManagerEditor : Editor
{
    GUIContent m_mainMenuSceneLabel;
    GUIContent m_citySceneLabel;
    GUIContent m_aptSceneLabel;

    protected bool m_initialized;
    protected ScenesManager m_sceneManager;

    public override void OnInspectorGUI()
    {
        Init();

        serializedObject.Update();

        ShowScenes();
        serializedObject.ApplyModifiedProperties();
    }

    private void Init()
    {
        if (m_initialized)
            return;

        m_initialized = true;
        m_sceneManager = target as ScenesManager;

        m_mainMenuSceneLabel = new GUIContent("Main Menu Scene", "The scene loaded when the game first start and at game over.");
        m_citySceneLabel = new GUIContent("City Scene", "The scene when the player is walking towards the friend's house.");
        m_aptSceneLabel = new GUIContent("Apartment Scene", "The main scene where player visits the friend's house.");
    }

    protected void ShowScenes()
    {
        // Main menu
        var mainMenuObj = GetSceneObject(m_sceneManager.MainMenuScene);
        var newMainMenuScene = EditorGUILayout.ObjectField(m_mainMenuSceneLabel, mainMenuObj, typeof(SceneAsset), false);
        if (newMainMenuScene == null)
        {
            var prop = serializedObject.FindProperty("m_mainMenuScene");
            prop.stringValue = "";
            EditorUtility.SetDirty(target);
        }
        else
        {
            if (newMainMenuScene.name != m_sceneManager.MainMenuScene)
            {
                var sceneObj = GetSceneObject(newMainMenuScene.name);
                if (sceneObj == null)
                    Debug.LogWarning("The scene " + newMainMenuScene.name + " cannot be used. To use this scene add it to the build settings for the project");
                else
                {
                    var prop = serializedObject.FindProperty("m_mainMenuScene");
                    prop.stringValue = newMainMenuScene.name;
                    EditorUtility.SetDirty(target);
                }
            }
        }

        // City
        var citySceneObj = GetSceneObject(m_sceneManager.CityScene);
        var newCityScene = EditorGUILayout.ObjectField(m_citySceneLabel, citySceneObj, typeof(SceneAsset), false);
        if (newCityScene == null)
        {
            var prop = serializedObject.FindProperty("m_cityScene");
            prop.stringValue = "";
            EditorUtility.SetDirty(target);
        }
        else
        {
            if (newCityScene.name != m_sceneManager.CityScene)
            {
                var sceneObj = GetSceneObject(newCityScene.name);
                if (sceneObj == null)
                    Debug.LogWarning("The scene " + newCityScene.name + " cannot be used. To use this scene add it to the build settings for the project");
                else
                {
                    var prop = serializedObject.FindProperty("m_cityScene");
                    prop.stringValue = newCityScene.name;
                    EditorUtility.SetDirty(target);
                }
            }
        }

        // Apartment
        var aptSceneObj = GetSceneObject(m_sceneManager.ApartmentScene);
        var newAptScene = EditorGUILayout.ObjectField(m_aptSceneLabel, aptSceneObj, typeof(SceneAsset), false);
        if (newAptScene == null)
        {
            var prop = serializedObject.FindProperty("m_apartmentScene");
            prop.stringValue = "";
            EditorUtility.SetDirty(target);
        }
        else
        {
            if (newAptScene.name != m_sceneManager.ApartmentScene)
            {
                var sceneObj = GetSceneObject(newAptScene.name);
                if (sceneObj == null)
                    Debug.LogWarning("The scene " + newAptScene.name + " cannot be used. To use this scene add it to the build settings for the project");
                else
                {
                    var prop = serializedObject.FindProperty("m_apartmentScene");
                    prop.stringValue = newAptScene.name;
                    EditorUtility.SetDirty(target);
                }
            }
        }
    }

    protected SceneAsset GetSceneObject(string sceneObjectName)
    {
        if (String.IsNullOrEmpty(sceneObjectName))
            return null;

        foreach (var editorScene in EditorBuildSettings.scenes)
        {
            if (editorScene.path.IndexOf(sceneObjectName) != -1)
                return AssetDatabase.LoadAssetAtPath(editorScene.path, typeof(SceneAsset)) as SceneAsset;

        }

        if (LogFilter.logWarn)
            Debug.LogWarning("Scene [" + sceneObjectName + "] cannot be used. Add this scene to the 'Scenes in the Build' in build settings.");
        return null;
    }
}
