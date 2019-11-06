using System.Collections.Generic;
using System.IO;
using UnityEditor;

public class CreateAssetBundles
{
	private static readonly Dictionary<BuildTarget, string> _outdirs = new Dictionary<BuildTarget, string>
	{
		{ BuildTarget.StandaloneWindows64, "Windows" },
		{ BuildTarget.StandaloneLinux64, "Linux" },
		{ BuildTarget.StandaloneOSX, "Mac" },
	};


	[MenuItem("Assets/Bundle Asset/All", priority = 0)]
	static void BuildAllAssetBundles()
	{
		foreach (var buildTarget in _outdirs.Keys)
		{
            BuildAssetBundle(buildTarget);
		}
	}

	[MenuItem("Assets/Bundle Asset/Windows", priority = 20)]
	static void BuildWindowsAssetBundles()
	{
        BuildAssetBundle(BuildTarget.StandaloneWindows64);
    }

    [MenuItem("Assets/Bundle Asset/Linux", priority = 21)]
    static void BuildLinuxAssetBundles()
    {
        BuildAssetBundle(BuildTarget.StandaloneLinux64);
    }

    [MenuItem("Assets/Bundle Asset/Mac", priority = 22)]
    static void BuildMacAssetBundles()
    {
        BuildAssetBundle(BuildTarget.StandaloneOSX);
    }

    static void BuildAssetBundle(BuildTarget buildTarget)
    {
        string path = string.Format("AssetBundles/{0}", _outdirs[buildTarget]);
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, buildTarget);
    }
}
