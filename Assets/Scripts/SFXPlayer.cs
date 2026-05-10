using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private float minPitch = 1;
    [SerializeField] private float maxPitch = 1;

    private AudioSource source;

    private void Awake()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;

        foreach (AudioClip clip in clips)
        {
            clip.LoadAudioData();
        }
    }

    public void PlaySound()
    {
        source.clip = clips[Random.Range(0,clips.Length)];
        source.pitch = Mathf.Lerp(minPitch, maxPitch, Random.value);
        source.Play();
    }
}
