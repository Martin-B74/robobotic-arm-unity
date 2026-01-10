using UnityEngine;

public class pencil : MonoBehaviour
{
    public float B = 1.5f;

    void Update()
    {
        float safeB = Mathf.Max(B, 0.01f);
        transform.localScale = new Vector3(1f, safeB * 2f, 1f);
    }
}
