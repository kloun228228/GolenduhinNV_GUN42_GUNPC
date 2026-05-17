using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gates : MonoBehaviour
{
    private static int _score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
        {
            _score++;
            Debug.Log($"Гол, текущий счет: {_score}");
            Destroy( ball.gameObject );
        }
    }
   
}
