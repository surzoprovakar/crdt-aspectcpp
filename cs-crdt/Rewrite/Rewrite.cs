using System.Text;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
// https://www.nuget.org/packages/Microsoft.CodeAnalysis.CSharp/

namespace cs_crdt.Rewrite {
    public class Rewrite {
        static void Main(string[] args) {
            // Parse the C# code file
            string codeFilePath = @"../test.cs";
            string code = File.ReadAllText(codeFilePath);
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
            Console.WriteLine(syntaxTree);
            
            SyntaxNode root = syntaxTree.GetRoot();

            // Convert the syntax tree to a string
            //StringBuilder sb = new StringBuilder();
            //root.WriteTo(sb);
            string text = syntaxTree.ToString(); 
            StringBuilder sb = new StringBuilder(text);

            // Replace some words in the string
            sb.Replace("new GCounter", "Wrapper.CreateWrapGC");
            sb.Replace("gc.Increment", "Wrapper.GCIncrement");

            sb.Replace("new PNCounter", "Wrapper.CreateWrapPN");
            sb.Replace("pnc.Increment", "Wrapper.PNIncrement");
            sb.Replace("pnc.Decrement", "Wrapper.PNDecrement");
            

            // Print the modified text
            Console.WriteLine(sb);

            string fileName = System.IO.Directory.GetCurrentDirectory() + "/main.cs";
            using (StreamWriter sw = File.CreateText(fileName)) {
                sw.WriteLine(sb);
            }

            #region [Func Name]
            // Extract function names from the syntax tree
            // var functions = syntaxTree.GetRoot()
            //                         .DescendantNodes()
            //                         .OfType<MethodDeclarationSyntax>()
            //                         .Select(method => method.Identifier.Text);

            // // Print the function names to the console
            // foreach (var functionName in functions)
            // {
            //     Console.WriteLine(functionName);
            // }
            #endregion
        }
    }
}