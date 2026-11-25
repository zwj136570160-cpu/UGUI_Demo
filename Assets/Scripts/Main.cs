using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //显示提示面板
        TipPanel tipPanel = UIManager.Instance.ShowPanel<TipPanel>();
        tipPanel.ChangeInfo("测试提示内容改变");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
