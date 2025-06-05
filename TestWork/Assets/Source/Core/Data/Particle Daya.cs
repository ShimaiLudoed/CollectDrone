using UnityEngine;

namespace Data
{
  public class ParticleData : MonoBehaviour
  {
    [field: SerializeField] public ParticleSystem BlueParti { get; private set; }
    [field: SerializeField] public ParticleSystem RedParti { get; private set; }
  }
}
