using UnityEngine;

public class Splitable : MonoBehaviour
{
    public float spreadFactor = 0.3f;

    void Split()
    {
        foreach (Transform child in transform)
        {
            GameObject model = child.GetChild(0).gameObject;

            Vector3 randomVector = Vector3.ClampMagnitude(Random.insideUnitSphere * 100, spreadFactor);
            model.transform.position += new Vector3(randomVector.x, randomVector.y, randomVector.z);
        }
    }
}
