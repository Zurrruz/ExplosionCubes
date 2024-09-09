using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Detonator : MonoBehaviour
{
    [SerializeField] private int _chanceDecay;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private RaycastExample _gameManager;

    private int _minChance = 0;
    private int _maxChance = 100;

    public int ChanceDecay => _chanceDecay;

    public bool CanAppear()
    {
        int chance = Random.Range(_minChance, _maxChance);

        return chance < _chanceDecay;
    }

    public void Initializes(int chance)
    {
        SetChance(chance);
        Explode();
    }

    private void SetChance(int chance)
    {
        _chanceDecay = chance;
    }

    private void Explode()
    {
        GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}
