using UnityEngine;
using UnityEngine.Events;

public class Detonator : MonoBehaviour
{
    [SerializeField] private int _chanceDecay;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public static event UnityAction<Transform, int> ActionExplosion;

    private int _minChance = 0;
    private int _maxChance = 100;

    private void OnMouseUpAsButton()
    {
        if (CanAppear())
            ActionExplosion?.Invoke(transform, _chanceDecay);

        Destroy(gameObject);
    }

    public bool CanAppear()
    {
        int chance = Random.Range(_minChance, _maxChance);

        return chance < _chanceDecay;
    }

    public void SetChance(int chance)
    {
        _chanceDecay = chance;
    }

    public void Explode()
    {
        GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}
