using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementEnnemies : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    public float speed = 1f;

    private Transform currentTarget;

    private enum MovementState { MovingToPointA };
    private MovementState currentState = MovementState.MovingToPointA;

    void Update()
    {
        switch (currentState)
        {
            case MovementState.MovingToPointA:
                MoveToPoint(pointA);
                break;
        }

        if (currentTarget != null) 
        {
            Vector3 directionToTarget = (currentTarget.position - transform.position).normalized;

            if (directionToTarget != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(directionToTarget);
            }
        }
    }

    private void MoveToPoint(Transform targetPoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.01f){

            switch (currentState)
            {
                case MovementState.MovingToPointA:
                    currentTarget = pointA;
                    break;
            }
        
        }
    }
}
