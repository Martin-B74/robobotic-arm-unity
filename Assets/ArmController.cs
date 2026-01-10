using UnityEngine;
using UnityEngine.UI;

public class RobotController : MonoBehaviour
{
    public rotation_1 rot1;
    public rotation_2 rot2;
    public translation_1 trans1;
    public rotation_3 rot3;
    public translation_2 trans2;

    public Slider slider1;
    public Slider slider2;
    public Slider slider3;
    public Slider slider4;
    public Slider slider5;

    void Start()
    {
        slider1.value = rot1.q1;
        slider2.value = rot2.q2;
        slider3.value = trans1.q3;
        slider4.value = rot3.q4;
        slider5.value = trans2.q5;
    }

    void Update()
    {
        rot1.q1 = slider1.value;
        rot2.q2 = slider2.value;
        trans1.q3 = slider3.value;
        rot3.q4 = slider4.value;
        trans2.q5 = slider5.value;
    }
}
