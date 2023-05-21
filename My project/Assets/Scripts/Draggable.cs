using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerClickHandler
{
    private bool isMoving = false;
    private float glideDuration = 16f; // Duration of the glide in seconds
    private float glideSpeed = 2f; // Speed of the glide calculated based on the duration
    private Vector3 initialPosition;
    private float timer;

    private void Start()
    {
        glideSpeed = transform.position.y / glideDuration;
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (isMoving)
        {
            timer += Time.deltaTime;
            if (timer <= glideDuration)
            {
                float targetX = 345f; // Set your desired x coordinate here
                float targetY = 120f; // Set your desired y coordinate here
                Vector3 targetPosition = new Vector3(targetX, targetY, initialPosition.z);
                transform.position = targetPosition;
            }
            else
            {
                isMoving = false;
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
        }
    }

    private IEnumerator FadeOut()
    {
        isFading = true;

        // Get the initial color and alpha value
        Color initialColor = objectRenderer.material.color;
        float initialAlpha = initialColor.a;

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;

            // Calculate the new alpha value
            float alpha = Mathf.Lerp(initialAlpha, 0f, timer / fadeDuration);

            // Update the object's color with the new alpha value
            Color newColor = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            objectRenderer.material.color = newColor;

            yield return null;
        }

        // Set the final alpha value to ensure it's fully faded out
        Color finalColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);
        objectRenderer.material.color = finalColor;

        isFading = false;
    }
}
