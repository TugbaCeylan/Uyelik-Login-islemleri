using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCUser.Models
{
    public class FxFonksiyon
    {
        public static string GetInformation(MessageFormat information)
        {
            string bilgi = null;
            switch (information)
            {
                case MessageFormat.OK:
                    bilgi = "Başarıyla tamamlanmıştır."; break;
                case MessageFormat.Err:
                    bilgi = "Bir hata oluştu."; break;
                case MessageFormat.Val:
                    bilgi = "Lütfen tüm alanları doğru formatta doldurunuz.";
                    break;
            }
            return bilgi;
        }
    }
}