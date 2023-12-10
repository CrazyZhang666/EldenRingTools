using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;

using EldenRingTools.Utils;

namespace EldenRingTools.ViewModels;

public partial class OtherViewModel : ObservableObject
{
    public OtherViewModel()
    {

    }

    [RelayCommand]
    private void OpenGameDir()
    {
        if (!File.Exists(Globals.GameExePath))
        {
            Growl.Warning("请选择 eldenring.exe 文件位置");
            return;
        }

        var fileInfo = new FileInfo(Globals.GameExePath);
        ProcessUtil.OpenLinkOrDir(fileInfo.DirectoryName);
    }

    [RelayCommand]
    private void OpenModDir()
    {
        if (!File.Exists(Globals.GameExePath))
        {
            Growl.Warning("请选择 eldenring.exe 文件位置");
            return;
        }

        var fileInfo = new FileInfo(Globals.GameExePath);
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
        if (!File.Exists(Globals.GameExePath))
        {
            Growl.Warning("请选择 eldenring.exe 文件位置");
            return;
        }

        var fileInfo = new FileInfo(Globals.GameExePath);
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
