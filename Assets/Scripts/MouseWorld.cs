using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance;

    [SerializeField]
    private LayerMask mousePlainMask;

    private void Awake() 
    {
        instance = this;    
    }
    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Camera.main needs to cache unity 2020 auto cache Camera.main
        Debug.Log(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlainMask));
        return raycastHit.point;
    }

    
    //Testing code
    //void FixedUpdate()
    //{
    //    //Debug.Log(Input.mousePosition);  //pixel cordinates
    //    transform.position = GetPosition();

    //}
}
