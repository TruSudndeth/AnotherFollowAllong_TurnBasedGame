using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingGridSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private GridSystem gridSystem;
    private Vector3 worldPosition;
    private Collider Unit;

    [SerializeField] private Transform gridDebugObjectPrefab;
    void Start()
    {
       gridSystem =  new GridSystem(10, 10, 2f);
       gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
    }

    private void Update()
    {
        MouseWorld.GetPosition(out worldPosition, out Unit);
        Debug.Log(gridSystem.GetGridPosition(worldPosition));
    }
}
