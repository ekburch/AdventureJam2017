using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AdventureJam.Reactions
{
    public class ReactionCollection : MonoBehaviour
    {
        [SerializeField]
        private Reaction[] _reactions;

        public Reaction[] Reactions { get { return _reactions; } }

        private void Start()
        {
            foreach (var reaction in _reactions)
            {
                reaction.Initialize();
            }
        }

        public void React()
        {
            foreach (var reaction in _reactions)
            {
                reaction.React(this);
            }
        }
    }
}
