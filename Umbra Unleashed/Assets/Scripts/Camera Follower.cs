using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//screenshake based on code from https://gist.github.com/ftvs/5822103 

public class PlayerMovement : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.2f;
    public float decreaseFactor = 1.0f;

    //temp variable to recycle
    public float tempDur;

    Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        //camera shake
        if (shakeDuration > 0)
        {
            originalPos = target.position + offset;
            Vector3 newPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            transform.position = newPosition;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            transform.position = target.position + offset;
        }
    }

    public void CauseScreenShake(float duration)
    {
        tempDur = duration;
        Invoke("TriggerShake", 0.6f);
    }

    public void TriggerShake()
    {
        shakeDuration = tempDur;
    }
}