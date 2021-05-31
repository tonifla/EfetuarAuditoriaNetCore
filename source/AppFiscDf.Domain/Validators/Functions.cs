using System;
using System.IO;

namespace AppFiscDf.Domain.Validators
{
    public static class Functions
    {
        internal static bool GetFileExtension(string value)
        {
            var extensionFile = Path.GetExtension(value);

            return (extensionFile.ToUpper()) switch
            {
                ".7Z" => true,
                ".BMP" => true,
                ".CSV" => true,
                ".EPS" => true,
                ".EXIF" => true,
                ".HTML" => true,
                ".ICO" => true,
                ".JPEG" => true,
                ".JPG" => true,
                ".JSON" => true,
                ".MP4" => true,
                ".MPEG" => true,
                ".OGG" => true,
                ".OGV" => true,
                ".PDF" => true,
                ".PNG" => true,
                ".PSD" => true,
                ".RAW" => true,
                ".SVE" => true,
                ".TAR" => true,
                ".TGZ" => true,
                ".TIF" => true,
                ".TIFF" => true,
                ".TXT" => true,
                ".WEBP" => true,
                ".XLS" => true,
                ".XLSX" => true,
                ".XML" => true,
                ".ZIP" => true,
                _ => false,
            };
        }

        internal static int GetCountString(string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;

            try
            {
                return value.ToString().Length;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}