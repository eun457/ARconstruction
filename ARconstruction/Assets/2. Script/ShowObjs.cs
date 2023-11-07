using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShowObjs : MonoBehaviour
{
    enum T_Index { ViewAll, Frame, Wall, MEPF, Mechanical, Plumbing, FireProtection }
    Toggle[] toggles;

    enum B_Index { Reset, Delete, Phase }
    Button[] buttons;

    enum O_Index { WithoutWall, Frame, Wall, Mechanical, Plumbing, FireProtection }
    GameObject[] objs;

    void Start()
    {
        //ResourceManager���� ���ҽ� �ε�
        toggles = ResourceManager.instance.toggles;
        objs = ResourceManager.instance.objects;
        buttons = ResourceManager.instance.buttons;

        //��� �ʱ�ȭ
        ToggleInit();

        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(delegate
            {
                ToggleValueChanged(toggle); // ��� �� ���� �̺�Ʈ �ڵ鷯�� ���
            });
        }

        buttons[(int)B_Index.Reset].onClick.AddListener(delegate
        {
            ToggleInit();
        });

        buttons[(int)B_Index.Delete].onClick.AddListener(delegate
        {
            LostnDelete();
        });
    }

    public void ToggleInit()
    {
        // ��� �ʱ� ����
        toggles[(int)T_Index.ViewAll].isOn = true; // ó���� ��� ���̰� ����
        toggles[(int)T_Index.Frame].isOn = false;
        toggles[(int)T_Index.Wall].isOn = false;
        toggles[(int)T_Index.Mechanical].isOn = false;
        toggles[(int)T_Index.Plumbing].isOn = false;
        toggles[(int)T_Index.FireProtection].isOn = false;

        objs[(int)O_Index.WithoutWall].SetActive(true);
        objs[(int)O_Index.Frame].SetActive(false);
        objs[(int)O_Index.Wall].SetActive(true);
        objs[(int)O_Index.Mechanical].SetActive(false);
        objs[(int)O_Index.Plumbing].SetActive(false);
        objs[(int)O_Index.FireProtection].SetActive(false);
    }

    void ToggleValueChanged(Toggle toggle)
    {
        if (toggle == toggles[(int)T_Index.ViewAll])
        {
            bool viewAllEnabled = toggle.isOn;

            if (viewAllEnabled)
            {
                // ��� �ٸ� ��۵��� ��Ȱ��ȭ
                toggles[(int)T_Index.Frame].isOn = false;
                toggles[(int)T_Index.Wall].isOn = false;
                toggles[(int)T_Index.MEPF].isOn = false;
                toggles[(int)T_Index.Mechanical].isOn = false;
                toggles[(int)T_Index.Plumbing].isOn = false;
                toggles[(int)T_Index.FireProtection].isOn = false;
            }

            objs[(int)O_Index.WithoutWall].SetActive(viewAllEnabled);
            objs[(int)O_Index.Wall].SetActive(viewAllEnabled);
        }
        else if (toggle == toggles[(int)T_Index.Frame])
        {
            if (toggle.isOn)
            {
                // �ٸ� ��� ��Ȱ��ȭ
                toggles[(int)T_Index.ViewAll].isOn = false;
            }
            objs[(int)O_Index.Frame].SetActive(toggle.isOn); // ������ ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
        }
        else if (toggle == toggles[(int)T_Index.Wall])
        {
            if (toggle.isOn)
            {
                // �ٸ� ��� ��Ȱ��ȭ
                toggles[(int)T_Index.ViewAll].isOn = false;
            }
            objs[(int)O_Index.Wall].SetActive(toggle.isOn); // �� ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
        }
        else if (toggle == toggles[(int)T_Index.MEPF] && !toggle.isOn)
        {
            // MEPF ����� �����Ǹ� �ٸ� ���� ��۵鵵 ����
            toggles[(int)T_Index.Mechanical].isOn = false;
            toggles[(int)T_Index.Plumbing].isOn = false;
            toggles[(int)T_Index.FireProtection].isOn = false;
        }
        else if (toggle == toggles[(int)T_Index.Mechanical])
        {
            if (toggle.isOn)
            {
                // �ٸ� ��� ��Ȱ��ȭ
                toggles[(int)T_Index.ViewAll].isOn = false;
            }
            objs[(int)O_Index.Mechanical].SetActive(toggle.isOn); // ��� ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
        }
        else if (toggle == toggles[(int)T_Index.Plumbing])
        {
            if (toggle.isOn)
            {
                // �ٸ� ��� ��Ȱ��ȭ
                toggles[(int)T_Index.ViewAll].isOn = false;
            }
            objs[(int)O_Index.Plumbing].SetActive(toggle.isOn); // ��� ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
        }
        else if (toggle == toggles[(int)T_Index.FireProtection])
        {
            if (toggle.isOn)
            {
                // �ٸ� ��� ��Ȱ��ȭ
                toggles[(int)T_Index.ViewAll].isOn = false;
            }
            objs[(int)O_Index.FireProtection].SetActive(toggle.isOn); // �ҹ� ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
        }
    }

    public void LostnDelete()
    {
        toggles[(int)T_Index.ViewAll].isOn = false;
        toggles[(int)T_Index.Frame].isOn = false;
        toggles[(int)T_Index.Wall].isOn = false;
        toggles[(int)T_Index.MEPF].isOn = false;
        toggles[(int)T_Index.Mechanical].isOn = false;
        toggles[(int)T_Index.Plumbing].isOn = false;
        toggles[(int)T_Index.FireProtection].isOn = false;
    }
}