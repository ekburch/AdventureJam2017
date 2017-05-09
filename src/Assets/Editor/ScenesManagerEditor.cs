using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;
using UnityEditor;
using System;

[CustomEditor(typeof(ScenesManager), true)]
[CanEditMultipleObjects]
public class ScenesManagerEditor : Editor
{
    GUIContent m_mainMenuSceneLabel;

    protected bool m_initialized;
    protected ScenesManager m_sceneManager;

    public override void OnInspectorGUI()
    {
        Init();

        serializedObject.Update();

        serializedObject.ApplyModifiedProperties();
    }

    private void Init()
    {
        if (m_initialized)
            return;

        m_initialized = true;
        m_sceneManager = target as ScenesManager;

        m_mainMenuSceneLabel = new GUIContent("Main Menu Scene", "The scene loaded when the game first start and at game over.");
    }

    protected void ShowScenes()
    {
        var mainMenuObj = GetSceneObject(m_sceneManager.MainMenuScene);
    }

    protected SceneAsset GetSceneObject(string sceneObjectName)
    {
        if (String.IsNullOrEmpty(sceneObjectName))
            return null;

        foreach( var editorScene in EditorBuildSettings.scenes)
        {
            if (editorScene.path.IndexOf(sceneObjectName) != -1)
                return AssetDatabase.LoadAssetAtPath(editorScene.path, typeof(SceneAsset)) as SceneAsset;
        }
    }
}
