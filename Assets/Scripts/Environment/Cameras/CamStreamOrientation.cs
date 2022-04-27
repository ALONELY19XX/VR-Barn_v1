using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamStreamOrientation : MonoBehaviour
{
    [SerializeField] private Camera target;
    
    void Update()
    {
        gameObject.transform.LookAt(target.transform);
    }
}
