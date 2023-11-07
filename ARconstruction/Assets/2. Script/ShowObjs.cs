using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShowObjs : MonoBehaviour
{
    #region Toggle
    Toggle m_Toggle_ViewAll;
    Toggle m_Toggle_Frame;
    Toggle m_Toggle_Wall;
    Toggle m_Toggle_MEPF;
    Toggle m_Toggle_Mechanical;
    Toggle m_Toggle_Plumbing;
    Toggle m_Toggle_FireProtection;
    #endregion

    #region Button
    [SerializeField] Button m_resetBtn;
    [SerializeField] Button m_deleteBtn;
    #endregion

    #region GameObject
    GameObject m_withoutWall;
    GameObject m_FrameObj;
    GameObject m_WallObj;
    GameObject m_MechanicalObj;
    GameObject m_PlumbingObj;
    GameObject m_FireProtectionObj;
    #endregion

    void Start()
    {
        Toggle[] togglesFromManager = ResourceManager.instance.toggles;
        m_Toggle_ViewAll = togglesFromManager[0];
        m_Toggle_Frame = togglesFromManager[1];
        m_Toggle_Wall = togglesFromManager[2];
        m_Toggle_MEPF = togglesFromManager[3];
        m_Toggle_Mechanical = togglesFromManager[4];
        m_Toggle_Plumbing = togglesFromManager[5];
        m_Toggle_FireProtection = togglesFromManager[6];

        GameObject[] objs = ResourceManager.instance.objects;
        m_withoutWall = objs[0];
        m_FrameObj = objs[1];
        m_WallObj = objs[2];
        m_MechanicalObj = objs[3];
        m_PlumbingObj = objs[4];
        m_FireProtectionObj = objs[5];

        ToggleInit();

        foreach (Toggle toggle in togglesFromManager)
        {
            toggle.onValueChanged.AddListener(delegate
            {
                ToggleValueChanged(toggle); // ��� �� ���� �̺�Ʈ �ڵ鷯�� ���
            });
        }

        m_resetBtn.onClick.AddListener(delegate
        {
            ToggleInit();
        });

        m_deleteBtn.onClick.AddListener(delegate
        {
            LostnDelete();
        });
    }

    public void ToggleInit()
    {
        // ��� �ʱ� ����
        m_Toggle_ViewAll.isOn = true; // ó���� ��� ���̰� ����
        m_Toggle_Frame.isOn = false;
        m_Toggle_Wall.isOn = false;
        m_Toggle_Mechanical.isOn = false;
        m_Toggle_Plumbing.isOn = false;
        m_Toggle_FireProtection.isOn = false;

        m_withoutWall.SetActive(true);
        m_FrameObj.SetActive(false);
        m_WallObj.SetActive(true);
        m_MechanicalObj.SetActive(false);
        m_PlumbingObj.SetActive(false);
        m_FireProtectionObj.SetActive(false);
    }

    void ToggleValueChanged(Toggle toggle)
    {
        if (toggle == m_Toggle_ViewAll)
        {
            bool viewAllEnabled = toggle.isOn;

            if (viewAllEnabled)
            {
                // ��� �ٸ� ��۵��� ��Ȱ��ȭ
                m_Toggle_Frame.isOn = false;
                m_Toggle_Wall.isOn = false;
                m_Toggle_MEPF.isOn = false;
                m_Toggle_Mechanical.isOn = false;
                m_Toggle_Plumbing.isOn = false;
                m_Toggle_FireProtection.isOn = false;
            }

            m_withoutWall.SetActive(viewAllEnabled);
            m_WallObj.SetActive(viewAllEnabled);
        }
        else if (toggle == m_Toggle_Frame)
        {
            if (toggle.isOn)
            {
                // �ٸ� ��� ��Ȱ��ȭ
                m_Toggle_ViewAll.isOn = false;
            }
            m_FrameObj.SetActive(toggle.isOn); // ������ ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
        }
        else if (toggle == m_Toggle_Wall)
        {
            if (toggle.isOn)
            {
                // �ٸ� ��� ��Ȱ��ȭ
                m_Toggle_ViewAll.isOn = false;
            }
            m_WallObj.SetActive(toggle.isOn); // �� ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
        }
        else if (toggle == m_Toggle_MEPF && !toggle.isOn)
        {
            // MEPF ����� �����Ǹ� �ٸ� ���� ��۵鵵 ����
            m_Toggle_Mechanical.isOn = false;
            m_Toggle_Plumbing.isOn = false;
            m_Toggle_FireProtection.isOn = false;
        }
        else if (toggle == m_Toggle_Mechanical)
        {
            if (toggle.isOn)
            {
                // �ٸ� ��� ��Ȱ��ȭ
                m_Toggle_ViewAll.isOn = false;
            }
            m_MechanicalObj.SetActive(toggle.isOn); // ��� ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
        }
        else if (toggle == m_Toggle_Plumbing)
        {
            if (toggle.isOn)
            {
                // �ٸ� ��� ��Ȱ��ȭ
                m_Toggle_ViewAll.isOn = false;
            }
            m_PlumbingObj.SetActive(toggle.isOn); // ��� ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
        }
        else if (toggle == m_Toggle_FireProtection)
        {
            if (toggle.isOn)
            {
                // �ٸ� ��� ��Ȱ��ȭ
                m_Toggle_ViewAll.isOn = false;
            }
            m_FireProtectionObj.SetActive(toggle.isOn); // �ҹ� ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
        }
    }

    public void LostnDelete()
    {
        m_Toggle_ViewAll.isOn = false;
        m_Toggle_Frame.isOn = false;
        m_Toggle_Wall.isOn = false;
        m_Toggle_MEPF.isOn = false;
        m_Toggle_Mechanical.isOn = false;
        m_Toggle_Plumbing.isOn = false;
        m_Toggle_FireProtection.isOn = false;
    }
}