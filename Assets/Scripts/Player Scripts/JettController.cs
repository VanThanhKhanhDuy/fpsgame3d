using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class JettController : MonoBehaviour
{
    public bool isDashing;
    private int dashAttempts;
    private float dashStartTime;
    public bool isUpdrafting = false;
    private float lastTimeUpdrafted = 0.0f;
    /*private float updraftHeigh = 4.0f;
    private float updraftDelaySeconds = 0.2f;
    private int updraftAttempts = 0;
    private int maxUpdraftAttempts = 10;
    public bool isThrowingSmoke = false;*/
    PlayerMovement playerController;
    CharacterController characterController;
   /* [SerializeField]
    GameObject smokeProjectile;
    [SerializeField]
    Transform smokeFiringTransform;
    [SerializeField]
    Camera playerCamera;*/

    /*JettSmokeProjectile currentSmokeProjectile;*/
    /*private float lastTimeSmokeEnded = 0f;
    private float smokeDelaySeconds = 0.3f;*/

    void Start()
    {
        playerController = GetComponent<PlayerMovement>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleDash();
        //HandleSmoke();
    }
    void HandleDash()
    {
        bool isTryingToDash = Input.GetKeyDown(KeyCode.E);
        if(isTryingToDash && !isDashing)
        {
            if(dashAttempts <= 50)
            {
                OnStartDash();
            }
        }
        if (isDashing)
        {
            if(Time.time - dashStartTime <= 0.4f)
            {
                if (playerController.movementVector.Equals(Vector3.zero))
                {
                    //luot ve phia truoc neu khong nhan phim di chuyen
                    characterController.Move(transform.forward * 30f * Time.deltaTime);
                }
                else
                {
                    characterController.Move(playerController.movementVector.normalized * 30f * Time.deltaTime);
                }
            }
            else
            {
                OnEndDash();
            }
        }
    }
    void OnStartDash()
    {
        isDashing = true;
        dashStartTime = Time.time;
        dashAttempts += 1;
    }
    void OnEndDash()
    {
        isDashing = false;
        dashStartTime = 0;
    }
    /*void HandleSmoke()
    {
        bool isTryingToThrowSmoke = Input.GetKeyDown(KeyCode.C);
        if(isTryingToThrowSmoke && Time.time - lastTimeSmokeEnded < smokeDelaySeconds)
        {
            ThrowSmoke();
        }
        if (isThrowingSmoke)
        {
            bool isControlled = Input.GetKey(KeyCode.C);
           currentSmokeProjectile.SetIsControlled(isControlled);
            bool isStoppingControl = Input.GetKeyUp(KeyCode.C);
            if (isStoppingControl)
            {
                OnThrowingSmokeEnd();
            }
        }
    }
    void ThrowSmoke()
    {
        isThrowingSmoke = true;
        GameObject _smokeProjectile = Instantiate(smokeProjectile, smokeFiringTransform.position, playerCamera.transform.rotation);
       currentSmokeProjectile = smokeProjectile.GetComponent<JettSmokeProjectile>();
        currentSmokeProjectile.InitializedValues(false, playerCamera);
        
    }
    void OnThrowingSmokeEnd()
    {
        lastTimeSmokeEnded = Time.time;
        isThrowingSmoke = false;
        currentSmokeProjectile.SetIsControlled(false);
        currentSmokeProjectile = null;
    }*/
    /*
    void HandleUpdraft()
    {

    }
    void Updraft()
    {
        if(!)
    }
    void OnUpdraftStart()
    {
        isUpdrafting = true;
        lastTimeUpdrafted = Time.time;
    }
    void OnUpdraftEnd()
    {
        isUpdrafting = false;
        
    }*/
}
