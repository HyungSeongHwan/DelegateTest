using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelegateTestUI : MonoBehaviour
{
    public static string[] CITYLIST = { "서울", "전주", "부산" };

    [SerializeField] TextItem[] m_TextItems = null;
    [SerializeField] Text m_txtResult = null;

    [SerializeField] Button m_btnResult = null;
    [SerializeField] Button m_btnClear = null;

    private int m_nSelectIndex = -1;


    private void Start()
    {
        m_btnResult.onClick.AddListener(OnClicked_Result);
        m_btnClear.onClick.AddListener(OnClicked_Clear);

        Initialize();
    }


    private void Initialize()
    {
        for (int i = 0; i < m_TextItems.Length; i++)
        {
            m_TextItems[i].OnAddListner(OnCallBack_TextItem);
            m_TextItems[i].Initialize(i, CITYLIST[i]);
        }
    }

    public void Initialize2()
    {
        for(int i = 0; i<m_TextItems.Length; i++)
        {
            m_TextItems[i].OnAddListner((TextItem kItem, bool bSelect) =>
            {
                OnCallBack_TextItem(kItem, bSelect);
            });
        }
    }

    private void ClearAllSelectItem()
    {
        for (int i = 0; i < m_TextItems.Length; i++)
        {
            m_TextItems[i].ClearSelect();
        }
    }

    private void PrintfResult(int nSelectIdx)
    {
        string sName = CITYLIST[nSelectIdx];
        m_txtResult.text = sName;
    }

    private void OnClicked_Result()
    {
        if (m_nSelectIndex != -1)
        {
            string sName = CITYLIST[m_nSelectIndex];
            m_txtResult.text = string.Format("선택된 도시는 {0} 입니다.", sName);
        }
    }

    public void OnClicked_Clear()
    {
        m_txtResult.text = "";
        ClearAllSelectItem();
        m_nSelectIndex = -1;
    }

    private void OnCallBack_TextItem(TextItem kItem, bool bSelect)
    {
        ClearAllSelectItem();
        kItem.SetSelectedColor(bSelect);
        m_nSelectIndex = kItem.m_Index;

        PrintfResult(m_nSelectIndex);
    }

}
