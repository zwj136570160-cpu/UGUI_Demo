using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        //显示 提示面板 测试
        //TipPanel tipPanel = UIManager.Instance.ShowPanel<TipPanel>();
        //tipPanel.ChangeInfo("测试提示内容改变");

        //一进游戏，就应该显示登陆面板
        UIManager.Instance.ShowPanel<LoginPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
