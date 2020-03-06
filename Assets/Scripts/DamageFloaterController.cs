using UnityEngine;

public class DamageFloaterController : MonoBehaviour
{
    public float destroyTime = 3f;
    public Vector3 offset = new Vector3(0, 2, 0);
    public Vector3 RandomIntensity = new Vector3(0.5f, 0, 0);

    void Start()
    {
        Destroy(gameObject, destroyTime);
        transform.localPosition += offset;
        transform.localPosition += new Vector3(Random.Range(-RandomIntensity.x, RandomIntensity.x),
        Random.Range(-RandomIntensity.y, RandomIntensity.y),
        Random.Range(-RandomIntensity.z, RandomIntensity.z));
    }
}
