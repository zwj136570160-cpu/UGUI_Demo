using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private static UIManager instance = new UIManager();
    public static UIManager Instance => instance;

    //存储面板的容器
    private Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();

    //一开始就得到Canvas对象
    private Transform canvasTrans;

    private UIManager() 
    {
        //得到场景上创建好的Canvas对象
        canvasTrans = GameObject.Find("Canvas").transform;
        //让Canvas对象 过场景 不移除
        //动态创建和动态删除来显示隐藏面板的，所以不删除它，影响不大
        GameObject.DontDestroyOnLoad(canvasTrans.gameObject);
    }

    //显示面板
    public T ShowPanel<T>() where T:BasePanel
    {
        //只需要保证 泛型T的类型和面板名一直 定一个这样的规则 方便使用
        string panelName = typeof(T).Name;

        //判断是否有显示的面板了，如果有 不用创建 直接返回给外部使用
        if (panelDic.ContainsKey(panelName))
            return panelDic[panelName] as T;

        //显示面板  动态创建面板预设体 设置父对象
        //根据得到的类名 就是预设体面板名 直接动态创建即可
        GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>($"UI/{panelName}"));
        panelObj.transform.SetParent(canvasTrans, false);

        //得到对应的面板脚本，存储起来
        T panel = panelObj.GetComponent<T>();
        //把面板脚本存储到对应容器中之后，可以方便获取
        panelDic.Add(panelName, panel);
        //调用显示自己的逻辑
        panel.ShowMe();

        return panel;
    }

    //隐藏面板
    //参数一：如果希望淡出，就默认传true 如果希望直接隐藏（删除面板）那么就传false
    public void HidePanel<T>(bool isFade = true) where T:BasePanel
    {
        //根据泛型类型得到面板名字
        string panelName = typeof(T).Name;
        //判断当前显示的面板 有没有该名字的面板
        if(panelDic.ContainsKey(panelName))
        {
            if(isFade)
            {
                panelDic[panelName].HideMe(() =>
                {
                    //面板 淡出成功后 删除面板
                    GameObject.Destroy(panelDic[panelName].gameObject);
                    //删除面板后 从字典中摸出
                    panelDic.Remove(panelName);
                });
            }
            else
            {
                //删除面板
                GameObject.Destroy(panelDic[panelName].gameObject);
                //删除面板后 从字典中摸出
                panelDic.Remove(panelName);
            }
        }
    }

    //获得面板
    public T getPanel<T>() where T:BasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
            return panelDic[panelName] as T;
        return null;
    }
}
