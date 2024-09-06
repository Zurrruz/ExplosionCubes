using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorScheme : MonoBehaviour
{
    private void Start()
    {
        PaintRandom();
    }

    private void PaintRandom()
    {
        GetComponent<Renderer>().material.color = new UnityEngine.Color(
            Random.Range(0, 1f),
            Random.Range(0, 1f),
            Random.Range(0, 1f));
    }
}
