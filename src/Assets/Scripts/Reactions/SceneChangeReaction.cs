using AdventureJam.DataPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AdventureJam.Reactions
{
    public class SceneChangeReaction : Reaction
    {
        [SerializeField]
        private string _scene;
        [SerializeField]
        private SaveData _playerSaveData;

        public string SceneName { get { return _scene; } }
        public SaveData PlayerSaveData { get { return _playerSaveData; } }

        protected override void React()
        {
            _playerSaveData.Set("PlayerStartPos", "asdf");
        }
    }
}
