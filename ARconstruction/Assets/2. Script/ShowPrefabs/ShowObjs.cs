using UnityEngine;
using UnityEngine.UI;

public class ShowObjs : MonoBehaviour
{
    #region Toggle
    [SerializeField] Toggle m_Toggle_ViewAll; // ��� ������Ʈ�� �����ִ� ���
    [SerializeField] Toggle m_Toggle_Frame; // ������ ������Ʈ�� �����ִ� ���
    [SerializeField] Toggle m_Toggle_Wall; // �� ������Ʈ�� �����ִ� ���
    [SerializeField] Toggle m_Toggle_MEPF; // MEPF ������Ʈ�� �����ִ� ���
    [SerializeField] Toggle m_Toggle_Mechanical; // ��� ������Ʈ�� �����ִ� ���
    [SerializeField] Toggle m_Toggle_Plumbing; // ��� ������Ʈ�� �����ִ� ���
    [SerializeField] Toggle m_Toggle_FireProtection; // �ҹ� ������Ʈ�� �����ִ� ���
    #endregion

    #region GameObject
    [SerializeField] GameObject m_withoutWall; // �� ���� �������� ������Ʈ
    [SerializeField] GameObject m_FrameObj; // ������ ������Ʈ
    [SerializeField] GameObject m_WallObj; // �� ������Ʈ
    [SerializeField] GameObject m_MechanicalObj; // ��� ������Ʈ
    [SerializeField] GameObject m_PlumbingObj; // ��� ������Ʈ
    [SerializeField] GameObject m_FireProtectionObj; // �ҹ� ������Ʈ
    #endregion

    void Start()
    {
        ToggleInit(); // ��� �ʱ� ������ ȣ��

        // �� ��ۿ� ���� �̺�Ʈ �����ʸ� �߰�
        Toggle[] toggles = new Toggle[]
        { m_Toggle_ViewAll, m_Toggle_Frame, m_Toggle_Wall, m_Toggle_MEPF, m_Toggle_Mechanical, m_Toggle_Plumbing, m_Toggle_FireProtection };

        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(delegate
            {
                ToggleValueChanged(toggle); // ��� �� ���� �̺�Ʈ �ڵ鷯�� ���
            });
        }
    }

    void ToggleInit()
    {
        // ��� �ʱ� ����
        m_Toggle_ViewAll.isOn = true; // ó���� ��� ���̰� ����
        m_Toggle_Frame.isOn = false;
        m_Toggle_Wall.isOn = false;
        m_Toggle_Mechanical.isOn = false;
        m_Toggle_Plumbing.isOn = false;
        m_Toggle_FireProtection.isOn = false;
    }

    void ToggleValueChanged(Toggle toggle)
    {
        if (toggle == m_Toggle_ViewAll)
        {
            bool viewAllEnabled = toggle.isOn;

            m_withoutWall.SetActive(viewAllEnabled); // �� ���� �������� ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
            m_WallObj.SetActive(viewAllEnabled); // �� ������Ʈ Ȱ��ȭ/��Ȱ��ȭ

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
}