using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineDrawer : MonoBehaviour
{
    [Header("Robot")]
    public ArmController controller;

    [Header("Ligne")]
    public Vector3 startPoint = new Vector3(10f, 0f, 10f);
    public Vector3 endPoint = new Vector3(30f, 0f, 30f);

    [Header("Temps")]
    public float duration = 5f;

    [Header("Départ")]
    public float startTolerance = 0.5f;

    float t = 0f;
    bool playing = false;
    bool approaching = false;
    bool drawing = false;

    LineRenderer lr;
    Vector3 drawingStartPosition;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.useWorldSpace = true;
        lr.loop = false;
        lr.positionCount = 0;
        lr.widthMultiplier = 0.1f;
        lr.material = new Material(Shader.Find("Sprites/Default"));

        drawingStartPosition = startPoint;

        playing = false;
        approaching = false;
        drawing = false;
    }

    void Update()
    {
        if (!playing || controller == null)
            return;

        controller.slider = false;

        if (approaching)
        {
            controller.coordonnees = drawingStartPosition;

            if (Vector3.Distance(controller.coordonnees, drawingStartPosition) < startTolerance)
            {
                approaching = false;
                drawing = true;
                t = 0f;
                lr.positionCount = 0;
            }
            return;
        }

        if (!drawing)
            return;

        t += Time.deltaTime / duration;
        t = Mathf.Clamp01(t);

        Vector3 p = Vector3.Lerp(startPoint, endPoint, t);

        controller.coordonnees = p;

        lr.positionCount++;
        lr.SetPosition(lr.positionCount - 1, p);

        if (t >= 1f)
        {
            playing = false;
            drawing = false;
        }
    }

    public void StartDrawing()
    {
        playing = true;
        approaching = true;
        drawing = false;
        t = 0f;

        if (lr != null)
            lr.positionCount = 0;
    }
}
