using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShowObjs : MonoBehaviour
{
    enum Toggle_Index { ViewAll, Frame, Wall, MEPF, Mechanical, Plumbing, FireProtection }
    enum Btn_Index { Reset, Delete, Phase }
    enum Obj_Index { WithoutWall, Frame, Wall, Mechanical, Plumbing, FireProtection }
    
    Toggle[] toggles;
    Button[] buttons;
    GameObject[] objs;

    void Start()
    {
        //ResourceManager���� ���ҽ� �ε�
        var resourceManager = ResourceManager.Instance;
        toggles = resourceManager.toggles;
        objs = resourceManager.objects;
        buttons = resourceManager.buttons;

        //��� �ʱ�ȭ
        Initialize();

        //�̺�Ʈ ������ �߰�
        AddTogglesListeners();
        AddButtonListeners();
    }
    public void Initialize()
    {
        //��� �ʱ� ����
        for (int i = 0; i < toggles.Length; i++)
        {
            //ViewAll��۸� Ȱ��ȭ
            toggles[i].isOn = i == (int)Toggle_Index.ViewAll;
        }

        //������Ʈ �ʱ� ����
        for (int i = 0; i<objs.Length; i++)
        {
            //�ǹ� �ܰ� ������Ʈ�� Ȱ��ȭ
            objs[i].SetActive(i == (int)Obj_Index.WithoutWall || i == (int)Obj_Index.Wall);
        }
    }
    private void AddTogglesListeners()
    {
        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(isOn => OnToggleValueChanged(toggle));
        }
    }
    private void AddButtonListeners()
    {
        buttons[(int)Btn_Index.Reset].onClick.AddListener(Initialize);
        buttons[(int)Btn_Index.Delete].onClick.AddListener(LostnDelete);
    }

    void OnToggleValueChanged(Toggle toggle)
    {
        bool isToggleOn = toggle.isOn;

        if(toggle == toggles[(int)Toggle_Index.ViewAll])
        {
            SetViewAllToggleState(toggle);
        }
        else
        {
            if (isToggleOn)
            {
                toggles[(int)Toggle_Index.ViewAll].isOn = false;
            }
            
            if(toggle == toggles[(int)Toggle_Index.Frame])
            {
                objs[(int)Obj_Index.Frame].SetActive(toggle.isOn);
            }
            else if(toggle == toggles[(int)Toggle_Index.Wall])
            {
                objs[(int)Obj_Index.Wall].SetActive(toggle.isOn);
            }
            else if(toggle == toggles[(int)Toggle_Index.MEPF] && !toggle.isOn)
            {
                // MEPF ����� �����Ǹ� �ٸ� ���� ��۵鵵 ����
                for (int i = (int)Toggle_Index.Mechanical; i <= (int)Toggle_Index.FireProtection; i++)
                {
                    toggles[i].isOn = false;
                }
            }
            else if(toggle == toggles[(int)Toggle_Index.Mechanical])
            {
                objs[(int)Obj_Index.Mechanical].SetActive(toggle.isOn);
            }
            else if(toggle == toggles[(int)Toggle_Index.Plumbing])
            {
                objs[(int)Obj_Index.Plumbing].SetActive(toggle.isOn);
            }
            else if(toggle == toggles[(int)Toggle_Index.FireProtection])
            {
                objs[(int)Obj_Index.FireProtection].SetActive(toggle.isOn);
            }
        }
    }

    void SetViewAllToggleState(Toggle toggle)
    {
        bool viewAllEnabled = toggle.isOn;

        if (viewAllEnabled)
        {
            // ViewAll�� �ٸ� ��� üũ����
            for (int i = (int)Toggle_Index.Frame; i <= (int)Toggle_Index.FireProtection; i++)
            {
                toggles[i].isOn = !viewAllEnabled;
            }
        }

        objs[(int)Obj_Index.WithoutWall].SetActive(viewAllEnabled);
        objs[(int)Obj_Index.Wall].SetActive(viewAllEnabled);
    }

    public void LostnDelete()
    {
        //��� ��� ��������
        for(int i = 0; i < toggles.Length; i++)
        {
            toggles[i].isOn = false;
        }
    }
}