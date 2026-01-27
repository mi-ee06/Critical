using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] blacklist;

    private void OnTriggerEnter(Collider other)
    {
        bool isCharacter = other.TryGetComponent<Character>(out Character character);
        if(isCharacter)
        {
            character.Die();
            return;
        }

        if (!other.CompareTag("Enemy")) return;

        for(int i = 0; i < blacklist.Length; i++)
        {
            if (Root(other.gameObject) == Root(blacklist[i])) return;
        }

        Destroy(Root(other.gameObject));
    }


    public GameObject Root(GameObject input)
    {
        Transform root = input.transform;
        while(root.parent != null)
        {
            root = root.parent;
        }

        return root.gameObject;
    }
}
