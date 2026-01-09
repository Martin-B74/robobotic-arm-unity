using UnityEngine;
using UnityEngine.UI;

public class ArmController : MonoBehaviour
{
    public Transform rotation1;     // Y
    public Transform rotation2;     // X
    public Transform translation1;  // Z
    public Transform rotation3;     // X
    public Transform translation2;  // Y

    public Slider rotation1Slider;
    public Slider rotation2Slider;
    public Slider translation1Slider;
    public Slider rotation3Slider;
    public Slider translation2Slider;

    void Update()
    {
        rotation1.localEulerAngles = new Vector3(0, rotation1Slider.value, 0);
        rotation2.localEulerAngles = new Vector3(rotation2Slider.value, 0, 0);
        translation1.localPosition = new Vector3(
            translation1.localPosition.x,
            translation1.localPosition.y,
            translation1Slider.value
        );
        rotation3.localEulerAngles = new Vector3(rotation3Slider.value, 0, 0);
        translation2.localPosition = new Vector3(
            translation2.localPosition.x,
            translation2Slider.value,
            translation2.localPosition.z
        );
    }
}
