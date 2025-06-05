using UnityEngine;
using Zenject;


public class Stone : MonoBehaviour
{
    public bool IsOccupied;
    public void SetOccupied(bool value)
    {
        IsOccupied = value;
    }
    public class StoneFactory : PlaceholderFactory<Stone> { }
}

