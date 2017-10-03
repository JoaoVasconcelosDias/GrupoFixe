using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Consola_experiment.Models;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace Consola_experiment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your C# compiler!";
            return View();
        }


        //metodo
        public class CSharpScriptEngine
        {
            private static ScriptState<object> scriptState = null;
            public static object Execute(string code)
            {
                scriptState = scriptState == null ? CSharpScript.RunAsync(code).Result : scriptState.ContinueWithAsync(code).Result;
                if (scriptState.ReturnValue != null && !string.IsNullOrEmpty(scriptState.ReturnValue.ToString()))
                    return scriptState.ReturnValue;
                return null;
            }


        }

        
        [HttpPost]
        public IActionResult About(string FirstCompile)
        {
            //CSharpScriptEngine.Execute(FirstCompile);
            object resultado = CSharpScriptEngine.Execute(FirstCompile);

            //resultado.ToString();

            /*@"
        using System;
        public class ScriptedClass
        {
            public String HelloWorld {get;set;}
            public ScriptedClass()
            {
                HelloWorld = ""Hello Roslyn!"";
            }
        }"*/

            //Console.WriteLine(CSharpScriptEngine.Execute("new ScriptedClass().HelloWorld"));

            return View(CSharpScriptEngine.Execute("new ScriptedClass().HelloWorld"));
            //return resultado.ToString();
            



        }
        //CSharpScript.EvaluateAsync(@"using System;Console.WriteLine(""Hello Roslyn."");").Wait();





        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
