using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadData : MonoBehaviour
{
    void Start()
    {
        // Создаем данные для сохранения
        Data dataToSave = new Data { Name = "Alice", Age = 30 };

        // Сохраняем данные в JSON файл
        SaveDataToJson("data.json", dataToSave);

        // Загружаем данные из JSON файла
        Data loadedData = ReadDataFromJson("data.json");

        // Выводим загруженные данные в консоль
        Debug.Log($"Name: {loadedData.Name}, Age: {loadedData.Age}");
    }

    static void SaveDataToJson(string fileName, Data data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(fileName, json);

        Debug.Log($"Data saved to {fileName}");
    }

    static Data ReadDataFromJson(string fileName)
    {
        string json = File.ReadAllText(fileName);
        return JsonUtility.FromJson<Data>(json);
    }
}

[System.Serializable]
public class Data
{
    public string Name;
    public int Age;
}

