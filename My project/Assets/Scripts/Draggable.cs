using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IPointerClickHandler
{
    private bool isMoving = false;
    private float glideDuration = 0.25f; // Duration of the glide in seconds
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float timer;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        initialPosition = transform.position;
        float targetX = 345f; // Set your desired x coordinate here
        float targetY = 100f; // Set your desired y coordinate here
        targetPosition = new Vector3(targetX, targetY, initialPosition.z);
    }

    
    private void Update()
    {
        if (isMoving)
        {
            source.Play();
            timer += Time.deltaTime;
            if (timer <= glideDuration)
            {
                transform.position = Vector3.Lerp(initialPosition, targetPosition, timer / glideDuration);
            }
            else
            {
                isMoving = false;
                transform.position = targetPosition; // Ensures that it exactly reaches the target at the end.
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartGlide();
    }

    public void StartGlide()
    {
        if (!isMoving)
        {
            isMoving = true;
            timer = 0f;
            initialPosition = transform.position; // Update the initial position each time a new glide is started
        }
    }
}