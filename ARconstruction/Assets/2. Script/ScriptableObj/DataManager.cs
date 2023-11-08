using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class DataManager : MonoBehaviour
{

    public ObjData objData;

    public string fileName = "";

    [ContextMenu("To Json Data")]//������Ʈ�� �ڵ������ �Լ��� �����ϴ� �޴���ư�� �߰�
    void SaveObjDataToJson()
    {
        string jsonData = JsonUtility.ToJson(objData, true);
        string path = Application.streamingAssetsPath + "/" + fileName + ".json"; //���+�����̸�
        File.WriteAllText(path, jsonData); //��ο� ���̽� ������ ����
        print(path);
    }

    [ContextMenu("From Json Data")]
    void LoadObjDataFromJson()
    {
        string path = Application.dataPath + "/" + fileName + ".json";
        string jsonData = File.ReadAllText(path);
        objData = JsonUtility.FromJson<ObjData>(jsonData);
    }
}
