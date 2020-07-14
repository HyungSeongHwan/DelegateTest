using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;

public class TextItem : MonoBehaviour
{

    public delegate void DelegateFunc(TextItem kItem, bool bSelect);
    public DelegateFunc OnSelectedFunc = null;

    [SerializeField] Text m_textMain = null;

    private Button _btnSelect = null;
    private Color _OriColor = Color.white;

    public int m_Index = 0;


    private void Start()
    {
        _OriColor = GetComponent<Image>().color;

        _btnSelect = GetComponent<Button>();
        _btnSelect.onClick.AddListener(OnClicked_Select);
    }


    public void Initialize(int idx, string sName)
    {
        m_Index = idx;
        m_textMain.text = sName;

    }

    public void OnAddListner(DelegateFunc func)
    {
        OnSelectedFunc = new DelegateFunc(func);
    }

    public void OnClicked_Select()
    {
        if (OnSelectedFunc != null) OnSelectedFunc(this, true);
    }

    public void ClearSelect()
    {
        SetSelectedColor(false);
    }

    public void SetSelectedColor(bool bSelect)
    {
        Image kImage = GetComponent<Image>();

        if (bSelect)
        {
            kImage.color = Color.green;
        }
        else
        {
            kImage.color = _OriColor;
        }
    }
}
