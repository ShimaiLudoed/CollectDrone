using Data;
using UnityEngine;
using Zenject;

namespace Player
{
  public class BlueDrone : ADrone
  {
    public override void Construct(TransformData transformData,Score score, ISound sound, ParticleData particleData)
    {
      base.Construct(transformData, score, sound, particleData);
      _parti = particleData.BlueParti;
      _score = score;
      _base = transformData.BlueSpawn;
    }
    public override void GetScore()
    {
      Debug.Log(_score);
      _score.AddBlueScore();
    }

    public class BlueDroneFactory : PlaceholderFactory<TransformData,Score, ISound, ParticleData, BlueDrone>
    { }
  }
}
