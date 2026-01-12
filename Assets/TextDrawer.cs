using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class LetterByLetterDrawer : MonoBehaviour
{
    [Header("Robot")]
    public ArmController controller;

    [Header("Texte")]
    public string word = "ENSISA";
    public float letterSpacing = 6f;
    public float durationPerSegment = 0.2f;
    public float penUpHeight = 15f;
    public Vector3 startPosition = new Vector3(10f, 10f, 10f);

    LineRenderer lr;
    List<Vector3> currentLetterPoints = new List<Vector3>();
    int currentPoint = 0;
    int currentLetterIndex = 0;
    float t = 0f;
    bool drawing = false;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.useWorldSpace = true;
        lr.loop = false;
        lr.widthMultiplier = 0.1f;
        lr.material = new Material(Shader.Find("Sprites/Default"));
    }

    void Update()
    {
        if (!drawing || controller == null || currentLetterPoints.Count == 0)
            return;

        Vector3 start = currentLetterPoints[currentPoint];
        Vector3 end = currentLetterPoints[Mathf.Min(currentPoint + 1, currentLetterPoints.Count - 1)];

        t += Time.deltaTime / durationPerSegment;
        t = Mathf.Clamp01(t);

        Vector3 p = Vector3.Lerp(start, end, t);
        controller.coordonnees = p;

        // On ajoute le point au LineRenderer SANS effacer les anciens
        lr.positionCount++;
        lr.SetPosition(lr.positionCount - 1, p);

        if (t >= 1f)
        {
            t = 0f;
            currentPoint++;

            if (currentPoint < currentLetterPoints.Count - 1)
            {
                float dist = Vector3.Distance(currentLetterPoints[currentPoint], end);
                if (dist > 2f)
                {
                    controller.coordonnees = new Vector3(
                        currentLetterPoints[currentPoint].x,
                        penUpHeight,
                        currentLetterPoints[currentPoint].z
                    );
                }
            }
        }

        if (currentPoint >= currentLetterPoints.Count - 1)
        {
            DrawNextLetter();
        }
    }

    public void StartDrawing()
    {
        lr.positionCount = 0; // On efface seulement au début du mot
        currentLetterIndex = 0;
        drawing = true;
        DrawNextLetter();
    }

    void DrawNextLetter()
    {
        if (currentLetterIndex >= word.Length)
        {
            drawing = false;
            return;
        }

        char letter = word[currentLetterIndex];

        // Décalage local de la lettre
        Vector3 localOffset = new Vector3(currentLetterIndex * letterSpacing, 0, 0);

        // On génère les points de la lettre
        currentLetterPoints = new List<Vector3>(GetLetterPoints(letter, localOffset));

        // On applique startPosition UNE SEULE FOIS
        for (int i = 0; i < currentLetterPoints.Count; i++)
            currentLetterPoints[i] += startPosition;

        currentPoint = 0;
        t = 0f;

        currentLetterIndex++;

        // On lève le stylo avant d'aller au premier point
        controller.coordonnees = new Vector3(
            currentLetterPoints[0].x,
            penUpHeight,
            currentLetterPoints[0].z
        );
    }

    Vector3[] GetLetterPoints(char letter, Vector3 offset)
    {
        float w = 2f;
        float h = 5f;

        switch (char.ToUpper(letter))
        {
            case 'E':
                return new Vector3[]
                {
                    offset,
                    offset + new Vector3(0,h,0),
                    offset + new Vector3(w, h,0),
                    offset + new Vector3(0,h/2,0),
                    offset + new Vector3(w*0.8f,h/2,0),
                    offset + new Vector3(0,0,0),
                    offset + new Vector3(w,0,0)
                };

            case 'N':
                return new Vector3[]
                {
                    offset,
                    offset + new Vector3(0,h,0),
                    offset + new Vector3(w,h,0),
                    offset + new Vector3(0,0,0),
                    offset + new Vector3(w,0,0)
                };

            case 'S':
                return new Vector3[]
                {
                    offset + new Vector3(w, h, 0),
                    offset,
                    offset + new Vector3(w, 0, 0),
                    offset + new Vector3(0, h, 0)
                };

            case 'I':
                return new Vector3[]
                {
                    offset + new Vector3(w/2, 0, 0),
                    offset + new Vector3(w/2, h, 0)
                };

            case 'A':
                return new Vector3[]
                {
                    offset + new Vector3(0,0,0),
                    offset + new Vector3(w/2,h,0),
                    offset + new Vector3(w,0,0),
                    offset + new Vector3(w*0.25f,h/2,0),
                    offset + new Vector3(w*0.75f,h/2,0)
                };

            default:
                return new Vector3[] { offset };
        }
    }
}
