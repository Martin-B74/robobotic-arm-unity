using UnityEngine;
using UnityEngine.UI;

public class RobotController : MonoBehaviour
{
    public GameObject rot1;
    public GameObject rot2;
    public GameObject trans1;
    public GameObject rot3;
    public GameObject trans2;

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

    void Start()
    {
        rot1 = GameObject.Find("Rotation1");
        rot2 = GameObject.Find("Rotation2");
        trans1 = GameObject.Find("Translation1");
        rot3 = GameObject.Find("Rotation3");
        trans2 = GameObject.Find("Translation2");

        scriptRot1 = rot1.GetComponent<rotation_1>();
        scriptRot2 = rot2.GetComponent<rotation_2>();
        scriptTrans1 = trans1.GetComponent<translation_1>();
        scriptRot3 = rot3.GetComponent<rotation_3>();
        scriptTrans2 = trans2.GetComponent<translation_2>();

        slider1.value = scriptRot1.q1;
        slider2.value = scriptRot2.q2;
        slider3.value = scriptTrans1.q3;
        slider4.value = scriptRot3.q4;
        slider5.value = scriptTrans2.q5;
    }

    void Update()
    {
        scriptRot1.q1 = slider1.value;
        scriptRot2.q2 = slider2.value;
        scriptTrans1.q3 = slider3.value;
        scriptRot3.q4 = slider4.value;
        scriptTrans2.q5 = slider5.value;
    }
}
