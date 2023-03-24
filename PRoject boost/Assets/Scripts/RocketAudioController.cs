using StateMachine.RocketStateMachine.States;
using UnityEngine;

public class RocketAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _trustAudioSource;
    [SerializeField] private AudioSource _rotateAudioSource;
    
    void Start()
    {
        RocketMovementState.OnTrust += PlayTrustSound;
        RocketMovementState.OnTrustExit += PauseTrustSound;
        RocketMovementState.OnRotate += PlayRotateSound;
        RocketMovementState.OnRotateExit += PauseRotateSound;
    }

    private void PlayTrustSound()
    {
        if (_trustAudioSource.isPlaying) return;
        _trustAudioSource.Play();
    }
    
    private void PauseTrustSound() => _trustAudioSource.Pause();
    
    private void PlayRotateSound()
    {
        if (_rotateAudioSource.isPlaying) return;
        _rotateAudioSource.Play();
    }
    
    private void PauseRotateSound() => _rotateAudioSource.Pause();

    private void OnDestroy()
    {
        RocketMovementState.OnTrust -= PlayTrustSound;
        RocketMovementState.OnTrustExit -= PauseTrustSound;
        RocketMovementState.OnRotate -= PlayRotateSound;
        RocketMovementState.OnRotateExit -= PauseRotateSound;
    }
}
