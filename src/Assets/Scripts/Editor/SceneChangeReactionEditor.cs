using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using AdventureJam.Reactions;
using System;
using UnityEngine.Networking;

[CustomEditor(typeof(SceneChangeReaction))]
public class SceneChangeReactionEditor : ReactionEditor
{
    GUIContent _sceneLabel;

    protected bool _initialized;

    protected override string GetFoldoutLabel()
    {
        return "Scene Change Reaction";
    }

    protected override void Init()
    {
        _reaction = target as SceneChangeReaction;

        _sceneLabel = new GUIContent("Scene Name", "The scene to load");
    }

    protected override void DrawReaction()
    {
        var sceneChangeReaction = _reaction as SceneChangeReaction;
        var reactionSceneObj = GetSceneObject(sceneChangeReaction.SceneName);
        var newScene = EditorGUILayout.ObjectField(_sceneLabel, reactionSceneObj, typeof(SceneAsset), false);
        if (newScene == null)
        {
            var prop = serializedObject.FindProperty("_scene");
            prop.stringValue = "";
            EditorUtility.SetDirty(target);
        }
        else
        {
            if (newScene.name != sceneChangeReaction.SceneName)
            {
                var sceneObj = GetSceneObject(newScene.name);
                if (sceneObj == null)
                    Debug.LogWarning("The scene " + newScene.name + " cannot be used. To use this scene add it to the build settings for the project");
                else
                {
                    var prop = serializedObject.FindProperty("_scene");
                    prop.stringValue = newScene.name;
                    EditorUtility.SetDirty(target);
                }
            }
        }
    }

    private SceneAsset GetSceneObject(string sceneObjectName)
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
