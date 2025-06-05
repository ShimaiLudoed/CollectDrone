using UnityEngine;

namespace Data
{
  public class AudioData : MonoBehaviour
  {
    [field: SerializeField] public AudioSource AudioSource { get; private set;  }
    [field: SerializeField] public AudioClip PutResource { get; private set; }
  }
}
