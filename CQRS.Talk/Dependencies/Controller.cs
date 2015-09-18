using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Talk.Dependencies
{
    public class Controller
    {
        // Fake Controller class

        public ActionResult View(object @object)
        {
            return new ActionResult();
        }


        public ActionResult RedirectToAction(String action, String controller)
        {
            return new ActionResult();
        }


        public ActionResult RedirectToAction(String action, String controller, object parameter)
        {
            return new ActionResult();
        }
    }


    public class ActionResult
    {
        // Fake 
    }


}
