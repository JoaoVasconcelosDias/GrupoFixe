using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;
using Microsoft.AspNetCore.Authorization;
using System.Web;
using System.Text; 
using System.CodeDom.Compiler; 
using System.Reflection;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        public static object CodeDomProvider { get; private set; }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your C# compiler!";

            return View();
        }

        [HttpPost]
        public ActionResult About(string FirstCompile)
        {
            List<string> errors = new List<string>();
            List<string> output = new List<string>();
            CompilerResults compilerResults = ProcessCompilation(FirstCompile);

            foreach (CompilerError error in compilerResults.Errors)
            {
                errors.Add(String.Format("Line {0} Error No:{1} -  {2}", error.Line, error.ErrorNumber, error.ErrorText));
            }

            foreach (String s in compilerResults.Output)
            {
                output.Add(s);

            }

            // se nao houver erros, executa
            //object obj1 = compilerResults.CompiledAssembly.EntryPoint.Invoke(null, null);  // apenas esta a dar o retorno do void! como ele é nulo, da me nulo! se eu pedisse o retorno de um inteiro, ele dava
            //object obj1 = compilerResults.CompiledAssembly.GetType("HelloWorld").GetMethod("Main").Invoke(null, null);

            var scriptClass = compilerResults.CompiledAssembly.GetType("HelloWorld");
            var scriptMethod1 = scriptClass.GetMethod("Main1", BindingFlags.Static | BindingFlags.Public);



            //return View(scriptMethod1.Invoke(null, new object[] { }));
            return View((object)scriptMethod1.Invoke(null, new object[] { }));
        }

       
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        //metodo!
        public static CompilerResults ProcessCompilation(string programText)
        {
            CodeDomProvider codeDomProvider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = true;
            parameters.GenerateInMemory = true;
            //parameters.OutputAssembly = "OutputAssembly.dll";
            //parameters.OutputAssembly = "OutputAssembly.exe";
            System.Collections.Specialized.StringCollection assemblies = new System.Collections.Specialized.StringCollection();
            return codeDomProvider.CompileAssemblyFromSource(parameters, programText);

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


/*
using System;

public class HelloWorld
{
    public static void Main()
    {
        Console.WriteLine("Hello world!");
    }
}
*/


//necessario um model para a consola?
//public class CompilerProgram
// {
// public string programText { get; set; }
// }