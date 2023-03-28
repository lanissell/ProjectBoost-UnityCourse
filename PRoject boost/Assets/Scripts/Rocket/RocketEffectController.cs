using Rocket.StateMachine.RocketStateMachine.States;
using UnityEngine;

namespace Rocket
{
    public class RocketEffectController : MonoBehaviour
    {
        [SerializeField] private AudioSource _trustAudioSource;
        [SerializeField] private ParticleSystem _trustEffect;
        [SerializeField] private AudioSource _rotateAudioSource;
    
        void Start()
        {
            RocketTrustState.OnTrust += PlayTrustEffect;
            RocketTrustState.OnTrustExit += PauseTrustEffect;
            RocketRotateIdleState.OnRotate += PlayRotateEffect;
            RocketRotateState.OnRotateExit += PauseRotateEffect;
        }

        private void PlayTrustEffect()
        {
            _trustAudioSource.Play();
            _trustEffect.Play();
        }
    
        private void PauseTrustEffect()
        {
            _trustAudioSource.Pause();
            _trustEffect.Stop();
        }
    
        private void PlayRotateEffect(float direction)
        {
            _rotateAudioSource.Play();
        }
    
        private void PauseRotateEffect() => _rotateAudioSource.Pause();

        private void OnDestroy()
        {
            RocketTrustState.OnTrust -= PlayTrustEffect;
            RocketTrustState.OnTrustExit -= PauseTrustEffect;
            RocketRotateIdleState.OnRotate -= PlayRotateEffect;
            RocketRotateState.OnRotateExit -= PauseRotateEffect;
        }
    }
}
