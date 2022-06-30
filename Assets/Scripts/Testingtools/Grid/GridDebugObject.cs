using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TMProUGUI;
    private GridObject gridObject;

    public void SetGridObject(GridObject _gridObject)
    {
        gridObject = _gridObject;
    }

    public void Update()
    {
        _TMProUGUI.text = gridObject.ToString();
    }

}
