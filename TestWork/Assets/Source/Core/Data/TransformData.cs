using UnityEngine;

namespace Data
{
    public class TransformData : MonoBehaviour
    {
        [field: SerializeField] public Transform RedBase {get; private set;}
        [field: SerializeField] public Transform BlueBase {get; private set;}
        [field: SerializeField] public Transform RedSpawn {get; private set;}
        [field: SerializeField] public Transform BlueSpawn {get; private set;}
    }
}
