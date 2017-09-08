using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YWC15.Controllers {
    public class HomeController : Controller {

        //string[,] CardALL = new string[13, 4] {{'2', '3', '4', '5', '6', '7', '8', '9', '0', 'J','Q', 'K', 'A'},
        //                             {"d","e","f"},
        //                             {"g","h","i"} };

        //'2', '3', '4', '5', '6', '7', '8', '9', '0', 'J','Q', 'K', 'A'
        //('C', 'D', 'H', 'S')

        string[] CardType = { "C", "D", "H", "S" };
        string[] CardNumber = { "2", "3", "4", "5", "6", "7", "8", "9", "0", "J", "Q", "K", "A" };
      

        public ActionResult Index(string cardnumber) {
            int n;

            if (cardnumber != null) {

                if (int.TryParse(cardnumber, out n)) {
                    int type = 0;
                    int card = 0;
                    int count = 0;

                    if (n <= 51 && n >= 0) {
                        while (n > 0) {
                            card++;
                            count++;
                            n--;

                            if (count == 13) {
                                type++;
                                count = 0;
                            }
                        }
                        string result = CardNumber[count] + CardType[type];

                        ViewBag.CardResult = result;
                        return View();
                    } else {
                        ViewBag.CardResult = "ห้ามกรอกเกิน 52 ใบ (0-51)";
                        return View();
                    }
                } else {
                    ViewBag.CardResult = "โปรกรอกตัวเลข";
                    return View();
                }
            }
            ViewBag.CardResult = "โปรดกรอกการ์ดที่ต้องการ";
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}