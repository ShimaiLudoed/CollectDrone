using Data;
using Zenject;

namespace Player
{
  public class RedDrone : ADrone
  {
    public override void Construct(TransformData transformData, Score score, ISound sound, ParticleData particleData)
    {
      base.Construct(transformData, score, sound, particleData);
      _parti = particleData.RedParti;
      _score = score;
      _base = transformData.RedSpawn;
    }

    public override void GetScore()
    {
      _score.AddRedScore();
    }

    public class RedDroneFactory : PlaceholderFactory<TransformData, Score, ISound, ParticleData, RedDrone>
    { }
  }
}
