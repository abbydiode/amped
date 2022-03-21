using UnityEngine;

public class Grapple : MonoBehaviour
{
    public float ExtensionSpeed = 0.02f;
    public GameObject Arm, Crosshair, Hand;

    float x, y;
    bool IsAiming, Shoot;
    SpriteRenderer ArmRenderer, HandRenderer;
    Vector2 ShotSpeed;

    void Start()
    {
        ArmRenderer = Arm.GetComponent<SpriteRenderer>();
        HandRenderer = Hand.GetComponent<SpriteRenderer>();
        ShotSpeed = new Vector2(ExtensionSpeed / 2, 0);
    }

    void Update()
    {
        x = Input.GetAxisRaw("AimHorizontal");
        y = Input.GetAxisRaw("AimVertical");
        Shoot = Input.GetAxisRaw("ShootHook") < -0.5;

        IsAiming = Mathf.Abs(x) + Mathf.Abs(y) > 0.5;

        Crosshair.transform.localPosition = new Vector3(
            x * Mathf.Sqrt(1 - 0.5f * y * y),
            y * Mathf.Sqrt(1 - 0.5f * x * x)
        );

        Arm.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(y, x) * (180 / Mathf.PI));

        Crosshair.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, IsAiming ? 1 : 0);


        if (Shoot)
        {
            ArmRenderer.size += ShotSpeed;
            Hand.transform.localPosition += (Vector3)ShotSpeed;
        }
        else if (ArmRenderer.size.x > 0.1)
        {
            ArmRenderer.size -= ShotSpeed;
            Hand.transform.localPosition -= (Vector3)ShotSpeed;
        }
        else
        {
            ArmRenderer.size = new Vector2(0, ArmRenderer.size.y);
            Hand.transform.localPosition = new Vector3(0, 0, 0);
        }

        ArmRenderer.material.color = new Color(1, 1, 1, ArmRenderer.size.x > 0.5f ? 1 : 0);
        HandRenderer.material.color = new Color(1, 1, 1, ArmRenderer.size.x > 0.5f ? 1 : 0);
    }
}
