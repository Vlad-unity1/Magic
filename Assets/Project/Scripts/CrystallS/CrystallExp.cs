using UnityEngine;

public class CrystallExp : MonoBehaviour
{
    public int Exp = 5; // Решить с этим полем

    public void OnInteract()
    {
        Destroy(gameObject);
    }

}
