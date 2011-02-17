using System.Web.Mvc;

namespace NoStressWedding.Areas.Services {
  public class ServicesAreaRegistration : AreaRegistration {
    public override string AreaName {
      get {
        return "Services";
      }
    }

    public override void RegisterArea(AreaRegistrationContext context) {
      context.MapRoute(
          "Services_default",
          "Services/{controller}/{action}/{id}",
          new { action = "Index", id = UrlParameter.Optional }
      );
    }
  }
}
