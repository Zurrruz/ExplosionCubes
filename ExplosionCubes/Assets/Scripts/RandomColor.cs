using UnityEngine;

public class RandomColor : MonoBehaviour
{
    void Start()
    {
        Change();
    }

    private void Change()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(
            UserUtils.GenerateRandomNumber(0, 1f), 
            UserUtils.GenerateRandomNumber(0, 1f), 
            UserUtils.GenerateRandomNumber(0, 1f));
    }
}
