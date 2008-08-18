﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.PythonBinding;
using IronPython;
using IronPython.Compiler;
using IronPython.Compiler.Ast;
using Microsoft.CSharp;
using NRefactory = ICSharpCode.NRefactory;

namespace PyWalker
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form, IOutputWriter
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();			
		}
		
		public void WriteLine(string s)
		{
			walkerOutputTextBox.Text += String.Concat(s, "\r\n");
		}
		
		void RunAstWalkerButtonClick(object sender, EventArgs e)
		{
			try {
				Clear();
//				PythonCompilerSink sink = new PythonCompilerSink();
//				CompilerContext context = new CompilerContext(String.Empty, sink);
//				Parser parser = Parser.FromString(null, context, codeTextBox.Text);
//				Statement statement = parser.ParseFileInput();
//				ResolveWalker walker = new ResolveWalker(this);
//				statement.Walk(walker);
//				if (sink.Errors.Count > 0) {
//					walkerOutputTextBox.Text += "\r\n";
//					foreach (PythonCompilerError error in sink.Errors) {
//						walkerOutputTextBox.Text += error.ToString() + "\r\n";
//					}
//				}
			} catch (Exception ex) {
				walkerOutputTextBox.Text = ex.ToString();
			}
		}
		
		void ClearButtonClick(object sender, EventArgs e)
		{
			Clear();
		}
		
		void Clear()
		{
			walkerOutputTextBox.Text = String.Empty;
		}
		
		void RunCodeDomVisitorClick(object sender, EventArgs e)
		{
			try {
				Clear();
//				PythonProvider provider = new PythonProvider();
//				CodeCompileUnit unit = provider.Parse(new StringReader(codeTextBox.Text));
//				CodeDomVisitor visitor = new CodeDomVisitor(this);
//				visitor.Visit(unit);
			} catch (Exception ex) {
				walkerOutputTextBox.Text = ex.ToString();
			}
		}
		
		/// <summary>
		/// Round trips the Python code through the code DOM and back
		/// to source code.
		/// </summary>
		void RunRoundTripButtonClick(object sender, EventArgs e)
		{
			try {
				Clear();
//				PythonProvider provider = new PythonProvider();
//				CodeCompileUnit unit = provider.Parse(new StringReader(codeTextBox.Text));
//				StringWriter writer = new StringWriter();
//				CodeGeneratorOptions options = new CodeGeneratorOptions();
//				options.BlankLinesBetweenMembers = false;
//				options.IndentString = "\t";
//				provider.GenerateCodeFromCompileUnit(unit, writer, options);
//				
//				walkerOutputTextBox.Text = writer.ToString();
			} catch (Exception ex) {
				walkerOutputTextBox.Text = ex.ToString();
			}
		}
		
		/// <summary>
		/// Converts the C# code to a code dom using the NRefactory
		/// library and then visits the code dom.
		/// </summary>
		void RunCSharpToPythonClick(object sender, EventArgs e)
		{
			try {
				Clear();
				using (NRefactory.IParser parser = NRefactory.ParserFactory.CreateParser(NRefactory.SupportedLanguage.CSharp, new StringReader(codeTextBox.Text))) {
					parser.ParseMethodBodies = false;
					parser.Parse();
					NRefactory.Visitors.CodeDomVisitor visitor = new NRefactory.Visitors.CodeDomVisitor();
					visitor.VisitCompilationUnit(parser.CompilationUnit, null);
				
//					PythonProvider provider = new PythonProvider();
//					StringWriter writer = new StringWriter();
//					CodeGeneratorOptions options = new CodeGeneratorOptions();
//					options.BlankLinesBetweenMembers = false;
//					options.IndentString = "\t";
//					provider.GenerateCodeFromCompileUnit(visitor.codeCompileUnit, writer, options);
//	
//					walkerOutputTextBox.Text = writer.ToString();
				}
			} catch (Exception ex) {
				walkerOutputTextBox.Text = ex.ToString();
			}			
		}
		
		/// <summary>
		/// Converts C# to python using the code dom generated by the
		/// NRefactory parser.
		/// </summary>
		void RunNRefactoryCSharpCodeDomVisitorClick(object sender, EventArgs e)
		{
			try {
				Clear();
				using (NRefactory.IParser parser = NRefactory.ParserFactory.CreateParser(NRefactory.SupportedLanguage.CSharp, new StringReader(codeTextBox.Text))) {
					parser.ParseMethodBodies = false;
					parser.Parse();
					NRefactory.Visitors.CodeDomVisitor visitor = new NRefactory.Visitors.CodeDomVisitor();
					visitor.VisitCompilationUnit(parser.CompilationUnit, null);
					CodeDomVisitor codeDomVisitor = new CodeDomVisitor(this);
					codeDomVisitor.Visit(visitor.codeCompileUnit);					
				}
			} catch (Exception ex) {
				walkerOutputTextBox.Text = ex.ToString();
			}			
		}		
	}
}
