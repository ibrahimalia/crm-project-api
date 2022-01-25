using Microsoft.AspNetCore.Mvc.ApplicationModels;

using System.Linq;

namespace Meta.IntroApp.Extensions
{
    public class SwaggerAreaControllerConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var controllerNamespace = controller.ControllerType.Namespace;
            var nameSpaceSections = controllerNamespace.Split(".").ToList();
            var areaSectionIndex = nameSpaceSections.IndexOf("Areas");
            if (areaSectionIndex == -1)
                controller.ApiExplorer.GroupName = "Common";
            else
                controller.ApiExplorer.GroupName = nameSpaceSections[areaSectionIndex + 1].Replace("App", "");
        }
    }
}
