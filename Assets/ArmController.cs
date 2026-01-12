using UnityEngine;
using UnityEngine.UI;

public class ArmController : MonoBehaviour
{
    public bool slider = true;

    public Vector3 coordonnees = new Vector3(20f, 0f, 20f);

    public GameObject rot1;
    public GameObject rot2;
    public GameObject trans1;
    public GameObject rot3;
    public GameObject trans2;
    public GameObject pen;

    public Slider slider1;
    public Slider slider2;
    public Slider slider3;
    public Slider slider4;
    public Slider slider5;

    private rotation_1 scriptRot1;
    private rotation_2 scriptRot2;
    private translation_1 scriptTrans1;
    private rotation_3 scriptRot3;
    private translation_2 scriptTrans2;
    private pencil scriptPencil;

    private Vector3 Xmouvement = new Vector3(0.1f, 0f, 0f);
    private Vector3 Zmouvement = new Vector3(0f, 0f, 0.1f);

    void Start()
    {
        rot1 = GameObject.Find("Rotation1");
        rot2 = GameObject.Find("Rotation2");
        trans1 = GameObject.Find("Translation1");
        rot3 = GameObject.Find("Rotation3");
        trans2 = GameObject.Find("Translation2");
        pen = GameObject.Find("Pencil");

        scriptRot1 = rot1.GetComponent<rotation_1>();
        scriptRot2 = rot2.GetComponent<rotation_2>();
        scriptTrans1 = trans1.GetComponent<translation_1>();
        scriptRot3 = rot3.GetComponent<rotation_3>();
        scriptTrans2 = trans2.GetComponent<translation_2>();
        scriptPencil = pen.GetComponent<pencil>();

        slider1.value = scriptRot1.q1;
        slider2.value = scriptRot2.q2;
        slider3.value = scriptTrans1.q3;
        slider4.value = scriptRot3.q4;
        slider5.value = scriptTrans2.q5;
    }

    void Update()
    {
        if (slider) {
            scriptRot1.q1 = slider1.value;
            scriptRot2.q2 = slider2.value;
            scriptTrans1.q3 = slider3.value;
            scriptRot3.q4 = slider4.value;
            scriptTrans2.q5 = slider5.value;
        } else {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                coordonnees += Xmouvement;
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                coordonnees -= Xmouvement;
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                coordonnees += Zmouvement;
            }
            if (Input.GetKey(KeyCode.UpArrow)) {
                coordonnees -= Zmouvement;
            }
            MGI(coordonnees);
        }
    }

    void MGI(Vector3 coordonnees)
    {
        Vector3 pos = coordonnees - scriptRot1.transform.position;

        float L = scriptTrans2.q5 + scriptPencil.B;

        float q1 = Mathf.Atan2(pos.x, pos.z) * Mathf.Rad2Deg;

        float R = Mathf.Sqrt(pos.x * pos.x + pos.z * pos.z);

        float dy = pos.y + L - scriptRot2.A;

        float q3 = Mathf.Sqrt(R * R + dy * dy);

        float q2 = Mathf.Atan2(R, dy) * Mathf.Rad2Deg;

        float q4 = 180f - q2;

        scriptRot1.q1 = q1;
        scriptRot2.q2 = q2;
        scriptTrans1.q3 = q3;
        scriptRot3.q4 = q4;
    }
    public float Q1 => scriptRot1.q1;
    public float Q2 => scriptRot2.q2;
    public float Q3 => scriptTrans1.q3;
    public float Q4 => scriptRot3.q4;
    public float Q5 => scriptTrans2.q5;


}
