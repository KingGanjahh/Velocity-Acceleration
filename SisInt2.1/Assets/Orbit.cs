using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField]
    private Vector3 acceleration, velocity, position;

    [SerializeField]
    private GameObject objectToOrbit;
    [SerializeField]
    private Vector3 objectPosition;
    [SerializeField]
    [Range(0, 10)]
    private float orbitalForce;

    [SerializeField]
    private float initialYSpd;

    void Start()
    {
        position += transform.position;
        velocity.y += initialYSpd;
    }

    void Update()
    {
        Move();

        if (position.x - objectPosition.x > orbitalForce)
        {
            velocity.x = velocity.x * -1;
        }
        if (position.y - objectPosition.y > orbitalForce)
        {
            velocity.y = velocity.y * -1;
        }
    }

    public void Move()
    {
        acceleration = objectToOrbit.transform.position - position;
        velocity += acceleration.normalized * 2 * Time.deltaTime;
        position += velocity * Time.deltaTime;
        transform.position = position;
    }
}
