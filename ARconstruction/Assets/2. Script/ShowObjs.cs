using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShowObjs : MonoBehaviour
{
    #region Toggle
    [SerializeField] Toggle m_Toggle_ViewAll;
    [SerializeField] Toggle m_Toggle_Frame;
    [SerializeField] Toggle m_Toggle_Wall;
    [SerializeField] Toggle m_Toggle_MEPF;
    [SerializeField] Toggle m_Toggle_Mechanical;
    [SerializeField] Toggle m_Toggle_Plumbing;
    [SerializeField] Toggle m_Toggle_FireProtection;
    #endregion

    #region Button
    [SerializeField] Button m_resetBtn;
    [SerializeField] Button m_deleteBtn;
    #endregion

    #region GameObject
    [SerializeField] GameObject m_withoutWall;
    [SerializeField] GameObject m_FrameObj;
    [SerializeField] GameObject m_WallObj;
    [SerializeField] GameObject m_MechanicalObj;
    [SerializeField] GameObject m_PlumbingObj;
    [SerializeField] GameObject m_FireProtectionObj;
    #endregion

    void Start()
    {
        ToggleInit();

        //�� ��ۿ� ���� �̺�Ʈ �����ʸ� �߰�
        Toggle[] toggles = new Toggle[]
        { m_Toggle_ViewAll, m_Toggle_Frame, m_Toggle_Wall, m_Toggle_MEPF, m_Toggle_Mechanical, m_Toggle_Plumbing, m_Toggle_FireProtection };

        foreach (Toggle toggle in toggles)
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