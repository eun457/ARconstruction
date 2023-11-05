using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChangeController : MonoBehaviour
{
    //[SerializeField] Toggle m_Toggle_ViewAll;
    [SerializeField] Toggle m_Toggle_Frame;
    [SerializeField] Toggle m_Toggle_Wall;
    [SerializeField] Toggle m_Toggle_MEPF;
    [SerializeField] Toggle m_Toggle_Mechanical;
    [SerializeField] Toggle m_Toggle_Plumbing;
    [SerializeField] Toggle m_Toggle_FireProtection;

    // �������� ����� ������Ʈ ����Ʈ
    List<GameObject> objectsToChangeColor = new List<GameObject>(); 
    int clickCount = 0;
    Color[] colorArray = { Color.red, Color.yellow, Color.green, Color.blue, Color.magenta };

    private void Start()
    {
        Toggle[] toggles = new Toggle[] { m_Toggle_Frame, m_Toggle_Wall, m_Toggle_MEPF, m_Toggle_Mechanical, m_Toggle_Plumbing, m_Toggle_FireProtection };
        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(delegate
            {
                OnToggleisOn(toggle);
            });
        }
    }
    public void OnToggleisOn(Toggle toggle)
    {
        if (clickCount < objectsToChangeColor.Count)
        {
            // ������Ʈ ���� ����
            objectsToChangeColor[clickCount].GetComponent<Renderer>().material.color = colorArray[clickCount];

            // Ŭ�� Ƚ�� ����
            clickCount++;
        }
    }

    //������Ʈ�� �������� �߰��ϴ� �Լ�
    public void AddObjectToChangeColor(GameObject obj)
    {
        objectsToChangeColor.Add(obj);
    }
}
