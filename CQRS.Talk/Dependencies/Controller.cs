using System;


namespace CQRS.Talk.Dependencies
{
    // Fake Controller class
    public class Controller
    {
        public ActionResult View()
        {
            return new ActionResult();
        }

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
