using TMPro;
using UnityEngine;

namespace Data
{
    public class TextData : MonoBehaviour
    {
        [field: SerializeField] public TMP_Text BlueResources { get; private set; }
        [field: SerializeField] public TMP_Text RedResources { get; private set; }
        [field: SerializeField] public TMP_Text DroneSpeedText { get; private set; }
        [field: SerializeField] public TMP_Text DroneCountText { get; private set; }
        [field: SerializeField] public TMP_Text GameSpeedText { get; private set; }
    }
}
