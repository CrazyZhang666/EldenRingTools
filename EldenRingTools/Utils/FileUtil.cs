namespace EldenRingTools.Utils;

public static class FileUtil
{
    public static string Dir_ApplicationData { get; private set; }

    static FileUtil()
    {
        Dir_ApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    }
}
