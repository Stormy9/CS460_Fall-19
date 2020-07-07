using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// added just for this:
using System.Drawing;

namespace CS460_Hwk04.Controllers
{
    public class ColorInterpolatorController : Controller
    {
        // GET: ColorInterpolator
        public ActionResult Create()
        {
            ViewBag.Title = "Color Interpolator!";
            ViewBag.Message = "Interpolate from one color to another...";
            ViewBag.Instructions_a = "Put in two colors in HTML hexadecimal format, i.e.";
            ViewBag.Instructions_b = "#cac, #d3a5c1 <= including the '#'";

            return View();
        }
        //===============================================================================
        [HttpPost]
        // `int` is a nullable type -- hence the `?` after it in the params
        public ActionResult Create(string color_one, string color_two,
                                                                    int? number_colors)
        {
            // was everything passed in -- and corretly?  Did it parse okay?
            if (ModelState.IsValid)             // then carry on.....
            {
                // since int may be null..... (a default int = 0)
                int n_c = number_colors.GetValueOrDefault();

                // make a list for the two colors passed in:
                // we can't do just 'color' because that's a thing in here
                IList<Colors> output = new List<Colors>();

                // we will create our list empty, and fill it w/a for-loop:
                // (so we can do a lot of them for demo purposes)
                for (int i = 0; i < 10; i++)
                {
                    output.Add(new Colors { color_one = color_one, color_two = color_two,
                                            number_colors = i }) ;
                    // note error with doing `number colors = number_colors`: 
                    //      'cannot implicitly convert type `int?` to `int`
                    //      'An explicit conversion exists (are you missing a cast?)
                    //
                    //      we'll just keep filling it up like in the example video.....
                    //      and figure out the casting later to try returning some math
                }

                ViewBag.ColorList = output;


                ViewBag.ColorOne = color_one;
                ViewBag.ColorTwo = color_two;

                // our 'flag' to know if to display anything in view, or not:
                // we could define it as anything, but this seems logical.....
                ViewBag.Okay = true;

                ViewBag.Title = "Color Interpolator!";
                ViewBag.Message = "Interpolate from one color to another...";
                ViewBag.Instructions_a = "Put in two colors in HTML hexadecimal format, i.e.";
                ViewBag.Instructions_b = "#cac, #d3a5c1 <= including the '#'";

                return View();
            }
            //
            //
            else        // someone done screwed something up somewhere.....
            {           // although should that happen, w/client-side validation?
                        // it won't let them submit a screwed-up form to begin with.....

                // borroed from Lecture/Example 2 video.....
                // i'd rather send them to a "you goofed" page, 
                //      but don't have time to make one right now.....
                return RedirectToAction("Index", "Home");

                // because this would piss them off -- the other may make them laugh   [=
            }
        }
        //===============================================================================
        // "this is not the way to do this, but it's the start of a model object....."
        // this will be the object type for our Color_List up there ^^^^^

        // internal `struct` -- could also do a `class` (but i've never made a `struct`):
        public struct Colors
        {
            // what is a "color", in our context?   note `public` on these.....
            public string color_one { get; set; }
            public string color_two { get; set; }
            public int number_colors { get; set; }

            // "we're using 'properties' for these b/c that's super-easy"
            // "normally this would go in the `Models` folder but this is quick & easy"
        }



        //===============================================================================
        //===============================================================================
        // brought in from Lab Instruction Sheet.....
        // From Greg's answer: 
        //https://stackoverflow.com/questions/359612/how-to-change-rgb-color-to-hsv/1626175
        // And Wikipedia: https://en.wikipedia.org/wiki/HSL_and_HSV
        public static void ColorToHSV(Color color, out double hue, 
                                        out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }
        //===============================================================================
        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
            {
                return Color.FromArgb(255, v, t, p);
            }
            else if (hi == 1)
            {
                return Color.FromArgb(255, q, v, p);
            }
            else if (hi == 2)
            {
                return Color.FromArgb(255, p, v, t);
            }
            else if (hi == 3)
            {
                return Color.FromArgb(255, p, q, v);
            }
            else if (hi == 4)
            {
                return Color.FromArgb(255, t, p, v);
            }
            else
            {
                return Color.FromArgb(255, v, p, q);
            }
        }
    }
}