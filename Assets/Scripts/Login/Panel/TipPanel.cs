using UnityEngine;
using UnityEngine.UI;

public class TipPanel : BasePanel
{
    public Button btnSure;
    public Text txtInfo;

    public override void Init()
    {
        //初始化 按钮事件监听
        btnSure.onClick.AddListener(() =>
        {
            //隐藏自己
            UIManager.Instance.HidePanel<TipPanel>();
        });
    }

    /// <summary>
    /// 提示内容改变 提供给外部使用
    /// </summary>
    /// <param name="info">提示内容</param>
    public void ChangeInfo(string info)
    {
        txtInfo.text = info;
    }
}
