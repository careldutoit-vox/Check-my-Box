using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.Collections;
using System.Security.Principal;
using System.Linq.Expressions;
using System.Web.Routing;

namespace System.Web.Mvc.Html {

  #region Authorization
  public static class AuthorizationExtensions {
    private static Dictionary<Expression, AuthorizeAttribute[]> expressionAuthorizers = new Dictionary<Expression, AuthorizeAttribute[]>();

    /// <summary>
    /// Determines whether the specified action is authorized.
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam>
    /// <param name="helper">The helper.</param>
    /// <param name="actionMethod">The action method.</param>
    /// <returns>
    ///     <c>true</c> if the specified helper is authorized; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsAuthorized<TController>(this HtmlHelper helper, Expression<Action<TController>> action) {
      var call = action.Body as MethodCallExpression;

      if (call == null) return false;

      var authorizers = expressionAuthorizers.ContainsKey(action)
          ? expressionAuthorizers[action]
          : expressionAuthorizers[action] = GetAttributes<AuthorizeAttribute>(call);

      return (authorizers.Length > 0)
          ? authorizers.All(a => a.IsAuthorized(helper.ViewContext.HttpContext.User))
          : true;
    }

    /// <summary>
    /// Gets the specified attributes for an action method.
    /// </summary>
    /// <param name="call">The call.</param>
    /// <returns></returns>
    private static TAttribute[] GetAttributes<TAttribute>(MethodCallExpression call) where TAttribute : Attribute {
      return call.Object.Type.GetCustomAttributes(typeof(TAttribute), true)
          .Union(call.Method.GetCustomAttributes(typeof(TAttribute), true))
          .Cast<TAttribute>()
          .ToArray();
    }

    /// <summary>
    /// Determines whether the specified <see cref="AuthorizeAttribute"/> authorizes the specified user.
    /// </summary>
    /// <param name="authorize">The <see cref="AuthorizeAttribute"/>.</param>
    /// <param name="user">The user.</param>
    /// <returns>
    ///     <c>true</c> if the specified user is authorized; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsAuthorized(this AuthorizeAttribute authorize, IPrincipal user) {
      if (!user.Identity.IsAuthenticated) return false;

      var users = authorize.Users.SplitString();
      if (users.Length > 0 && !users.Contains(user.Identity.Name, StringComparer.OrdinalIgnoreCase)) return false;

      var roles = authorize.Roles.SplitString();
      if (roles.Length > 0 && !roles.Any(user.IsInRole)) return false;

