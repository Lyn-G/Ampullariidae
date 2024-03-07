using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    public float parallaxSpeed = 0.5f; // Adjust this value to control the scrolling speed

    void Update()
    {
        float offset = Time.time * parallaxSpeed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, 0);
    }
}