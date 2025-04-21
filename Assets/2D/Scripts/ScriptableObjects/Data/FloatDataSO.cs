using UnityEngine;

[CreateAssetMenu(fileName = "FloatData", menuName = "Scriptable Objects/Data/FloatData")]
public class FloatDataSO : ValueData<float>
{
    public static implicit operator float(FloatDataSO variable)
    {
        return variable != null ? variable.Value : 0;
    }
}
