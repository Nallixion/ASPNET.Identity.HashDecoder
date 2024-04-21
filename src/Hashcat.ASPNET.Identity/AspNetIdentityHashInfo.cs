using System.Globalization;
using NetDevPack.Utilities;

namespace Hashcat.ASPNET.Identity;

public class AspNetIdentityHashInfo
{
    public AspNetIdentityHashInfo(string base64Hash){
        HexHash = base64Hash.FromBase64().ToPlainHexDumpStyle();
        Hash = base64Hash;
        var hashVersion = HexHash.Substring(0, 2);
        switch (hashVersion)
        {
            case "01":
                HashVersion = AspNetIdentityHashVersion.PBKDF2_HMAC_SHA256;
                GetV3Info();
                break;
            case "00":
                HashVersion = AspNetIdentityHashVersion.PBKDF2_HMAC_SHA1;
                GetV2Info();
                break;
            default:
                throw new Exception("Invalid hash version");
        }
    }

    private void GetV2Info()
    {
        HexSalt = HexHash.Substring(2, 34);
        HexSubKey = HexHash.Substring(34);
        Salt = HexSalt.FromPlainHexDumpStyleToByteArray().ToBase64();
        SubKey = HexSubKey.FromPlainHexDumpStyleToByteArray().ToBase64();
        IterCount = 1000;
        ShaType = "sha1";
        HashcatFormat = $"sha1:{IterCount}:{Salt}:{SubKey}";
    }

    private void GetV3Info(){
        HexPrf = HexHash.Substring(2, 8);
        HexIterCount = HexHash.Substring(10, 8);
        HexSaltLength = HexHash.Substring(18, 8);
        HexSalt = HexHash.Substring(26, 32);
        HexSubKey = HexHash.Substring(58, 64);
        IterCount = int.Parse(HexIterCount, NumberStyles.HexNumber);
        SaltLength = int.Parse(HexSaltLength, NumberStyles.HexNumber) * 8;
        Salt = HexSalt.FromPlainHexDumpStyleToByteArray().ToBase64();
        SubKey = HexSubKey.FromPlainHexDumpStyleToByteArray().ToBase64();
        HashcatFormat = $"sha256:{IterCount}:{Salt}:{SubKey}";
        ShaType = "sha256";
    }

    public string ShaType { get; set; }

    public string HashcatFormat { get; set; }

    public string SubKey { get; set; }

    public string Salt { get; set; }

    public int SaltLength { get; set; }

    public int IterCount { get; set; }

    public string HexSubKey { get; set; }

    public string HexSalt { get; set; }

    public string HexSaltLength { get; set; }

    public string HexIterCount { get; set; }

    public string HexPrf { get; set; }

    public AspNetIdentityHashVersion HashVersion { get; set; }
    public string HexHash { get; set; }
    public string Hash { get; set; }
}

public enum AspNetIdentityHashVersion{
    PBKDF2_HMAC_SHA1 = 0,
    PBKDF2_HMAC_SHA256 = 1,
    PBKDF2_HMAC_SHA512 = 2
}
