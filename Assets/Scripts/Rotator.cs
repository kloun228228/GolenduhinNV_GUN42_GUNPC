using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private Vector3 _rotate;
    Rigidbody _rb;

    private IEnumerator Start()
    {
        _rb = GetComponent<Rigidbody>();
        while (true)
        {
            yield return new WaitForFixedUpdate();
            Quaternion deltaRotation = Quaternion.Euler(_rotate * Time.fixedDeltaTime);
            _rb.MoveRotation(_rb.rotation * deltaRotation);
        }
    }

    
}
