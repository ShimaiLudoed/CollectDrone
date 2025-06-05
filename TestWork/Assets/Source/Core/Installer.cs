using Data;
using Player;
using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField] private ParticleData particleData;
    [SerializeField] private AudioData audioData;
    [SerializeField] private ResourceSpawner resourceSpawner;
    [SerializeField] private Stone stone;
    [SerializeField] private Score score;
    [SerializeField] private RedDrone redDrone;
    [SerializeField] private DroneManager droneManager;
    [SerializeField] private DroneUI droneUI;
    [SerializeField] private BlueDrone blueDrone;
    [SerializeField] private TransformData transformData;
    [SerializeField] private SliderData sliderData;
    [SerializeField] private TextData textData;
    
    public override void InstallBindings()
    {
        Container.Bind<ISound>().To<Sound>().AsSingle().NonLazy();
        
        Container.Bind<Score>().FromInstance(score).AsSingle();
        
        Container.Bind<RedDrone>().FromInstance(redDrone).AsTransient();
        Container.Bind<BlueDrone>().FromInstance(blueDrone).AsTransient();
        Container.BindFactory<TransformData, Score, ISound, ParticleData, RedDrone, RedDrone.RedDroneFactory>().FromComponentInNewPrefab(redDrone);
        Container.BindFactory<TransformData, Score, ISound, ParticleData, BlueDrone, BlueDrone.BlueDroneFactory>().FromComponentInNewPrefab(blueDrone);

        Container.Bind<ResourceSpawner>().FromInstance(resourceSpawner).AsSingle();
        Container.Bind<Stone>().FromInstance(stone).AsTransient();
        Container.BindFactory<Stone, Stone.StoneFactory>().FromComponentInNewPrefab(stone);

        Container.Bind<DroneUI>().FromInstance(droneUI).AsSingle();
        Container.Bind<DroneManager>().FromInstance(droneManager).AsSingle();

        Container.Bind<ParticleData>().FromInstance(particleData).AsSingle().NonLazy();
        Container.Bind<TransformData>().FromInstance(transformData).AsSingle().NonLazy();
        Container.Bind<SliderData>().FromInstance(sliderData).AsSingle().NonLazy();
        Container.Bind<TextData>().FromInstance(textData).AsSingle().NonLazy();
        Container.Bind<AudioData>().FromInstance(audioData).AsSingle().NonLazy();
    }
}