using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField]
    private Vector3 acceleration, velocity, position;
    [SerializeField]
    [Range (0,1)]
    private float airResistance;

    void Start()
    {
        position += transform.position;
    }

    void Update()
    {
        Move();


        if (position.x > 5 || position.x < -5)
        {
            velocity.x = velocity.x * -1 * airResistance;
            Recalculate();
        }
        if (position.y > 5 || position.y < -5)
        {
            velocity.y = velocity.y * -1 * airResistance;
            Recalculate();
        }
    }

    public void Move()
    {
        velocity += acceleration * Time.deltaTime;
        position += velocity * Time.deltaTime;
        transform.position = position;
    }

    void Recalculate()
    {
        if (position.x > 5)
        {
            position.x = 5;
        }
        else if (position.y > 5)
        {
            position.y = 5;
        }
        else if (position.x < -5)
        {
            position.x = -5;
        }
        else if (position.y < -5)
        {
            position.y = -5;
        }
        else
        {
            return;
        }
    }
}
