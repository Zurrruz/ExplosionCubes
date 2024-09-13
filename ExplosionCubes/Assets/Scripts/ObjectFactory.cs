using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    [SerializeField] private Detonator _cube;
    [SerializeField] private int _minNumberCreated;
    [SerializeField] private int _maxNumberCreated;
    [SerializeField] private int _reducingSize;
    [SerializeField] private int _reducingChanceDecay;
    [SerializeField] private float _increasingExplosionRadius;
    [SerializeField] private float _increasingExplosionForce;

    public void GenerateObjects(Detonator detonator)
    {
        Detonator newDetonator;

        int newChance = detonator.ChanceDecay / _reducingChanceDecay;
        float newExplosionRadius = detonator.ExplosionRadius + _increasingExplosionRadius;
        float newExplosionForce = detonator.ExplosionForce + _increasingExplosionForce;

        int numberObjectCreated = Random.Range(_minNumberCreated, _maxNumberCreated + 1);

        for (int i = 0; i < numberObjectCreated; i++)
        {
            newDetonator = Instantiate(_cube, detonator.transform.position, Quaternion.identity);
            newDetonator.transform.localScale = detonator.transform.localScale / _reducingSize;

            newDetonator.Initializes(newChance, newExplosionRadius, newExplosionForce);
        }
    }
}
