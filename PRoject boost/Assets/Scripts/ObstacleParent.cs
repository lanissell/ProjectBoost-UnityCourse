using Unity.VisualScripting;
using UnityEngine;

public class ObstacleParent : MonoBehaviour
{
    private Transform[] _children;

    private void Start()
    {
        _children = transform.GetComponentsInChildren<Transform>();
        foreach (var child in _children) 
            child.AddComponent<Obstacle>();
    }
}
