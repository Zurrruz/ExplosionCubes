using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ChangeColor : MonoBehaviour
{
    private void Start()
    {
        PaintRandom();
    }

    private void PaintRandom()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(
            Random.Range(0, 1f),
            Random.Range(0, 1f),
            Random.Range(0, 1f));
    }
}
