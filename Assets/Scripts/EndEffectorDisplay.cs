using UnityEngine;
using UnityEngine.UI;

public class EndEffectorDisplay : MonoBehaviour
{
    public Transform pencil;
    public Text unityPositionText;
    public Text modelPositionText;

    public GameObject pen;
    private pencil scriptPencil;
    private Vector3 offsetB;

    public ArmController controller;

    public float l1 = 10f, l2 = 10f, l3 = 10f;

    void Start()
    {
        pen = GameObject.Find("Pencil");
        scriptPencil = pen.GetComponent<pencil>();
    }

    void Update()
    {
        offsetB = new Vector3(0f, scriptPencil.B, 0f);

        Vector3 unityPos = pencil.position - offsetB;
        unityPositionText.text = $"Unity : {unityPos.ToString("F3")}";

        Vector3 modelPos = ComputeModelPosition();
        modelPositionText.text = $"Modèle : {modelPos.ToString("F3")}";
    }

    Vector3 ComputeModelPosition()
    {
        float q1 = controller.Q1;
        float q2 = controller.Q2;
        float q3 = controller.Q3;
        float q4 = controller.Q4;
        float q5 = controller.Q5;

        // Exemple simplifié — à remplacer par ton vrai modèle
        float x = l2 * Mathf.Cos(q1 * Mathf.Deg2Rad);
        float y = l1 + q3;
        float z = l2 * Mathf.Sin(q1 * Mathf.Deg2Rad);

        return new Vector3(x, y, z);
    }
}
