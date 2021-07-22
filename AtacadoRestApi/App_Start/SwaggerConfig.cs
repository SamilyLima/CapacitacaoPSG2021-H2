using System.Web.Http;
using WebActivatorEx;
using AtacadoRestApi;
using Swashbuckle.Application;
using System;
using System.Xml.XPath;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace AtacadoRestApi
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        
                        c.Schemes(new[] { "http", "https" });
                        c.SingleApiVersion("v1", "AtacadoRestApi");
                        c.PrettyPrint();
                        c.IncludeXmlComments(GetXmlCommentsPath());
                     })
                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle("AtacadoRestApi - Swagger UI");
                        c.DocExpansion(DocExpansion.List);

                      });
        }

        private static string GetXmlCommentsPath()
        {
            return string.Format(@"{0}\Docs\AtacadoRestApi.xml",
                System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
