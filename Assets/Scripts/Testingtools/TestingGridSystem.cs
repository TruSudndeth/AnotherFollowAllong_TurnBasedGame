using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingGridSystem : MonoBehaviour
{
    [SerializeField] private Unit unit;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            unit.GetMoveAction().GetValidActionGridPositionList();
        }
    }
}
