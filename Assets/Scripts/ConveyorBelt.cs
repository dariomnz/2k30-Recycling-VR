using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ConveyorBelt : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 0.2f;
    public float Speed
    {
        set => SetSpeed(value);
        get { return m_Speed; }
    }
    Rigidbody rBody;
    public GameObject Belt;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 pos = rBody.position;
        rBody.position += -transform.forward * Speed * Time.fixedDeltaTime;
        rBody.MovePosition(pos);
    }

    void OnValidate()
    {
        SetSpeed(Speed);
    }

    void SetSpeed(float newValue)
    {
        m_Speed = newValue;
        Belt.GetComponent<Renderer>().sharedMaterials[1].SetFloat("Vector1_Speed", m_Speed);
    }
}
