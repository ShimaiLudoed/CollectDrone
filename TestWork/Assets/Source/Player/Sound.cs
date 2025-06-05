using Data;
using UnityEngine;
using Zenject;

public class Sound : ISound
{
  private readonly AudioSource _source;
  private readonly AudioClip _putSound;

  [Inject]
  public Sound(AudioData audioData)
  {
    _source = audioData.AudioSource;
    _putSound = audioData.PutResource;
  }

  public void PlayPutSound()
  {
    _source.PlayOneShot(_putSound);
  }
}
