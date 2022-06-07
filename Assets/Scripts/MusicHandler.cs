using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace miniit.MERGE
{
    public class MusicHandler : MonoBehaviour
    {
        public AudioMixerSnapshot paused;
        public AudioMixerSnapshot unpaused;
        [SerializeField] private AudioSource audioSourse;
        [SerializeField] private AudioSource prefab;
        [SerializeField] private Transform selfTransform;

        [Tooltip("Name of path in resources.")]
        [SerializeField] private const string Sounds = nameof(Sounds);

        public void PauseMusic()
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            Lowpass();
        }

        private void Lowpass()
        {
            if (Time.timeScale == 0)
            {
                paused.TransitionTo(.01f);
            }
            else
            {
                unpaused.TransitionTo(.01f);
            }
        }

        public void StopSceneMusic()
        {
            audioSourse.Stop();
        }

        public void PlaySoundInternal(AudioClip sound)
        {
            AudioSource soundSource = Instantiate<AudioSource>(prefab, selfTransform);
            soundSource.clip = sound;
            soundSource.Play();
            StartCoroutine(DestroyAfterPlay(soundSource));
        }

        private IEnumerator DestroyAfterPlay(AudioSource soundSource)
        {
            yield return new WaitForSeconds(soundSource.clip.length);
            Destroy(soundSource.gameObject);
        }

        public void ApplyMusicVolume(float volume)
        {
            audioSourse.volume = volume;
        }
    }
}