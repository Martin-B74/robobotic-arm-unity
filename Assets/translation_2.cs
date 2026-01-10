using UnityEngine;

public class translation_2 : MonoBehaviour {
    public float q5 = 10f;
    private Vector3 initialPos;
    private Transform visuel;
    private Transform pencil;

    void Start()
    {
        initialPos = transform.localPosition;
        visuel = transform.Find("Translation2Visuel");
        pencil = transform.Find("Pencil");
    }

    void Update()
    {
        transform.localPosition = initialPos + new Vector3(0, -q5, 0);
        visuel.localScale = new Vector3(visuel.localScale.x, q5, visuel.localScale.z);
        visuel.localPosition = new Vector3(0, q5/2f, 0);
        pencil.localPosition = Vector3.zero;
    }
}