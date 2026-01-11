using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public RobotController controller;
    public Transform pencil;

    public Vector3 startPoint = new Vector3(10f, 0f, 10f);
    public Vector3 endPoint = new Vector3(30f, 0f, 30f);
    public float duration = 5f;

    public Vector3 drawingStartPosition;
    public float startTolerance = 0.1f;

    float t = 0f;
    bool playing = false;
    bool drawing = false;

    LineRenderer lr;
    Vector3 lastPosition;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        if (lr != null)
            lr.positionCount = 0;

        lastPosition = Vector3.zero;
        Play();
    }

    void Update()
    {
        if (!playing || controller == null) return;

        controller.slider = false;

        bool readyToDraw = Vector3.Distance(pencil.position, drawingStartPosition) < startTolerance;

        if (!drawing && readyToDraw)
        {
            drawing = true;
            t = 0f;
            if (lr != null) lr.positionCount = 0;
        }

        if (!drawing)
        {
            controller.coordonnees = drawingStartPosition;
            return;
        }

        t += Time.deltaTime / duration;
        if (t > 1f)
        {
            t = 1f;
            playing = false;
        }

        Vector3 p = Vector3.Lerp(startPoint, endPoint, t);
        controller.coordonnees = p;

        if (lr != null)
        {
            lr.positionCount++;
            lr.SetPosition(lr.positionCount - 1, p); 
        }
    }

    public void Play()
    {
        t = 0f;
        playing = true;
        drawing = false;

        if (lr != null)
            lr.positionCount = 0;
    }
}
