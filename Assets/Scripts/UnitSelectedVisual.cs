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
        SelectedVisual = UnitActionSystem.Instance.GetSelectedUnit();
        SelectedVisual.GetComponentInChildren<UnitSelectedVisual>().meshRenderer.enabled = true;
        UnitActionSystem.Instance.OnSelectedUnitchange += UnitActionSystem_OnSelectedUnitChange;
    }

    private void UnitActionSystem_OnSelectedUnitChange(object sender, EventArgs empty)
    {
        SelectedVisual = UnitActionSystem.Instance.GetSelectedUnit();
        SelectedVisual.GetComponentInChildren<UnitSelectedVisual>().meshRenderer.enabled = false;
        UnitActionSystem.Instance.TrySwitchUnit();
        SelectedVisual = UnitActionSystem.Instance.GetSelectedUnit();
        SelectedVisual.GetComponentInChildren<UnitSelectedVisual>().meshRenderer.enabled = true;
    }
}
