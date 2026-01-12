using UnityEngine;
using UnityEngine.UI;

public class EndEffectorDisplay : MonoBehaviour
{
    public Transform pencil;
    public Text unityPositionText;
    public Text modelPositionText;

    public GameObject rot2;
    private rotation_2 scriptRot2;

    public GameObject pen;
    private pencil scriptPencil;
    private Vector3 offsetB;

    public ArmController controller;

    void Start()
    {
        rot2 = GameObject.Find("Rotation2");
        scriptRot2 = rot2.GetComponent<rotation_2>();

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

        float x = q3 * Mathf.Sin(q2 * Mathf.Deg2Rad) * Mathf.Cos(q1 * Mathf.Deg2Rad);
        float y = scriptRot2.A + q3 * Mathf.Cos(q2 * Mathf.Deg2Rad) - (q5 + scriptPencil.B) + 10f;
        float z = q3 * Mathf.Sin(q2 * Mathf.Deg2Rad) * Mathf.Sin(q1 * Mathf.Deg2Rad);

        return new Vector3(x, y, z);
    }
}
