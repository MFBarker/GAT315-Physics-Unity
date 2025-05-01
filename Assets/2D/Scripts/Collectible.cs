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

//Custom Editor
/*
 * Custom editor
 * 
 * links:
 * https://docs.unity3d.com/ScriptReference/EditorGUILayout.html
 * https://stackoverflow.com/questions/79446272/how-do-i-show-certain-variables-depending-on-my-enum-c
 
 */
[CustomEditor(typeof(Collectible))]
public class CollectibleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Collectible collectible = (Collectible)target;

        collectible.type = (eType)EditorGUILayout.EnumPopup("Type", collectible.type);
        collectible.destroyImmediately = EditorGUILayout.Toggle("Destroy Immediately",collectible.destroyImmediately);

        //Score Objects (Coin, Gem)
        if (collectible.type == eType.Coin || collectible.type == eType.Gem)
        {
            collectible.val = EditorGUILayout.IntField("Value", collectible.val);
            collectible.Score = (IntDataSO) EditorGUILayout.ObjectField("Score Data",collectible.Score,typeof(IntDataSO),true);
        }

        // Key
        if (collectible.type == eType.Key)
        {
            collectible.interactInput = (InputActionReference) EditorGUILayout.ObjectField("Interact Input",collectible.interactInput,typeof(InputActionReference),true);
            collectible.interactEvent = (EventChannelSO) EditorGUILayout.ObjectField("Interact Event",collectible.interactEvent,typeof(EventChannelSO),true);
        }
    }
}