using UnityEngine;

public class translation_1 : MonoBehaviour
{
    public float q3 = 20f;

    private Transform visuel;
    private Vector3 initialPos;

    void Start()
    {
        initialPos = transform.localPosition;
        visuel = transform.Find("Translation1Visuel");
    }

    void Update() {
        transform.localPosition = initialPos + new Vector3(0, q3, 0);
        visuel.localScale = new Vector3(visuel.localScale.x, q3, visuel.localScale.z);
        visuel.localPosition = new Vector3(0, -q3/2f, 0);
    }
}