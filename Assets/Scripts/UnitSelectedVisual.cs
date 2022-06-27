using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] private Unit SelectedVisual;
    private MeshRenderer meshRenderer;
    //Initiate Selected Visual by Parent Unit GetCompnent (Maybe)
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

    // Update is called once per frame
    void Start()
    {
        UpdateVisual();
        UnitActionSystem.Instance.OnSelectedUnitchange += UnitActionSystem_OnSelectedUnitChange;
    }

    private void UnitActionSystem_OnSelectedUnitChange(object sender, EventArgs empty)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (UnitActionSystem.Instance.GetSelectedUnit() == SelectedVisual)
        {
            meshRenderer.enabled = true;
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }
}
