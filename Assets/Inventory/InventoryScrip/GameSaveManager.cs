using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//二进制序列化程序
using System.Runtime.Serialization.Formatters.Binary;


public class GameSaveManager : MonoBehaviour
{
    public Inventory myInventory;

    public void SaveGame()
    {
        //获得游戏save的目录
        Debug.Log(Application.persistentDataPath);
        if(!Directory.Exists(Application.persistentDataPath + "/game_SaveDate"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_SaveDate");
        }

        //将数据转换为二进制
        BinaryFormatter formatter = new BinaryFormatter();
        //创建一个文件
        FileStream file = File.Create(Application.persistentDataPath + "/game_SaveDate/inventory.txt");
        //myInventory 转化为json格式
        var json = JsonUtility.ToJson(myInventory);
        //以二进制将json写入file(只读)
        formatter.Serialize(file, json);

        file.Close();
    }

    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        //确认文件是否存在
        if(File.Exists(Application.persistentDataPath + "/game_SaveDate/inventory.txt"))
        {
            //引用json文件
            FileStream file = File.Open(Application.persistentDataPath + "/game_SaveDate/inventory.txt", FileMode.Open);
            
            //覆盖重写json
            //Deserialize 反序列化
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), myInventory);
            
            file.Close();
        }
    }
}
