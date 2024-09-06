using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    [SerializeField] private Rigidbody _gameObject;
    [SerializeField] private int _minNumberCreated;
    [SerializeField] private int _maxNumberCreated;
    [SerializeField] private int _reducingSize;
    [SerializeField] private int _reducingChanceDecay;

    public void GenerateObject(Transform transform, int chanceDecay)
    {
        Rigidbody gameObject;

        int numberObjectCreated = Random.Range(_minNumberCreated, _maxNumberCreated);

        for (int i = 0; i < numberObjectCreated; i++)
        {
            gameObject = Instantiate(_gameObject, transform.position, Quaternion.identity);
            gameObject.transform.localScale = transform.localScale / _reducingSize;

            gameObject.TryGetComponent(out DecayObject decay);
            decay.ChangeChance(chanceDecay / _reducingChanceDecay);

            gameObject.TryGetComponent(out Detonation detonation);
            detonation.Explode();
        }
    }
}
