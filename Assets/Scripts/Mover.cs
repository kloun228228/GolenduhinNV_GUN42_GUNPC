using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector3 _start;
    [SerializeField] private Vector3 _end;
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;

    private Rigidbody _rb;

    private IEnumerator Start()
    {
        _rb = GetComponent<Rigidbody>();

      
        Vector3 globalStart = transform.TransformPoint(_start);
        Vector3 globalEnd = transform.TransformPoint(_end);

        while (true)
        {
            
            yield return StartCoroutine(MoveToTarget(globalEnd));
            
            yield return new WaitForSeconds(_delay);

            
            yield return StartCoroutine(MoveToTarget(globalStart));

            yield return new WaitForSeconds(_delay);
        }
    }

    
    private IEnumerator MoveToTarget(Vector3 target)
    {
        
        while (Vector3.Distance(_rb.position, target) > 0.01f)
        {
            yield return new WaitForFixedUpdate();

            
            Vector3 nextPosition = Vector3.MoveTowards(_rb.position, target, _speed * Time.fixedDeltaTime);
            _rb.MovePosition(nextPosition);
        }
    }

    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
     
        Vector3 gStart = transform.TransformPoint(_start);
        Vector3 gEnd = transform.TransformPoint(_end);

        Gizmos.DrawSphere(gStart, 0.2f);
        Gizmos.DrawSphere(gEnd, 0.2f);
        Gizmos.DrawLine(gStart, gEnd);
    }
}