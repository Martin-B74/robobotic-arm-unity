using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CircleDrawer : MonoBehaviour
{
    public ArmController controller;

    public Vector3 circleCenter = new Vector3(20f, 0f, 20f);
    public float radius = 10f;
    public int segments = 360;
    public float duration = 5f;

    float t = 0f;
    bool playing = false;

    LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.useWorldSpace = true;
        lr.loop = false;
        lr.positionCount = 0;
        lr.widthMultiplier = 0.1f;
        lr.material = new Material(Shader.Find("Sprites/Default"));
    }

    void Update()
    {
        if (!playing || controller == null)
            return;

        t += Time.deltaTime / duration;
        t = Mathf.Clamp01(t);

        Vector3 p = GetCirclePoint(t);

        controller.coordonnees = p;

        lr.positionCount++;
        lr.SetPosition(lr.positionCount - 1, p);

        if (t >= 1f)
            playing = false;
    }

    Vector3 GetCirclePoint(float t)
    {
        float angle = t * 2f * Mathf.PI;
        return new Vector3(
            circleCenter.x + radius * Mathf.Cos(angle),
            circleCenter.y,
            circleCenter.z + radius * Mathf.Sin(angle)
        );
    }

    public void StartDrawing()
    {
        t = 0f;
        playing = true;
        lr.positionCount = 0;
    }
}
