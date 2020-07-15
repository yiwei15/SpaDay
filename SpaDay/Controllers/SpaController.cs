using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaDay.Controllers
{
    
    public class SpaController : Controller
    {
        

        //Contains the logic to determine which facial treatments are appropriate for which skin type.
        public bool CheckSkinType(string skinType, string facialType)
        {

            if (facialType != "Microdermabrasion")
            {
                if (skinType == "oily" && facialType != "Rejuvenating")
                {
                    return false;
                }
                else if (skinType == "combination" && (facialType != "Rejuvenating" || facialType != "Enzyme Peel"))
                {
                    return false;
                }
                else if (skinType == "dry" && facialType != "Hydrofacial")
                {
                    return false;
                }
            }

            return true;

        }

        //Returns the Spa/Index view when GET requests are made to /spa/.
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //Returns the Spa/Menu view when POST requests are made to /spa/
        [HttpPost]
        [Route("/spa")]
        public IActionResult Menu(string name, string skintype, string manipedi)
        {
            ViewBag.name = name;
            ViewBag.skintype = skintype;
            ViewBag.manipedi = manipedi;
            
            List<string> facials = new List<string>()
            {
                "Microdermabrasion", "Hydrofacial", "Rejuvenating", "Enzyme Peel"
            };


            List<string> appropriateFacials = new List<string>();
            for (int i = 0; i < facials.Count; i++)
            {
                if (CheckSkinType(skintype, facials[i]))
                {
                    appropriateFacials.Add(facials[i]);
                }
            }

            ViewBag.appropriateFacials = appropriateFacials;

            return View();
        }

    }
}
