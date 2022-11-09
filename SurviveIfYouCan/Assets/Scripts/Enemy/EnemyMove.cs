using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float _movementSpeed;

    private void Update()
    {
        float _step = _movementSpeed * Time.deltaTime;
        float _distance = Vector3.Distance(player.position, transform.position);
        if (_distance < 10)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, _step);
        }
    }
}
