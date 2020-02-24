using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ASP.NET_PROVA
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None; // (IPC) Utilizando "None", para remover os "$Id" adicionados pelo Entity Framework, retornando assim comente o resultado real do banco
            config.Formatters.Remove(config.Formatters.XmlFormatter);// (IPC) Utilizado pra remover o retorno xlm do serviço passando a utilizar o Json
            config.MapHttpAttributeRoutes();    

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
