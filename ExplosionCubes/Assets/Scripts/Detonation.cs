using UnityEngine;

public class Detonation : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ObjectFactory _objectFactory;

    private void OnMouseUpAsButton()
    {
        Destroy(gameObject);        
    }

    public void Explode()
    {
        gameObject.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}
