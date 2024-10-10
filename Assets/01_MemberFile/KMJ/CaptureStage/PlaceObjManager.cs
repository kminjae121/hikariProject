using System.IO;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class PlaceObjData
{
    public string spritePath;
    public string name;

    public string prefabPath;

    // PlaceObjSO 데이터를 PlaceObjData로 변환했음
    public PlaceObjData(PlaceObjSO placeObj)
    {
        spritePath = AssetDatabase.GetAssetPath(placeObj.sprite);
        name = placeObj.name;
        prefabPath = AssetDatabase.GetAssetPath(placeObj.prefab);
    }
}

public static class PlaceObjManager
{
    private static string filePath = Application.persistentDataPath + "/placeObjData.json";

    public static void SavePlaceObj(PlaceObjSO placeObj)
    {
        PlaceObjData data = new PlaceObjData(placeObj);
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(filePath, json);
        Debug.Log($"파일 세이브됨 {filePath}");
    }

    public static PlaceObjSO LoadPlaceObj()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlaceObjData data = JsonUtility.FromJson<PlaceObjData>(json);

            PlaceObjSO loadedPlaceObj = ScriptableObject.CreateInstance<PlaceObjSO>();
            loadedPlaceObj.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(data.spritePath);
            loadedPlaceObj.name = data.name;
            loadedPlaceObj.prefab = AssetDatabase.LoadAssetAtPath<GameObject>(data.prefabPath);

            Debug.Log($"파일 로드됨 {filePath}");
            return loadedPlaceObj;
        }
        else
        {
            Debug.LogError("세이브 파일을 찾을 수 없음");
            return null;
        }
    }
}
