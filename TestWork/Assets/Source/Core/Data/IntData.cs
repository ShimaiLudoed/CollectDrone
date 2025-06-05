using UnityEngine;

namespace Data
{
    public class IntData : MonoBehaviour
    {
        [field: SerializeField] public int BlueScore { get; private set; }
        [field: SerializeField] public int RedScore { get; private set; }
    }
}
