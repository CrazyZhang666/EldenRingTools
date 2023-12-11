namespace EldenRingTools.Utils;

public static class FileUtil
{
    public static string Dir_ApplicationData { get; private set; }

    static FileUtil()
    {
        Dir_ApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    }

    /// <summary>
    /// 创建文件夹，如果文件夹存在则不创建
    /// </summary>
    /// <param name="dirPath"></param>
    public static void CreateDirectory(string dirPath)
    {
        if (!Directory.Exists(dirPath))
            Directory.CreateDirectory(dirPath);
    }

    /// <summary>
    /// 从资源文件中抽取资源文件
    /// </summary>
    /// <param name="resFileName">资源文件路径</param>
    /// <param name="outputPath">输出文件路径</param>
    public static void ExtractResFile(string resFileName, string outputPath)
    {
        BufferedStream inStream = null;
        FileStream outStream = null;

        try
        {
            var assembly = Assembly.GetExecutingAssembly();
            inStream = new BufferedStream(assembly.GetManifestResourceStream(resFileName));
            outStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            int length;
            var buffer = new byte[1024];

            while ((length = inStream.Read(buffer, 0, buffer.Length)) > 0)
                outStream.Write(buffer, 0, length);

            outStream.Flush();
        }
        finally
        {
            outStream?.Close();
            inStream?.Close();
        }
    }
}
