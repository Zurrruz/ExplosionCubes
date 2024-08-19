using UnityEngine;

public class Decay : MonoBehaviour
{
    [SerializeField] private int _chance;
    [SerializeField] ObjectFactory _objectFactory;

    private int _minChance = 0;
    private int _maxChance = 100;

    public bool CanAppear()
    {
        int chance = UserUtils.GenerateRandomNumber(_minChance, _maxChance);

        if (chance < _chance)
            return true;
        else
            return false;
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
