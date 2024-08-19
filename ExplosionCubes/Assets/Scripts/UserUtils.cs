using UnityEngine;

public class UserUtils 
{
    public static int GenerateRandomNumber(int minValue, int maxValue)
    {
        int s_random = Random.Range(minValue, maxValue);
        return s_random;
    }

    public static float GenerateRandomNumber(float minValue, float maxValue)
    {
        float s_random = Random.Range(minValue, maxValue);
        return s_random;
    }
}
