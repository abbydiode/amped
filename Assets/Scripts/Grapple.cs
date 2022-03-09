using UnityEngine;

public class Grapple : MonoBehaviour
{
    public float ExtensionSpeed = 0.01f;

    float x, y;
    bool IsAiming, Shoot;
    public GameObject Arm, Crosshair;
    SpriteRenderer ArmRenderer;

    void Start()
    {
        ArmRenderer = Arm.GetComponent<SpriteRenderer>();
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
            ArmRenderer.size += new Vector2(ExtensionSpeed / 2, 0);
        else if (ArmRenderer.size.x > 0.1)
            ArmRenderer.size -= new Vector2(ExtensionSpeed / 2, 0);

        ArmRenderer.material.color = new Color(1, 1, 1, ArmRenderer.size.x > 0.5f ? 1 : 0);
    }
}
