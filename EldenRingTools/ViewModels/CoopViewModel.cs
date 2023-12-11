using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;

namespace EldenRingTools.ViewModels;

public partial class CoopViewModel : ObservableObject
{
    [ObservableProperty]
    private string gameExePath;

    [ObservableProperty]
    private bool useSeamlessCoop;
    [ObservableProperty]
    private bool useModEngine2;

    [ObservableProperty]
    private bool useSteamEmuWithOverlay;
    [ObservableProperty]
    private bool useSteamEmuAchievement;

    [ObservableProperty]
    private bool useModAdjustTheFov;
    [ObservableProperty]
    private bool useModDisableRuneLoss;
    [ObservableProperty]
    private bool useModFixTheCamera;
    [ObservableProperty]
    private bool useModIncreaseAnimationDistance;
    [ObservableProperty]
    private bool useModPauseTheGame;
    [ObservableProperty]
    private bool useModRemoveBlackBars;
    [ObservableProperty]
    private bool useModRemoveChromaticAberration;
    [ObservableProperty]
    private bool useModRemoveVignette;
    [ObservableProperty]
    private bool useModSkipTheIntro;
    [ObservableProperty]
    private bool useModUnlockTheFps;

    [ObservableProperty]
    private string coopAccountName;
    [ObservableProperty]
    private string coopSteam64Id;
    [ObservableProperty]
    private string coopPassword;

    public CoopViewModel()
    {

    }

    /// <summary>
    /// 获取游戏主程序位置
    /// </summary>
    [RelayCommand]
    private void GetGameExePath()
    {
        var fileDialog = new OpenFileDialog
        {
            Title = "选择 Elden Ring 主程序",
            RestoreDirectory = true,
            Multiselect = false,
            Filter = "可执行文件|*.exe",
            FileName = "eldenring.exe"
        };

        if (fileDialog.ShowDialog() == false)
            return;

        GameExePath = string.Empty;

        if (!fileDialog.FileName.EndsWith("eldenring.exe"))
        {
            Growl.Warning("选取的文件名非 eldenring.exe 文件");
            return;
        }

        var versionInfo = FileVersionInfo.GetVersionInfo(fileDialog.FileName);
        if (versionInfo.CompanyName is null ||
            !versionInfo.CompanyName.Equals("FromSoftware, Inc."))
        {
            Growl.Warning("eldenring.exe 文件签名不正确");
            return;
        }

        GameExePath = fileDialog.FileName;
        Globals.GameExePath = GameExePath;
        Growl.Success("eldenring.exe 文件路径选择成功");
    }

    /// <summary>
    /// 应用设置
    /// </summary>
    [RelayCommand]
    private void ApplySetting()
    {

    }
}
