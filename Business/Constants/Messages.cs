using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";

        public static string ProductNameInvalied = "Ürün İsmi Geçersiz";
        public static string ProductListed = "Ürünler Listelendi ";
        public static string MaintenaceTime = "Sistem Bakımda";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists = "Aynı isimde ürün eklenemez";
        public static string CategoryLimitExceded = "Kategori limiti aşıldı";
    }
}
