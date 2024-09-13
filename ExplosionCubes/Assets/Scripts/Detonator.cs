using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Detonator : MonoBehaviour
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

    public void Initializes(int chance, float explosionRadius, float explosionForce)
    {
        setParameters(chance , explosionRadius, explosionForce);
        Explode();
    }

    private void setParameters(int chance, float explosionRadius, float explosionForce)
    {
        _chanceDecay = chance;
        _explosionRadius = explosionRadius;
        _explosionForce = explosionForce;
    }

    public void PushAway()
    {
        foreach(Rigidbody explodebleObject in GetExplodableObjects())
            explodebleObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }

    private void Explode()
    {
        GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits) 
            if(hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