      return true;
    }

    /// <summary>
    /// Splits and trims the specified string.
    /// </summary>
    /// <param name="original">The original.</param>
    /// <returns></returns>
    public static string[] SplitString(this string original) {
      return string.IsNullOrEmpty(original)
          ? new string[0]
          : original.Split('.').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToArray();
    }
  }
  #endregion

  #region Link using authorization
  public static class LinkExtensions {
    /// <summary>
    /// Render an HTML action link if authorized by the target action.
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam>
    /// <param name="helper">The helper.</param>
    /// <param name="action">The action.</param>
    /// <param name="linkText">The link text.</param>
    /// <returns></returns>
    public static IHtmlString AuthorizedActionLink<TController>(this HtmlHelper helper, Expression<Action<TController>> action, string linkText)
        where TController : Controller {
      return AuthorizedActionLink<TController>(helper, action, linkText, null);
    }

    /// <summary>
    /// Render an HTML action link if authorized by the target action.
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam>
    /// <param name="helper">The helper.</param>
    /// <param name="action">The action.</param>
    /// <param name="linkText">The link text.</param>
    /// <param name="htmlAttributes">The HTML attributes.</param>
    /// <returns></returns>
    public static IHtmlString AuthorizedActionLink<TController>(this HtmlHelper helper, Expression<Action<TController>> action, string linkText, object htmlAttributes)
        where TController : Controller {

      var routeValuesFromExpression = ExpressionHelper.GetExpressionText(action);//ExpressionHelper.GetRouteValuesFromExpression<TController>(action);

      return helper.IsAuthorized(action) ? helper.RouteLink(linkText, routeValuesFromExpression, new RouteValueDictionary(htmlAttributes)) : null;
    }
  }
  #endregion
  public static class HtmlHelperExtensions {
    /// <summary>
    /// Overloaded method to include Area mapping 
    /// </summary>
    /// <param name="htmlHelper"></param>
    /// <param name="linkText"></param>
    /// <param name="action"></param>
    /// <param name="controller"></param>
    /// <param name="areaName"></param>
    /// <returns></returns>
    public static IHtmlString ActionLinkSecure(
      this HtmlHelper htmlHelper,
        string linkText,
        string action,
        string controller,
        string areaName,
        object routeValues, object htmlAttributes
      ) {
        return SecurityTrimmedActionLink(htmlHelper, linkText, action, controller, areaName, false, routeValues, htmlAttributes);
    }
    /// <summary>
    /// Overload for areas without attributes
    /// </summary>
    /// <param name="htmlHelper"></param>
    /// <param name="linkText"></param>
    /// <param name="action"></param>
    /// <param name="controller"></param>
    /// <param name="areaName"></param>
    /// <param name="routeValues"></param>
    /// <param name="htmlAttributes"></param>
    /// <returns></returns>
    public static IHtmlString ActionLinkSecure(
      this HtmlHelper htmlHelper,
        string linkText,
        string action,
        string controller,
        string areaName
      ) {
      return SecurityTrimmedActionLink(htmlHelper, linkText, action, controller, areaName, false, null, null);
    }

    public static IHtmlString ActionLinkSecure(
        this HtmlHelper htmlHelper,
        string linkText,
        string action,
        string controller) {
      return SecurityTrimmedActionLink(htmlHelper, linkText, action, controller,"", false, null, null);
    }

    public static IHtmlString SecurityTrimmedActionLink(this HtmlHelper htmlHelper, string linkText
      , string action, string controller, string areaName, bool showDisabled, object routeValues, object htmlAttributes) {

      RouteValueDictionary routes = new RouteValueDictionary(routeValues);
      RouteValueDictionary attributes = new RouteValueDictionary(htmlAttributes);
      routes.Add("area", areaName);
      if (IsAccessibleToUser(action, controller)) {
        return htmlHelper.ActionLink(linkText, action, controller, routes , attributes);
      } else {
        return MvcHtmlString.Create(showDisabled ? String.Format("<span>{0}</span>", linkText) : "");
      }
    }
    public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText,
        string actionName, string controllerName, string areaName, object routeValues, object htmlAttributes) {
      RouteValueDictionary routes = new RouteValueDictionary(routeValues);
      RouteValueDictionary attributes = new RouteValueDictionary(htmlAttributes);
      routes.Add("area", areaName);
      return helper.ActionLink(linkText, actionName, controllerName, routes, attributes);
    }

    public static bool IsAccessibleToUser(string actionAuthorize, string controllerAuthorize) {
      Assembly assembly = Assembly.GetExecutingAssembly();
      GetControllerType(controllerAuthorize);
      Type controllerType = GetControllerType(controllerAuthorize);
      var controller = (IController)Activator.CreateInstance(controllerType);
      ArrayList controllerAttributes = new ArrayList(controller.GetType().GetCustomAttributes(typeof(AuthorizeAttribute), true));
      ArrayList actionAttributes = new ArrayList();
      MethodInfo[] methods = controller.GetType().GetMethods();
      foreach (MethodInfo method in methods) {
        object[] attributes = method.GetCustomAttributes(typeof(ActionNameAttribute), true);
        if ((attributes.Length == 0 && method.Name == actionAuthorize) || (attributes.Length > 0 && ((ActionNameAttribute)attributes[0]).Name == actionAuthorize)) {
          actionAttributes.AddRange(method.GetCustomAttributes(typeof(AuthorizeAttribute), true));
        }
      }
      if (controllerAttributes.Count == 0 && actionAttributes.Count == 0)
        return true;

      IPrincipal principal = HttpContext.Current.User;
      string roles = "";
      string users = "";
      if (controllerAttributes.Count > 0) {
        AuthorizeAttribute attribute = controllerAttributes[0] as AuthorizeAttribute;
        roles += attribute.Roles;
        users += attribute.Users;
      }
      if (actionAttributes.Count > 0) {
        AuthorizeAttribute attribute = actionAttributes[0] as AuthorizeAttribute;
        roles += attribute.Roles;
        users += attribute.Users;
      }

      if (string.IsNullOrEmpty(roles) && string.IsNullOrEmpty(users) && principal.Identity.IsAuthenticated)
        return true;

      string[] roleArray = roles.Split(',');
      string[] usersArray = users.Split(',');
      foreach (string role in roleArray) {
        if (role == "*" || principal.IsInRole(role))
          return true;
      }
      foreach (string user in usersArray) {
        if (user == "*" && (principal.Identity.Name == user))
          return true;
      }
      return false;
    }

    public static Type GetControllerType(string controllerName) {
      Assembly assembly = Assembly.GetExecutingAssembly();
      foreach (Type type in assembly.GetTypes()) {
        try {
          if (type.BaseType.Name == "Controller" && (type.Name.ToUpper() == (controllerName.ToUpper() + "Controller".ToUpper()))) {
            return type;
          }
        } catch { }
      }
      return null;
    }

  }
}