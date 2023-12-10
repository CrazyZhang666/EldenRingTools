namespace EldenRingTools.Utils;

public class ProcessUtil
{
    /// <summary>
    /// 打开http链接或者文件夹路径
    /// </summary>
    /// <param name="url"></param>
    public static void OpenLinkOrDir(string url)
    {
        Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
    }

    /// <summary>
    /// 打开指定进程，可以附带运行参数
    /// </summary>
    /// <param name="path">本地文件夹路径</param>
    /// <param name="args">可选参数</param>
    public static void OpenProcess(string path, string args = "")
    {
        Process.Start(path, args);
    }
}
