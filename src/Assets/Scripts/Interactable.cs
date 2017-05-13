using AdventureJam.Reactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureJam
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField]
        protected ReactionCollection _reactionCollection;
        protected Transform _transform;

        public Transform Location { get { return _transform; } }
        public ReactionCollection Reactions { get { return _reactionCollection; } }

        private void Start()
        {
            _transform = transform;
            _reactionCollection = GetComponent<ReactionCollection>();
        }

        public void Interact()
        {
            Reactions.React();
        }
    }
}
