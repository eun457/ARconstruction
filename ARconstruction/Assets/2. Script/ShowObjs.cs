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
        var resourceManager = ResourceManager.instance;
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

        //toggles[(int)T_Index.ViewAll].isOn = true; // ó���� ��� ���̰� ����
        //toggles[(int)T_Index.Frame].isOn = false;
        //toggles[(int)T_Index.Wall].isOn = false;
        //toggles[(int)T_Index.Mechanical].isOn = false;
        //toggles[(int)T_Index.Plumbing].isOn = false;
        //toggles[(int)T_Index.FireProtection].isOn = false;

        //������Ʈ �ʱ� ����
        for (int i = 0; i<objs.Length; i++)
        {
            //�ǹ� �ܰ� ������Ʈ�� Ȱ��ȭ
            objs[i].SetActive(i == (int)Obj_Index.WithoutWall || i == (int)Obj_Index.Wall);
        }

        //objs[(int)O_Index.WithoutWall].SetActive(true);
        //objs[(int)O_Index.Frame].SetActive(false);
        //objs[(int)O_Index.Wall].SetActive(true);
        //objs[(int)O_Index.Mechanical].SetActive(false);
        //objs[(int)O_Index.Plumbing].SetActive(false);
        //objs[(int)O_Index.FireProtection].SetActive(false);
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
        if (toggle == toggles[(int)Toggle_Index.ViewAll])
        {
            bool viewAllEnabled = toggle.isOn;

            if (viewAllEnabled)
            {
                // ��� �ٸ� ��۵��� ��Ȱ��ȭ
                toggles[(int)Toggle_Index.Frame].isOn = false;
                toggles[(int)Toggle_Index.Wall].isOn = false;
                toggles[(int)Toggle_Index.MEPF].isOn = false;
                toggles[(int)Toggle_Index.Mechanical].isOn = false;
                toggles[(int)Toggle_Index.Plumbing].isOn = false;
                toggles[(int)Toggle_Index.FireProtection].isOn = false;
            }

            objs[(int)Obj_Index.WithoutWall].SetActive(viewAllEnabled);
            objs[(int)Obj_Index.Wall].SetActive(viewAllEnabled);
        }
        else if (toggle == toggles[(int)Toggle_Index.Frame])
        {
            if (toggle.isOn)
            {
                // �ٸ� ��� ��Ȱ��ȭ
                toggles[(int)Toggle_Index.ViewAll].isOn = false;
            }
            objs[(int)Obj_Index.Frame].SetActive(toggle.isOn); // ������ ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
        }
        else if (toggle == toggles[(int)Toggle_Index.Wall])
        {
            if (toggle.isOn)
            {
                // �ٸ� ��� ��Ȱ��ȭ
                toggles[(int)Toggle_Index.ViewAll].isOn = false;
            }
            objs[(int)Obj_Index.Wall].SetActive(toggle.isOn); // �� ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
        }
        else if (toggle == toggles[(int)Toggle_Index.MEPF] && !toggle.isOn)
        {
            // MEPF ����� �����Ǹ� �ٸ� ���� ��۵鵵 ����
            toggles[(int)Toggle_Index.Mechanical].isOn = false;
            toggles[(int)Toggle_Index.Plumbing].isOn = false;
            toggles[(int)Toggle_Index.FireProtection].isOn = false;
        }
        else if (toggle == toggles[(int)Toggle_Index.Mechanical])
        {
            if (toggle.isOn)
            {
                // �ٸ� ��� ��Ȱ��ȭ
                toggles[(int)Toggle_Index.ViewAll].isOn = false;
            }
            objs[(int)Obj_Index.Mechanical].SetActive(toggle.isOn); // ��� ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
        }
        else if (toggle == toggles[(int)Toggle_Index.Plumbing])
        {
            if (toggle.isOn)
            {
                // �ٸ� ��� ��Ȱ��ȭ
                toggles[(int)Toggle_Index.ViewAll].isOn = false;
            }
            objs[(int)Obj_Index.Plumbing].SetActive(toggle.isOn); // ��� ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
        }
        else if (toggle == toggles[(int)Toggle_Index.FireProtection])
        {
            if (toggle.isOn)
            {
                // �ٸ� ��� ��Ȱ��ȭ
                toggles[(int)Toggle_Index.ViewAll].isOn = false;
            }
            objs[(int)Obj_Index.FireProtection].SetActive(toggle.isOn); // �ҹ� ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
        }
    }

    public void LostnDelete()
    {
        //��� ��� ��������
        for(int i = 0; i < toggles.Length; i++)
        {
            toggles[i].isOn = false;
        }

        //toggles[(int)Toggle_Index.ViewAll].isOn = false;
        //toggles[(int)Toggle_Index.Frame].isOn = false;
        //toggles[(int)Toggle_Index.Wall].isOn = false;
        //toggles[(int)Toggle_Index.MEPF].isOn = false;
        //toggles[(int)Toggle_Index.Mechanical].isOn = false;
        //toggles[(int)Toggle_Index.Plumbing].isOn = false;
        //toggles[(int)Toggle_Index.FireProtection].isOn = false;
    }
}