using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public Vector3 upRecoil;
    private Vector3 originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.localEulerAngles;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddRecoil()
    {
        transform.localEulerAngles += upRecoil;
    }

    private void StopRecoil()
    {
        transform.localEulerAngles = originalRotation;
    }
}
