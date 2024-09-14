using UnityEngine;

public class Specifications : MonoBehaviour
{
    [SerializeField] private int _chanceDecay;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private int _minChance = 0;
    private int _maxChance = 100;

    public int ChanceDecay => _chanceDecay;
    public float ExplosionRadius => _explosionRadius;
    public float ExplosionForce => _explosionForce;

    public bool CanAppear()
    {
        int chance = Random.Range(_minChance, _maxChance);

        return chance < _chanceDecay;
    }

    public void SetParameters(int chance, float explosionRadius, float explosionForce)
    {
        _chanceDecay = chance;
        _explosionRadius = explosionRadius;
        _explosionForce = explosionForce;
    }
}
