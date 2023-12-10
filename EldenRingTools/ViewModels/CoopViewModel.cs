using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;

using EldenRingTools.Utils;

namespace EldenRingTools.ViewModels;

public partial class CoopViewModel : ObservableObject
{
    /// <summary>
    /// 游戏主程序路径
    /// </summary>
    [ObservableProperty]
    private string gameExePath;
    /// <summary>
    /// 联机用户昵称
    /// </summary>
    [ObservableProperty]
    private string coopAccountName;
    /// <summary>
    /// 联机SteamId
    /// </summary>
    [ObservableProperty]
    private string coopSteamId;
    /// <summary>
    /// 联机密码
    /// </summary>
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
        Growl.Success("eldenring.exe 文件路径选择成功");
    }

    [RelayCommand]
    private void OpenGameDir()
    {
        if (!File.Exists(GameExePath))
        {
            Growl.Warning("请选择 eldenring.exe 文件位置");
            return;
        }

        var fileInfo = new FileInfo(GameExePath);
        ProcessUtil.OpenLinkOrDir(fileInfo.DirectoryName);
    }

    [RelayCommand]
    private void OpenModDir()
    {
        if (!File.Exists(GameExePath))
        {
            Growl.Warning("请选择 eldenring.exe 文件位置");
            return;
        }

        var fileInfo = new FileInfo(GameExePath);
        var tempDir = Path.Combine(fileInfo.DirectoryName, "mod");
        if (!Directory.Exists(tempDir))
        {
            Growl.Warning("游戏目录 mod 文件夹不存在");
            return;
        }

        ProcessUtil.OpenLinkOrDir(tempDir);
    }

    [RelayCommand]
    private void OpenModsDir()
    {
        if (!File.Exists(GameExePath))
        {
            Growl.Warning("请选择 eldenring.exe 文件位置");
            return;
        }

        var fileInfo = new FileInfo(GameExePath);
        var tempDir = Path.Combine(fileInfo.DirectoryName, "mods");
        if (!Directory.Exists(tempDir))
        {
            Growl.Warning("游戏目录 mods 文件夹不存在");
            return;
        }

        ProcessUtil.OpenLinkOrDir(tempDir);
    }

    [RelayCommand]
    private void OpenArchiveDir()
    {
        var tempDir = Path.Combine(FileUtil.Dir_ApplicationData, "EldenRing");
        if (!Directory.Exists(tempDir))
        {
            Growl.Warning("Elden Ring 存档文件夹不存在");
            return;
        }

        ProcessUtil.OpenLinkOrDir(tempDir);
    }

    [RelayCommand]
    private void OpenSteamEmuDir()
    {
        var tempDir = Path.Combine(FileUtil.Dir_ApplicationData, "Goldberg SteamEmu Saves");
        if (!Directory.Exists(tempDir))
        {
            Growl.Warning("SteamEmu 文件夹不存在");
            return;
        }

        ProcessUtil.OpenLinkOrDir(tempDir);
    }
}
