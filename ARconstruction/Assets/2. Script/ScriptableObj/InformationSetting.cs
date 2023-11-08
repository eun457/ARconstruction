using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEditor;
using LitJson;
using UnityEngine.Networking;

public class InformationSetting : MonoBehaviour
{
    public static InformationSetting Instance;
    public ObjData objData;

    public string fileName;

    public TextMeshProUGUI textMeshProUGUI;

    [SerializeField] TextMeshProUGUI productName;
    [SerializeField] TextMeshProUGUI productCategory;
    [SerializeField] TextMeshProUGUI productMaterial;
    [SerializeField] TextMeshProUGUI Floor;
    [SerializeField] TextMeshProUGUI objectSize;
    [SerializeField] TextMeshProUGUI workFlow;
    [SerializeField] TextMeshProUGUI startDate;
    [SerializeField] TextMeshProUGUI endDate;
    [SerializeField] TextMeshProUGUI currentStatus;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(Instance);
        }
    }
    void Update()
    {
        productName.text = objData.productName;
        productCategory.text = objData.productCategory;
        productMaterial.text = objData.productMaterial;
        Floor.text = objData.Floor;
        objectSize.text = objData.objectSize;
        workFlow.text = objData.workFlow;
        startDate.text = objData.startDate;
        endDate.text = objData.endDate;
        currentStatus.text = objData.currentStatus;
    }

    /*  public void LoadObjDataFromJson(string fileName)
      {
          string path =  "jar:file://" + Application.streamingAssetsPath + "/" + fileName + ".json";
          textMeshProUGUI.text = path;
          string jsonData = File.ReadAllText(path);
          objData = JsonUtility.FromJson<ObjData>(jsonData);
      }*/

    public void Start()
    {
        //StartCoroutine(LoadObjDataFromJson(fileName));
    }

    // JSON �����͸� �о�ͼ� ó���ϴ� �ڷ�ƾ�Դϴ�.
    public IEnumerator LoadObjDataFromJson(string fileName)
    {
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, fileName + ".json");

#if UNITY_ANDROID && !UNITY_EDITOR
        path = "jar:file://" + Application.streamingAssetsPath + "/" + fileName + ".json";
#endif

        using (UnityWebRequest www = UnityWebRequest.Get(path))
        {
            // �� ��û�� �����ϴ�.
            yield return www.SendWebRequest();
            // JSON �����͸� ���ڿ��� �о�ɴϴ�.
            string jsonData = www.downloadHandler.text;
            objData = JsonUtility.FromJson<ObjData>(jsonData);
        }
    }
}
