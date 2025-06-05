using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Player
{
    public class DroneUI : MonoBehaviour
    {
        private Slider _droneCountSlider;
        private Slider _droneSpeedSlider;
        private TMP_Text _droneCountText;
        private TMP_Text _droneSpeedText;

        [Inject]
        public void Construct(SliderData sliderData, TextData textData)
        {
            _droneCountSlider = sliderData.CountSlider;
            _droneSpeedSlider = sliderData.SpeedSlider;
            _droneSpeedText = textData.DroneSpeedText;
            _droneCountText = textData.DroneCountText;
        }
        private void Start()
        {
            _droneCountSlider.value = 1;
            _droneSpeedSlider.value = 5f;      
        
            UpdateUI();
        
            _droneCountSlider.onValueChanged.AddListener(delegate { UpdateUI(); });
            _droneSpeedSlider.onValueChanged.AddListener(delegate { UpdateUI(); });
        }
        private void UpdateUI()
        {
            _droneCountText.text = "Количество дронов: " + _droneCountSlider.value.ToString();
            _droneSpeedText.text = "Скорость дронов: " + _droneSpeedSlider.value.ToString();
        }
    }
}
