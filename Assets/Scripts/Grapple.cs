using UnityEngine;

public class Grapple : MonoBehaviour
{
    float x, y;

    void Update()
    {
        x = Input.GetAxisRaw("AimHorizontal");
        y = Input.GetAxisRaw("AimVertical");
        transform.localPosition = new Vector3(
            x * Mathf.Sqrt(1 - 0.5f * y * y),
            y * Mathf.Sqrt(1 - 0.5f * x * x)
        );

        //this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, distance);
    }
}
