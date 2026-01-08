using UnityEngine;
using UnityEngine.UI;

public class ArmController : MonoBehaviour
{
    [Header("Transforms du robot")]
    public Transform translation1;   // montée/descente
    public Transform rotation1;      // rotation base
    public Transform translation2;   // avance/recul
    public Transform rotation2;      // articulation bras
    public Transform translation3;   // extension finale

    [Header("Sliders")]
    public Slider translation1Slider;
    public Slider rotation1Slider;
    public Slider translation2Slider;
    public Slider rotation2Slider;
    public Slider translation3Slider;

    void Update()
    {
        // Translation verticale (Y)
        translation1.localPosition = new Vector3(
            translation1.localPosition.x,
            translation1Slider.value,
            translation1.localPosition.z
        );

        // Rotation de la base (Y)
        rotation1.localEulerAngles = new Vector3(
            0,
            rotation1Slider.value,
            0
        );

        // Translation avant/arrière (Z)
        translation2.localPosition = new Vector3(
            translation2.localPosition.x,
            translation2.localPosition.y,
            translation2Slider.value
        );

        // Rotation du bras (X)
        rotation2.localEulerAngles = new Vector3(
            rotation2Slider.value,
            0,
            0
        );

        // Extension finale (Y)
        translation3.localPosition = new Vector3(
            translation3.localPosition.x,
            translation3Slider.value,
            translation3.localPosition.z
        );
    }
}
