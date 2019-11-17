using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationComponent : MonoBehaviour
{
    public float m_RotationSpeed = 0.0f;

    private void Update()
    {
        this.transform.rotation *= Quaternion.AngleAxis(Time.deltaTime * this.m_RotationSpeed, this.transform.up);
    }
}
