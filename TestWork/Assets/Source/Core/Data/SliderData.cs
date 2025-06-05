using UnityEngine;
using UnityEngine.UI;

namespace Data
{
    public class SliderData : MonoBehaviour
    {
        [field: SerializeField] public Slider GameSpeedSlider { get; private set; }
        [field: SerializeField] public Slider CountSlider {get; private set; }
        [field: SerializeField] public Slider SpeedSlider {get; private set; }
    }
}
