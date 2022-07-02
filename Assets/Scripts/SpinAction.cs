using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : MonoBehaviour
{
    [SerializeField] private float SpinSpeed = 1;

    private bool startSpinning;
    private bool isActive = false;
    public void Update()
    {
        if (!isActive) return;
            if (startSpinning)
            {
                float addSpinAmount = 360.0f * Time.deltaTime * SpinSpeed;
                if (addSpinAmount >= 360)
                {
                    addSpinAmount = 0;
                    startSpinning = false;
                }
                transform.eulerAngles += new Vector3(0, addSpinAmount, 0);
            } 
    }
    public void Spin()
    {
        startSpinning = true;
    }
}
