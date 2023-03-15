using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JettSmokeProjectile : MonoBehaviour
{
    [SerializeField] GameObject smokeBallPrefab;

    public bool isControlled;
    private Vector3 startingPositioin;
    private float particleMovementSpeed = 20.0f;
    private float maxDistance = 70.0f;
    private float distanceTraveled = 0f;
    private Camera playerCamera;
    private float downnwardForce = -2.0f;
    private float downwardForceIncrement = -3.8f;



    void Start()
    {
        startingPositioin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlled)
        {
            transform.rotation = playerCamera.transform.rotation;
        }
        Vector3 movementVector = (transform.forward * particleMovementSpeed * Time.deltaTime);
        if(!isControlled)
        {
            downnwardForce += downwardForceIncrement * Time.deltaTime;
            movementVector += (transform.up * downnwardForce * Time.deltaTime);
        }
        Vector3 newPosition = transform.position + movementVector;
        distanceTraveled = Vector3.Distance(startingPositioin, newPosition);
        if (distanceTraveled > maxDistance)
        {
            OnCreateSmokeBall(transform.position);
        }
        else
        {
            transform.position += movementVector;
        }
    }
    public void InitializedValues (bool _isControlled, Camera _playerCamera)
    {
        isControlled = _isControlled;
        playerCamera = _playerCamera;
    }
    public void SetIsControlled(bool _isControlled)
    {
        isControlled = _isControlled;
    }
    void OnCreateSmokeBall(Vector3 position)
    {
        Instantiate(smokeBallPrefab, position, transform.rotation);
        Destroy(this.gameObject);
    }
}
