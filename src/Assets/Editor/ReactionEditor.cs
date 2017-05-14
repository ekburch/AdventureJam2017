using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace AdventureJam.Reactions
{
    public abstract class ReactionEditor : Editor
    {
        [SerializeField]
        private bool _showReaction;
        private SerializedProperty _reactionsProperty;
        private Reaction _reaction;

        private const float ButtonWidth = 30f;

        public static Reaction CreateReaction(Type reactionType)
        {
            return (Reaction)CreateInstance(reactionType);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUI.indentLevel++;

            EditorGUILayout.BeginHorizontal();

            _showReaction = EditorGUILayout.Foldout(_showReaction, GetFoldoutLabel());

            EditorGUILayout.EndHorizontal();

            if (_showReaction)
                DrawReaction();

            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }

        private void OnEnable()
        {
            _reaction = target as Reaction;

            Init();
        }

        protected virtual void Init() { }

        protected virtual void DrawReaction()
        {
            DrawDefaultInspector();
        }

        protected abstract string GetFoldoutLabel();
    }
}
