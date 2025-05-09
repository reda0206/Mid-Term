using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackgrounds : MonoBehaviour
{
    private float startingPos;
    private float lengthOfSprite;
    public float AmountOfParallax;
    public Camera MainCamera;
    
    void Start()
    {
        startingPos = transform.position.x;
        lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void Update()
    {
        Vector3 Position = MainCamera.transform.position;
        float Temp = Position.x * (1 - AmountOfParallax);
        float distance = Position.x * AmountOfParallax;

        Vector3 newPosition = new Vector3(startingPos + distance, transform.position.y, transform.position.z);

        transform.position = newPosition;
    }
}
