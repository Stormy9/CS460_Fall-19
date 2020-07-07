using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS460_Hwk04.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //===============================================================================
        // GET: ~/Home/RGBColor
        [HttpGet]
        public ActionResult RGBColor()
        {
            ViewBag.Title = "Make some RGB Colors!";
            ViewBag.Message = "Put in some numbers and see what color you get...";

            string red = Request["red"];
            string green = Request["green"];
            string blue = Request["blue"];

            bool checkR = string.IsNullOrEmpty(red);
            bool checkG = string.IsNullOrEmpty(green);
            bool checkB = string.IsNullOrEmpty(blue);

            // see if there's something in the Request Objects
            // 'false' means they are *not* empty/null
            if (checkR == false && checkG == false && checkB == false)
            {
                ViewBag.RGB = "rgb(" + red + ", " + green + ", " + blue + ")";

                int fun = FunMath(red, green, blue);
                ViewBag.Math = "(those values add up to " + fun + ", by the way)";

                string hex = RGBtoHex(int.Parse(red), int.Parse(green), int.Parse(blue));
                ViewBag.Hex = "hex value => " + hex;
            }
            return View();
        }

        //===============================================================================
        /// <summary>
        ///     just wanted to try doing something with the input we got
        ///     with our GET method/Request Objects
        ///     
        ///     the params should be pretty obvious.....   [=
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns>
        ///     adds up all of the values of the RGB
        /// </returns>
        public int FunMath(string r, string g, string b)
        {
            int answer = (int.Parse(r) + int.Parse(g) + int.Parse(b));

            return answer;
        }
        //===============================================================================
        /// <summary>
        ///     make the RGB color format/code into Hex!
        ///     
        ///     again, the params should be pretty apparent.....   [=
        /// </summary>
        /// <param name="R"></param>
        /// <param name="G"></param>
        /// <param name="B"></param>
        /// <returns>
        ///     the Hex-ified Color Value!
        /// </returns>
        public string RGBtoHex(int R, int G, int B)
        {
            string hexValue = "#" + R.ToString("X2") + G.ToString("X2") + B.ToString("X2");
            return hexValue;
        }
        //===============================================================================

    }
}