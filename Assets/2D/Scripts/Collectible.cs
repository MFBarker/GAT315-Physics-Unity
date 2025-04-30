using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public enum eType
{ 
    Coin,
    Gem,
    Key
}

[RequireComponent(typeof(Collider2D))]
public class Collectible : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] public eType type;
    [SerializeField] public IntDataSO Score;
    [SerializeField] public int val = 0;
    [SerializeField] public bool destroyImmediately;

    [Header("Input")]
    [SerializeField] public InputActionReference interactInput;
    [SerializeField] public EventChannelSO interactEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (type)
        {
            case eType.Coin:
                Score.Value += val;
                break;
            case eType.Gem:
                Score.Value += val;
                break;
            case eType.Key:
                //
                break;
        }

        if (destroyImmediately) Destroy(this.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (type == eType.Key) 
        {
            if (interactInput != null && interactInput.action.IsPressed())
            {
                interactEvent.Raise();
                Destroy(this.gameObject);
            }
            
        }
    }

}

//Custom Editor ()
//[CustomEditor(typeof(Collectible))]
//public class CollectibleEditor : Editor
//{
//    void OnInspectorGUI()
//    {
//        // the match object
//        Collectible collectible = (Collectible)target;

//        // display dropdown for gamemodes
//        collectible.type = (eType)EditorGUILayout.EnumPopup("Gamemode", collectible.type);
//        collectible.destroyImmediately = EditorGUILayout.("Gamemode", collectible.type);

//        //Score Objects
//        if (collectible.type == eType.Coin || collectible.type == eType.Gem)
//        {
//            collectible.val = EditorGUILayout.IntField("Value", collectible.val);
//        }

//        // Key
//        if (collectible.type == eType.Key)
//        {
//            collectible.interactInput = EditorGUILayout.(collectible.interactInput);
//        }
//    }
//}