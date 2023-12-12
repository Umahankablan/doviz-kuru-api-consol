////using System;
////using System.Net.Http;
////using HtmlAgilityPack;
////using System.Threading.Tasks;
////using System.Collections.Generic;


////namespace ConsoleApp1
////{
////    internal class Program
////    {
////        static async Task Main(string[] args)
////        {
////            string url = "https://www.tcmb.gov.tr/kurlar/today.xml";
////            var httpClient = new HttpClient();
////            var html = await httpClient.GetStringAsync(url);

////            var htmlDocument = new HtmlDocument();
////            htmlDocument.LoadHtml(html);


////            var dolarNode = htmlDocument.DocumentNode.SelectSingleNode("//tr[@class='dolar']");

////            if (dolarNode != null)
////            {
////                var currencyName = dolarNode.SelectSingleNode(".//td[1]").InnerText;
////                var ForexBuying = dolarNode.ForexBuying(".//td[3]").InnerText;
////                //var buyingRate = dolarNode.SelectSingleNode(".//td[3]").InnerText;
////                var ForexSelling = dolarNode.BanknoteSelling(".//td[4]").InnerText;
////                // var sellingRate = dolarNode.SelectSingleNode(".//td[4]").InnerText;

////                Console.WriteLine($"{currencyName}: Alış {ForexBuying}, Satış {ForexSelling}");
////                // Console.WriteLine($"{currencyName}: Alış {buyingRate}, Satış {sellingRate}");
////            }
////            else
////            {
////                Console.WriteLine("Dolar kuru bulunamadı.");
////            }
////        }
////    }
////}


//using System;
//using System.Net.Http;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    internal class Program
//    {
//        static async Task Main(string[] args)
//        {
//            string url = "https://www.tcmb.gov.tr/kurlar/today.xml";
//            var httpClient = new HttpClient();
//            var html = await httpClient.GetStringAsync(url);

//            // Kullanacağınız düzenli ifadeyi burada tanımlayın.
//            // Örneğin, dolar alış ve satış fiyatlarını çıkarmak için:
//            string regexPattern = @"<tr class=""dolar"">\s*<td>.*?<\/td>\s*<td>(.*?)<\/td>\s*<td>(.*?)<\/td>\s*<td>(.*?)<\/td>";

//            var match = Regex.Match(html, regexPattern);

//            if (match.Success)
//            {
//                var currencyName = match.Groups[1].Value;
//                var ForexBuying = match.Groups[2].Value;
//                var ForexSelling = match.Groups[3].Value;

//                Console.WriteLine($"{currencyName}: Alış {ForexBuying}, Satış {ForexSelling}");
//            }
//            else
//            {
//                Console.WriteLine("Dolar kuru bulunamadı.");
//                Console.ReadKey();
//            }
//        }
//    }
//}



//using System;
//using System.Net.Http;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    internal class Program
//    {
//        static async Task Main(string[] args)
//        {
//            string url = "https://www.tcmb.gov.tr/kurlar/today.xml";
//            var httpClient = new HttpClient();
//            var html = await httpClient.GetStringAsync(url);

//            // Kullanacağınız düzenli ifadeyi burada tanımlayın.
//            // Örneğin, dolar alış ve satış fiyatlarını çıkarmak için:
//            string regexPattern = @"<tr class=""dolar"">\s*<td>.*?<\/td>\s*<td>(.*?)<\/td>\s*<td>(.*?)<\/td>\s*<td>(.*?)<\/td>";

//            var match = Regex.Match(html, regexPattern);

//            if (match.Success)
//            {
//                var currencyName = match.Groups[1].Value;
//                var ForexBuying = match.Groups[2].Value;
//                var ForexSelling = match.Groups[3].Value;

//                Console.WriteLine($"Dolar Kuru: Alış {ForexBuying}, Satış {ForexSelling}");
//            }
//            else
//            {
//                Console.WriteLine("Dolar kuru bulunamadı.");
//                Console.ReadKey();
//            }
//        }
//    }
//}



//using System;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Xml.Linq;

