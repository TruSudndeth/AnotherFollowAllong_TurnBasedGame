using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : MonoBehaviour
{
    [SerializeField] private float SpinSpeed = 1;

    private bool startSpinning;
    private bool isActive = false;
    private float currentSpinAngle;
    public void Update()
    {
        if (!isActive) return;
            if (startSpinning)
            {
                float addSpinAmount = 360.0f * Time.deltaTime * SpinSpeed;
                currentSpinAngle += addSpinAmount;
                if (currentSpinAngle >= 360.0f)
                {
                    addSpinAmount = 0;
                    startSpinning = false;
                    transform.rotation = Quaternion.Euler(Vector3.zero);
                    currentSpinAngle = 0;
                }
                transform.eulerAngles += new Vector3(0, addSpinAmount, 0);
            } 
    }
    public void Spin()
    {
        startSpinning = true;
        isActive = true;
    }
}
