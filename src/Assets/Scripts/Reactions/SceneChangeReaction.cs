using AdventureJam.DataPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AdventureJam.Reactions
{
    [CreateAssetMenu]
    public class SceneChangeReaction : Reaction
    {
        [SerializeField]
        private string _scene;
        private SaveData _playerSaveData;
        private SceneController _sceneController;

        public string SceneName { get { return _scene; } }
        public SaveData PlayerSaveData { get { return _playerSaveData; } }

        public override void Initialize()
        {
            _sceneController = FindObjectOfType<SceneController>();
        }

        protected override void React()
        {
            // Save the StartingPosition's name to the data asset
            //_playerSaveData.Set("PlayerStartPos", "asdf");

            // Start the scene loading process.
            _sceneController.LoadScene(this);
        }
    }
}
