using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CircleDrawer : MonoBehaviour
{
    [Header("Robot")]
    public RobotController controller;
    public Transform pencil;

    [Header("Cercle")]
    public Vector3 circleCenter = new Vector3(20f, 0f, 20f);
    public float radius = 10f;
    public int segments = 360;

    [Header("Temps")]
    public float duration = 5f;

    [Header("Départ")]
    public Vector3 drawingStartPosition;
    public float startTolerance = 0.1f;

    float t = 0f;
    bool playing = false;
    bool drawing = false;

    LineRenderer lr;
    Vector3[] circlePoints;
    int lastIndex = -1;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.useWorldSpace = true;
        lr.loop = false;
        lr.positionCount = 0;
        lr.widthMultiplier = 0.1f;
        lr.material = new Material(Shader.Find("Sprites/Default"));

        PrecomputeCircle();
        Play();
    }

    void PrecomputeCircle()
    {
        circlePoints = new Vector3[segments];

        float angleStep = 2f * Mathf.PI / segments;

        for (int i = 0; i < segments; i++)
        {
            float angle = i * angleStep;

            circlePoints[i] = new Vector3(
                circleCenter.x + radius * Mathf.Cos(angle),
                circleCenter.y,
                circleCenter.z + radius * Mathf.Sin(angle)
            );
        }
    }

    void Update()
    {
        if (!playing || controller == null)
            return;

        controller.slider = false;

        if (!drawing)
        {
            controller.coordonnees = drawingStartPosition;

            if (Vector3.Distance(pencil.position, drawingStartPosition) < startTolerance)
            {
                drawing = true;
                t = 0f;
                lastIndex = -1;
                lr.positionCount = 0;
            }
            return;
        }

        t += Time.deltaTime / duration;
        if (t > 1f)
            t = 1f;

        int index = Mathf.FloorToInt(t * segments);
        index = Mathf.Clamp(index, 0, segments - 1);

        if (index != lastIndex)
        {
            Vector3 p = circlePoints[index];

            controller.coordonnees = p;

            lr.positionCount++;
            lr.SetPosition(lr.positionCount - 1, p);

            lastIndex = index;
        }

        if (t >= 1f)
        {
            playing = false;

            if (lr.positionCount > 1)
            {
                lr.positionCount++;
                lr.SetPosition(lr.positionCount - 1, lr.GetPosition(0));
            }
        }
    }

    public void Play()
    {
        t = 0f;
        playing = true;
        drawing = false;
        lastIndex = -1;

        if (lr != null)
            lr.positionCount = 0;
    }
}
