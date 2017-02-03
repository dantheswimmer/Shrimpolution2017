using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class ShrimpMovement : NetworkBehaviour
{

    Animator animator;
    CharacterController charController;
    Camera camera;
    public float swimPulseLength;
    float pulseIncrement = .1f;
    float pulseRemaining;
    Vector3 pulseDir;
    float pulseStrength;
    bool pulseActivated;


    // Use this for initialization
    void Start()
    {
        camera = gameObject.GetComponentInChildren<Camera>();
        animator = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;
        if (Input.GetKeyDown(KeyCode.W) && !pulseActivated)
        {
            animator.Play("swimPulse");
        }
        updateSwimPulse();

    }

    void beginSwimPulse()
    {
        pulseDir = transform.forward;
        pulseActivated = true;
        pulseRemaining = swimPulseLength;
    }
    void updateSwimPulse()
    {
        if (pulseActivated)
        {
            charController.Move(pulseDir * pulseRemaining / 3);
            pulseRemaining -= pulseIncrement;
            if (pulseRemaining <= 0)
            {
                pulseActivated = false;
            }
        }
    }
}