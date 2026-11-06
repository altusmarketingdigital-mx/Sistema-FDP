using System.Security.Cryptography;
using System.Text;

namespace ApiVentas.Security;

public static class EncriptacionService
{
    private const string LegacyKey = "UN1v4F4ctur43";

    public static string EncriptarContrasena(string texto)
    {
        if (string.IsNullOrEmpty(texto)) return string.Empty;

        byte[] arregloACifrar = Encoding.UTF8.GetBytes(texto);

        using var md5 = MD5.Create();
        byte[] keyArray = md5.ComputeHash(Encoding.UTF8.GetBytes(LegacyKey));

        using var tdes = TripleDES.Create();
        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        using var cTransform = tdes.CreateEncryptor();
        byte[] arrayResultado = cTransform.TransformFinalBlock(arregloACifrar, 0, arregloACifrar.Length);

        return Convert.ToBase64String(arrayResultado, 0, arrayResultado.Length);
    }

    public static string DesencriptarContrasena(string textoEncriptado)
    {
        if (string.IsNullOrEmpty(textoEncriptado)) return string.Empty;

        byte[] arrayADescifrar = Convert.FromBase64String(textoEncriptado);

        using var md5 = MD5.Create();
        byte[] keyArray = md5.ComputeHash(Encoding.UTF8.GetBytes(LegacyKey));

        using var tdes = TripleDES.Create();
        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        using var cTransform = tdes.CreateDecryptor();
        byte[] resultArray = cTransform.TransformFinalBlock(arrayADescifrar, 0, arrayADescifrar.Length);

        return Encoding.UTF8.GetString(resultArray);
    }
}
