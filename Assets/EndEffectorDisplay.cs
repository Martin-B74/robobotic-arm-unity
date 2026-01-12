using UnityEngine;
using UnityEngine.UI;

public class EndEffectorDisplay : MonoBehaviour
{
    public Transform pencil;
    public Text unityPositionText;
    public Text modelPositionText;

    public GameObject rot2;
    private rotation_2 scriptRot2;

    public GameObject rot3;
    private rotation_3 scriptRot3;

    public GameObject pen;
    private pencil scriptPencil;

    public ArmController controller;

    void Start()
    {
        rot2 = GameObject.Find("Rotation2");
        scriptRot2 = rot2.GetComponent<rotation_2>();

        rot3 = GameObject.Find("Rotation3");
        scriptRot3 = rot3.GetComponent<rotation_3>();

        pen = GameObject.Find("Pencil");
        scriptPencil = pen.GetComponent<pencil>();
    }

    void Update()
    {
        Vector3 offsetB = new Vector3(0f, scriptPencil.B * Mathf.Cos((scriptRot2.q2 + scriptRot3.q4) * Mathf.Deg2Rad), 0f);

        Vector3 unityPos = pencil.position + offsetB;
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

        float A = scriptRot2.A;
        float B = scriptPencil.B;

        float L = q5 + B;
        float R = q3 * Mathf.Sin(q2 * Mathf.Deg2Rad) + L * Mathf.Sin((q2 + q4) * Mathf.Deg2Rad);

        float x = R * Mathf.Sin(q1 * Mathf.Deg2Rad);
        float y = A + q3 * Mathf.Cos(q2 * Mathf.Deg2Rad) + L * Mathf.Cos((q2 + q4) * Mathf.Deg2Rad) + 10f;
        float z = R * Mathf.Cos(q1 * Mathf.Deg2Rad);

        return new Vector3(x, y, z);
    }
}
