using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    [SerializeField] private Specifications _cube;
    [SerializeField] private Detonator _detonator;

    [SerializeField] private int _minNumberCreated;
    [SerializeField] private int _maxNumberCreated;

    [SerializeField] private int _reducingSize;
    [SerializeField] private int _reducingChanceDecay;

    [SerializeField] private float _increasingExplosionRadius;
    [SerializeField] private float _increasingExplosionForce;

    public void GenerateObjects(Specifications specifications)
    {
        Specifications newSpecifications;

        int newChance = specifications.ChanceDecay / _reducingChanceDecay;
        float newExplosionRadius = specifications.ExplosionRadius + _increasingExplosionRadius;
        float newExplosionForce = specifications.ExplosionForce + _increasingExplosionForce;

        int numberObjectCreated = Random.Range(_minNumberCreated, _maxNumberCreated + 1);

        for (int i = 0; i < numberObjectCreated; i++)
        {
            newSpecifications = Instantiate(_cube, specifications.transform.position, Quaternion.identity);
            newSpecifications.transform.localScale = specifications.transform.localScale / _reducingSize;

            newSpecifications.SetParameters(newChance, newExplosionRadius, newExplosionForce);

            _detonator.Explode(newSpecifications, _cube.ExplosionForce, _cube.ExplosionRadius);
        }
    }
}
