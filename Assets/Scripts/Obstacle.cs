using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float Speed = 3;
    [SerializeField] private float minY = -2.0f;
    [SerializeField] private float maxY = 2.0f;
    [SerializeField] private float respawnX = 9.0f;

    private Vector3 initialPosition;

    void Start()
    {
        float randomY = Random.Range(minY, maxY);
        initialPosition = new Vector3(respawnX, randomY, transform.position.z);
        transform.position = initialPosition;
    }

    void Update()
    {
        if (transform.position.x <= -8)
        {
            float randomY = Random.Range(minY, maxY);
            initialPosition = new Vector3(respawnX, randomY, transform.position.z);
            transform.position = initialPosition;
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * -Speed);
        }
    }
}