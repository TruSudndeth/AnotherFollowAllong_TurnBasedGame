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
    }

    // Update is called once per frame
    void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitchange += UnitActionSustem_OnSelectedUnitChange;
    }

    private void UnitActionSustem_OnSelectedUnitChange(object sender, EventArgs empty)
    {

    }
}