//namespace ConsoleApp1
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {
//            string url = "https://www.tcmb.gov.tr/kurlar/today.xml";
//            var httpClient = new HttpClient();
//            var response = await httpClient.GetAsync(url);

//            if (response.IsSuccessStatusCode)
//            {
//                var content = await response.Content.ReadAsStringAsync();
//                var xmlDocument = XDocument.Parse(content);

//                var dolarElement = xmlDocument.Descendants("Currency").FirstOrDefault(x => x.Attribute("Kod")?.Value == "USD");
//                if (dolarElement != null)
//                {
//                    var ForexBuying = dolarElement.Element("ForexBuying")?.Value;
//                    var ForexSelling = dolarElement.Element("ForexSelling")?.Value;

//                    Console.WriteLine($"US DOLLAR: Alış {ForexBuying}, Satış {ForexSelling}");
//                }
//                else
//                {
//                    Console.WriteLine("Dolar kuru bulunamadı veya hata oluştu."); // Hata mesajını değiştirin
//                }
//            }
//            else
//            {
//                Console.WriteLine("HTTP isteği başarısız oldu. Lütfen bağlantınızı kontrol edin."); // Hata mesajını değiştirin
//            }
//        }
//    }
//}

//using System;
//using System.Xml;

//namespace ConsoleApp1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string xmlContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
//                <Tarih_Date Tarih=""09.10.2023"" Date=""10/09/2023"" Bulten_No=""2023/192"">
//                    <Currency CrossOrder=""0"" Kod=""USD"" CurrencyCode=""USD"">
//                        <Unit>1</Unit>
//                        <Isim>ABD DOLARI</Isim>
//                        <CurrencyName>US DOLLAR</CurrencyName>
//                        <ForexBuying>27.6559</ForexBuying>
//                        <ForexSelling>27.7058</ForexSelling>
//                        <BanknoteBuying>27.6366</BanknoteBuying>
//                        <BanknoteSelling>27.7473</BanknoteSelling>
//                        <CrossRateUSD/>
//                        <CrossRateOther/>
//                    </Currency>
//                </Tarih_Date>";

//            XmlDocument xmlDoc = new XmlDocument();
//            xmlDoc.LoadXml(xmlContent);

//            string dolarKod = "USD"; // Çekmek istediğiniz döviz kodu

//            XmlNode dolarNode = xmlDoc.SelectSingleNode($"/Tarih_Date/Currency[@Kod='{dolarKod}']");
//            if (dolarNode != null)
//            {
//                string alisFiyati = dolarNode.SelectSingleNode("ForexBuying")?.InnerText;
//                string satisFiyati = dolarNode.SelectSingleNode("ForexSelling")?.InnerText;

//                Console.WriteLine($"Döviz Kodu: {dolarKod}");
//                Console.WriteLine($"Döviz Alış Fiyatı: {alisFiyati}");
//                Console.WriteLine($"Döviz Satış Fiyatı: {satisFiyati}");
//                Console.ReadKey();
//            }
//            else
//            {
//                Console.WriteLine("Belirtilen döviz kodu bulunamadı.");

//            }
//        }
//    }
//}





using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(content);

                string dolarKodu = "USD"; // İlgilenilen döviz kodu (örneğin, ABD Doları)
                string euroKodu = "EUR"; // Euro'nun döviz kodu
                string sterlingKodu = "GBP"; // ingiliz sterlini döviz kodu
                string frankKodu = "CHF"; // isviçre frangı döviz kodu

                XmlNode dolarNode = xmlDoc.SelectSingleNode($"/Tarih_Date/Currency[@Kod='{dolarKodu}']");
                XmlNode euroNode = xmlDoc.SelectSingleNode($"/Tarih_Date/Currency[@Kod='{euroKodu}']");
                XmlNode sterlingNode = xmlDoc.SelectSingleNode($"/Tarih_Date/Currency[@Kod='{sterlingKodu}']");
                XmlNode frankNode = xmlDoc.SelectSingleNode($"/Tarih_Date/Currency[@Kod='{frankKodu}']");

                if (dolarNode != null && euroNode != null && sterlingNode != null && frankNode != null )
                {
                    string alisFiyatiDolar = dolarNode.SelectSingleNode("ForexBuying")?.InnerText;
                    string satisFiyatiDolar = dolarNode.SelectSingleNode("ForexSelling")?.InnerText;
                    string alisFiyatiEuro = euroNode.SelectSingleNode("ForexBuying")?.InnerText;
                    string satisFiyatiEuro = euroNode.SelectSingleNode("ForexSelling")?.InnerText;
                    string alisFiyatisterling = sterlingNode.SelectSingleNode("ForexBuying")?.InnerText;
                    string satisFiyatisterling = sterlingNode.SelectSingleNode("ForexSelling")?.InnerText;
                    string alisFiyatifrank = frankNode.SelectSingleNode("ForexBuying")?.InnerText;
                    string satisFiyatifrank = frankNode.SelectSingleNode("ForexSelling")?.InnerText;

                   // Console.WriteLine($"Döviz Kodu: {dolarKodu}");
                    Console.WriteLine($"Dolar Alış Fiyatı: {alisFiyatiDolar}");
                    Console.WriteLine($"Dolar Satış Fiyatı: {satisFiyatiDolar}");
                    Console.WriteLine($"Euro Alış Fiyatı: {alisFiyatiEuro}");
                    Console.WriteLine($"Euro Satış Fiyatı: {satisFiyatiEuro}");
                    Console.WriteLine($"ingiliz Sterling Alış Fiyatı :{alisFiyatisterling}");
                    Console.WriteLine($"ingiliz Sterling Satış Fiyatı : {satisFiyatisterling}");
                    Console.WriteLine($"isviçre Frank Alış Fiyatı : {alisFiyatifrank}");
                    Console.WriteLine($"isviçre Frank Satış Fiyatı :{satisFiyatifrank}");
                
                    Console.ReadKey();

                }
                else
                {
                    Console.WriteLine("Belirtilen döviz kodu bulunamadı.");
                  
                }
            }
            else
            {
                Console.WriteLine("HTTP isteği başarısız oldu. Lütfen bağlantınızı kontrol edin.");
               
            }
        }
    }
}
