using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataSave
{

    public static void SaveShop(ShopScript shop)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "savedata.sv");
        FileStream stream = new FileStream(path, FileMode.Create);

        DataStore data = new DataStore(shop);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveDiscovery(ShipMovement_D ship)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "savedata.sv");
        FileStream stream = new FileStream(path, FileMode.Create);

        DataStore data = new DataStore(ship);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveChallenge(MaterialSpawn challenge)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "savedata.sv");
        FileStream stream = new FileStream(path, FileMode.Create);

        DataStore data = new DataStore(challenge);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveGO(GameOver go)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "savedata.sv");
        FileStream stream = new FileStream(path, FileMode.Create);

        DataStore data = new DataStore(go);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static DataStore LoadData()
    {
        string path = Path.Combine(Application.persistentDataPath, "savedata.sv");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DataStore data = formatter.Deserialize(stream) as DataStore;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
