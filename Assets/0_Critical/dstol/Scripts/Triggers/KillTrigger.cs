using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        bool isCharacter = other.TryGetComponent<Character>(out Character character);
        if(isCharacter)
        {
            character.Die();
        }
    }
}
