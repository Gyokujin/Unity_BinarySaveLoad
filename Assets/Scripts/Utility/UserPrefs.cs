
using MemoryPack;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserPrefs
{
    private static readonly Dictionary<string, byte[]> _data;

    private static string Path => $"{Application.persistentDataPath}/{Application.productName}.bin";

    static UserPrefs()
    {
        if (File.Exists(Path))
        {
            byte[] bin = File.ReadAllBytes(Path);
            _data = MemoryPackSerializer.Deserialize<Dictionary<string, byte[]>>(bin);
        }
        else
        {
            _data = new Dictionary<string, byte[]>();
        }
    }

    public static void Save<T>(string key, T value)
    {
        byte[] bin = MemoryPackSerializer.Serialize(value);
        _data[key] = bin;

        byte[] playerDataBin = MemoryPackSerializer.Serialize(_data);
        File.WriteAllBytes(Path, playerDataBin);
    }

    public static T Load<T>(string key, T defaultValue)
    {
        if (!File.Exists(Path)) 
            return defaultValue;

        if (!_data.TryGetValue(key, out byte[] value))
            return default;

        T data = MemoryPackSerializer.Deserialize<T>(value);
        return data;
    }
}