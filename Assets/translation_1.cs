using UnityEngine;

public class translation_1 : MonoBehaviour
{
    public float q3 = 20f;
    public Transform visuel;

    private Vector3 initialPos;

    void Start()
    {
        initialPos = transform.localPosition;

        if (visuel == null)
            Debug.LogError("❌ visuel est NULL sur " + gameObject.name);
    }

    void Update()
    {
        transform.localPosition = initialPos + new Vector3(0, 0, q3);

        if (visuel != null)
        {
            float safeQ3 = Mathf.Max(q3, 20f);
            visuel.localScale = new Vector3(1f, 1f, safeQ3);
            visuel.localPosition = Vector3.zero;
        }
    }
}