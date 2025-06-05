using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
public enum Select
{
    auto,
    manual
}
public enum Type
{
    Easy = 0,
    Medium = 1,
    Hard = 2,
    Extreme = 3
}

public class Brick : MonoBehaviour
{
    //variables
    public Type type;
    public Select select;
    int hitsLeft;
    int scoreVal;

    [SerializeField] public Sprite[] sprites; //indexes match type
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (select == Select.auto)
        {
            //random select type
            type = (Type)Random.Range(0, 4);
        }
        //switch type
        switch (type)
        {
            //set info
            case Type.Easy:
                hitsLeft = 1;
                scoreVal = 100;
                break;
            case Type.Medium:
                hitsLeft = 2;
                scoreVal = 200;
                break;
            case Type.Hard:
                hitsLeft = 3;
                scoreVal = 300;
                break;
            case Type.Extreme:
                hitsLeft = 4;
                scoreVal = 400;
                break;
            default:
                break;
        }
        spriteRenderer.sprite = sprites[(int)type];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitsLeft--;
            if (hitsLeft == 0) 
            {
                Manager.Instance.AddPoints(scoreVal);
                Destroy(gameObject); 
            }
            else spriteRenderer.sprite = sprites[hitsLeft - 1];
        }
    }
}


[CustomEditor(typeof(Brick))]
public class BrickEditor : Editor
{
    SerializedProperty spritesProp;
    public override void OnInspectorGUI()
    {
        spritesProp = serializedObject.FindProperty("sprites");

        Brick brick = (Brick)target;

        brick.select = (Select)EditorGUILayout.EnumPopup("Select", brick.select);

        if (brick.select == Select.manual)
        {
            brick.type = (Type)EditorGUILayout.EnumPopup("Type", brick.type);
        }

        serializedObject.Update();

        EditorGUILayout.PropertyField(spritesProp, new GUIContent("Sprites"), true);

        serializedObject.ApplyModifiedProperties();
    }
}
