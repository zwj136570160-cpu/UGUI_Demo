using UnityEngine;

public class LoginMgr
{
    private static LoginMgr instance = new LoginMgr();
    public static LoginMgr Instance => instance;

    //静态变量，不要在外面去new
    private LoginData loginData;
    //公共属性 方便外面获取
    public LoginData LoginData => loginData;

    private LoginMgr() 
    {
        //直接通过Json管理器 来读取对应数据
        loginData = JsonMgr.Instance.LoadData<LoginData>("LoginData");
    }

    #region 登陆数据
    //存储数据相关
    public void SaveLoginData()
    {
        JsonMgr.Instance.SaveData(loginData, "LoginData");
    }
    #endregion
}
