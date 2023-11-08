using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class TouchMgr : MonoBehaviour
{
    private Camera ARCam;
    private Ray ray;
    private RaycastHit hit;

    public TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        ARCam = GameObject.Find("ARCamera").GetComponent<Camera>();
    }

    void Update()
    {
        //��ġ�� ������ 0 �̻��̰� ù ��° ��ġ�� ���
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //�հ������� ��ġ�� ��ũ�� ��ǥ�� �������� 3���� ������ ����
            ray = ARCam.ScreenPointToRay(Input.GetTouch(0).position);

            RaycastHit[] hits;

            hits = Physics.RaycastAll(ray, 100f);

            if(hits!=null && hits.Length>0)
            {
                RaycastHit closesHit = hits[0];

                for(int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].distance < closesHit.distance)
                    {
                        closesHit = hits[i];
                    }
                }

                string objectName = closesHit.transform.name;
                textMeshProUGUI.text = objectName;
                //InformationSetting.Instance.fileName = objectName;
                StartCoroutine(InformationSetting.Instance.LoadObjDataFromJson(objectName));
                //InformationSetting.Instance.LoadObjDataFromJson(objectName);
            }   
        }
    }
}
