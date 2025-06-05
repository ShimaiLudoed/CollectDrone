using Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Player
{
  public class DroneManager : MonoBehaviour
  {
    private RedDrone.RedDroneFactory _redDroneFactory;
    private BlueDrone.BlueDroneFactory _blueDroneFactory;
    private Score _score;
    private ISound _sound;
    private TransformData _transformData;
    private Slider _speedSlider;
    private Slider _countSlider;
    private ParticleData _particle;
    [SerializeField] private List<ADrone> _drones = new List<ADrone>();
    
    [Inject]
    public void Construct(ParticleData particleData, RedDrone.RedDroneFactory redDroneFactory,BlueDrone.BlueDroneFactory blueDroneFactory,TransformData transformData,SliderData sliderData, Score score, ISound sound)
    {
      _particle = particleData;
      _sound = sound;
      _score = score;
      _blueDroneFactory = blueDroneFactory;
      _redDroneFactory = redDroneFactory;
      _transformData = transformData;
      _speedSlider = sliderData.SpeedSlider;
      _countSlider = sliderData.CountSlider;
    }
    void Start()
    {
      UpdateDrones();
      _speedSlider.onValueChanged.AddListener(delegate { UpdateDrones(); });
      _countSlider.onValueChanged.AddListener(delegate { UpdateDrones(); });
      //TODO сделать не только по слайду и отвязать от сцены
    }
    void UpdateDrones()
    {
      foreach (var drone in _drones)
      {
        Destroy(drone.gameObject);
      }
      _drones.Clear();
      int count = Mathf.RoundToInt(_countSlider.value);
      for (int i = 0; i < count; i++)
      {
        //GameObject droneObj = Instantiate(dronePrefab, baseLocation.position, Quaternion.identity);
        //Drone drone = droneObj.GetComponent<Drone>();
        ADrone redADroneObj = _redDroneFactory.Create(_transformData,_score, _sound,_particle);
        redADroneObj.transform.position = _transformData.RedSpawn.position;
        redADroneObj.speed = _speedSlider.value;
        _drones.Add(redADroneObj);
        ADrone blueADroneObj = _blueDroneFactory.Create(_transformData, _score, _sound,_particle);
        blueADroneObj.transform.position = _transformData.BlueSpawn.position;
        blueADroneObj.speed = _speedSlider.value;
        _drones.Add(blueADroneObj);
      }
    }
  }
}
