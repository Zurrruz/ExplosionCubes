using UnityEngine;

public class DecayObject : MonoBehaviour
{
    [SerializeField] private int _chance;
    [SerializeField] private int _reducingChanceDecay;
    [SerializeField] private ObjectFactory _objectFactory;

    private DecayObject _decayObject;

    private int _minChance = 0;
    private int _maxChance = 100;

    private void Start()
    {
        _decayObject = this;
    }

    public bool CanAppear()
    {
        int chance = Random.Range(_minChance, _maxChance);

        return chance < _chance;
    }

    public void ChangeChance(int chance)
    {
        _chance = chance;
    }

    private void OnMouseUpAsButton()
    {
        if (CanAppear())
            _objectFactory.GenerateObject(transform, _chance);
    }
}
