using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantFinder.Controllers
{
    
    public class LoggerCls 
    {
        //log klasörünün projedeki yerini open folder ile path değişkenine atarız. Sonuna bir \ daha koyarız.
        string _Path = @"C:\Users\grona\OneDrive\Masaüstü\RestaurantFinder\RestaurantFinder\Log\";
        //Dosyanın adı için : Dosyanın adı genelde bugünün tarihi olur.
        string _FileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";
        
        //Log oluşturma metodu. Parametre olarak içinde string şeklinde bilgi tutacak.
        //Bu metoddan önce log klasörünü projeye sağ tık ile dahil etmemiz gerkiyor.
        //Log klasörü gözükmediyse show all files a tıklayınca geliyor.
        public void CreateLog(string message)
        {
            // _Path : doyanın yolu + Dosya adı , Dosyanın modu (açma , kapama vs.) ,Yapılacak işlem
            FileStream fs = new FileStream(_Path + _FileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter  sw = new StreamWriter(fs);
            //Mesajı bugünün tarihinin yanına yazdırması için datetime eklenir.
            sw.WriteLine(DateTime.Now.ToString() + message);
            sw.Flush();
            //Açtıklarımızı tek tek kapatmamız gerekir.
            sw.Close();
            fs.Close();
        }
        //!!!!!!!!!!!!!!!!!!!!!!!!!!
        //Bu loglamayı hazırda yazdığımız controllerlarda test ederiz . Bu yüzden projeye ait sınıf controllerlarında ki http isteklerinin içerisine de kodlama yapmamız gerkir...

    }
}
