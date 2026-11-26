using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class LoginPanel : BasePanel
{
    //注册按钮
    public Button btnRegister;
    //确定登陆按钮
    public Button btnSure;

    //账户名输入框
    public InputField inputUN;
    //密码输入框
    public InputField inputPW;

    //记住密码多选框
    public Toggle togPW;
    //自动登陆多选框
    public Toggle togAuto;

    public override void Init()
    {
        //点击注册
        btnRegister.onClick.AddListener(() =>
        {
            //显示注册面板

            //隐藏自己
            UIManager.Instance.HidePanel<LoginPanel>();
        });

        //点击登陆
        btnSure.onClick.AddListener(() =>
        {
            //点击登陆后 要验证用户名密码 是否正确
        });

        //点击记住密码
        togPW.onValueChanged.AddListener((isOn) =>
        {
            //当取消记住密码时，如果自动登陆被选中了，应该要取消自动登陆
            if (!isOn)
            {
                togAuto.isOn = false;
            }
        });

        //点击自动登陆
        togAuto.onValueChanged.AddListener((isOn) =>
        {
            //当选中自动登陆时，如果记住密码没有被选中，应该要选中
            if(isOn)
            {
                togPW.isOn = true;
            }
        });
    }

    public override void ShowMe()
    {
        base.ShowMe();
        //显示自己时 根据数据 更新面板上的内容

        //得到数据
        LoginData loginData = LoginMgr.Instance.LoginData;

        //初始化面板显示
        togPW.isOn = loginData.remeberPw;
        togAuto.isOn = loginData.autoLogin;

        //更新账号密码
        inputUN.text = loginData.userName;
        if (togPW.isOn)
            inputPW.text = loginData.passWord;

        //自动登陆逻辑
        if(togAuto.isOn)
        {
            //自动验证账号密码相关
        }
    }
}
