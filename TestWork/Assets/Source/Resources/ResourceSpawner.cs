
using Data;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private int maxResources = 10; 
    [SerializeField] private Vector3 spawnAreaSize = new Vector3(40, 1, 40);
    private Stone.StoneFactory _stoneFactory; 
    private Slider _repeatRate; //TODO сделать скорость появления ресурса
    
    [Inject]
    public void Construct(Stone.StoneFactory stoneFactory,SliderData sliderData)
    {
        _repeatRate = sliderData.GameSpeedSlider;
        _stoneFactory = stoneFactory;
    }
    private void Start()
    {
        _repeatRate.onValueChanged.AddListener(delegate { UpdateSpawn();});
        InvokeRepeating("SpawnResource", 0f, _repeatRate.value);
    }

    void UpdateSpawn()
    {
        CancelInvoke("SpawnResource");
        InvokeRepeating("SpawnResource", 0f, _repeatRate.value);
    }
    void SpawnResource()
    {
        if (GameObject.FindGameObjectsWithTag("Resource").Length < maxResources) 
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnAreaSize.x , spawnAreaSize.x ),
                1, 
                Random.Range(-spawnAreaSize.z , spawnAreaSize.z )
            );
            Stone stoneObj = _stoneFactory.Create();
            stoneObj.transform.position = randomPosition;
        }
    }
}
