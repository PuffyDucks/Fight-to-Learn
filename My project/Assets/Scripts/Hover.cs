using UnityEngine;

public class Hover : MonoBehaviour
{
    private bool isHovering = false;
    private bool isMovingUp = false;
    private float hoverDuration = 4f; // Duration of each hover cycle in seconds
    private float hoverDistance = 2f; // Increased hover distance
    private Vector3 initialPosition;
    private float timer;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (isHovering)
        {
            timer += Time.deltaTime;
            float t = Mathf.PingPong(timer / hoverDuration, 1f);
            float yOffset = Mathf.Sin(t * Mathf.PI * 2f) * hoverDistance;
            transform.position = initialPosition + new Vector3(0f, yOffset, 0f);
        }
    }

    private void OnMouseEnter()
    {
        StartHover();
    }

    private void OnMouseExit()
    {
        StopHover();
    }

    public void StartHover()
    {
        isHovering = true;
        isMovingUp = true;
        timer = 0f;
    }

    public void StopHover()
    {
        isHovering = false;
        isMovingUp = false;
        transform.position = initialPosition;
    }
}