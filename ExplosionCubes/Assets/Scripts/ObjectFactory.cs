using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private int _minNumberCreated;
    [SerializeField] private int _maxNumberCreated;
    [SerializeField] private int _reducingSize;
    [SerializeField] private int _reducingChanceDecay;

    public void GenerateObject(Transform transform, int chanceDecay)
    {
        GameObject gameObject;

        int numberObjectCreated = UserUtils.GenerateRandomNumber(_minNumberCreated, _maxNumberCreated);

        for (int i = 0; i < numberObjectCreated; i++)
        {
            gameObject = Instantiate(_gameObject, transform.position, Quaternion.identity);
            gameObject.transform.localScale = transform.localScale / _reducingSize;

            Decay decay = gameObject.GetComponent<Decay>();
            decay.ChangeChance(chanceDecay / _reducingChanceDecay);

            gameObject.GetComponent<Detonation>().Explode();
        }
    }
}
