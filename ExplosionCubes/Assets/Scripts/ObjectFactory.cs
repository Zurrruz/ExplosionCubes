using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    [SerializeField] private Detonator _cube;
    [SerializeField] private int _minNumberCreated;
    [SerializeField] private int _maxNumberCreated;
    [SerializeField] private int _reducingSize;
    [SerializeField] private int _reducingChanceDecay;

    public void GenerateObjects(Transform transform, int chanceDecay)
    {
        Detonator detonatorObject;

        int numberObjectCreated = Random.Range(_minNumberCreated, _maxNumberCreated + 1);

        for (int i = 0; i < numberObjectCreated; i++)
        {
            detonatorObject = Instantiate(_cube, transform.position, Quaternion.identity);
            detonatorObject.transform.localScale = transform.localScale / _reducingSize;

            detonatorObject.Initializes(chanceDecay / _reducingChanceDecay);
        }
    }
}
