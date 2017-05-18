using UnityEngine;

namespace AdventureJam.Reactions
{
    [CreateAssetMenu]
    public class AudioReaction : Reaction
    {
        [SerializeField] private AudioSource _audioSource;   // The audio source to play the clip
        [SerializeField] private AudioClip _audioClip;       // The AudioClip to be played.
        [SerializeField] private float _delay = 0f;

        protected override void React()
        {
            _audioSource.clip = _audioClip;
            _audioSource.PlayDelayed(_delay);
        }
    }
}
