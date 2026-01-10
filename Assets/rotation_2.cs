using UnityEngine;

public class rotation_2 : MonoBehaviour {
    public float q2 = 0f;
    public float A = 10f;

    void Update()
    {
        transform.localPosition = new Vector3(0f, A, 0f);
        transform.localEulerAngles = new Vector3(q2, 0f, 0f);
    }
}