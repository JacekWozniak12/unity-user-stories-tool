using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Example", menuName = "Example", order = 0)]
public class DynamicNameChangeExample : ScriptableObject
{
    public static int MAXIMAL_DUPLICANTS_AMOUNT = 9999;

    public string Name;

    public void OnAwake()
    {
        if (Name == "" || Name == null) Name = "example";
    }

    public void OnValidate()
    {
        if (Name == "") Name = "example";
#if UNITY_EDITOR
        name = Name;
        string folderName = Name;
        string test = "";
        int i = 0;
        do
        {
            test = AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(this), folderName);
            i++;
            folderName = $"{Name} ({i})";
        }
        while (test.Trim().Length > 1 && i < MAXIMAL_DUPLICANTS_AMOUNT);
    }
#endif
}
