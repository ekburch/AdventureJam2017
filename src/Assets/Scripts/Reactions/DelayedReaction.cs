using System.Collections;
using UnityEngine;

namespace AdventureJam.Reactions
{
    public abstract class DelayedReaction : Reaction
    {
        [SerializeField]
        private float _delay;
        public float Delay { get { return _delay; } }

        protected WaitForSeconds _wait;

        public override void Initialize()
        {
            _wait = new WaitForSeconds(Delay);

            base.Initialize();
        }

        public override void React(MonoBehaviour behaviour)
        {
            behaviour.StartCoroutine(ReactCoroutine());
        }

        protected IEnumerator ReactCoroutine()
        {
            yield return _wait;

            React();
        }
    }
}
