﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.ComponentModel.Design.Serialization;
using ICSharpCode.PythonBinding;
using NUnit.Framework;

namespace PythonBinding.Tests.Designer
{
	/// <summary>
	/// Tests the PythonDesignerLoaderProvider class.
	/// </summary>
	[TestFixture]
	public class PythonDesignerLoaderProviderTestFixture
	{
		PythonDesignerLoaderProvider provider;
		PythonDesignerGenerator generator;
		
		[TestFixtureSetUp]
		public void SetUpFixture()
		{
			provider = new PythonDesignerLoaderProvider();
			generator = new PythonDesignerGenerator();
		}
		
		[Test]
		public void PythonDesignerLoaderCreated()
		{
			DesignerLoader loader = provider.CreateLoader(generator);
			loader.Dispose();
			Assert.IsInstanceOfType(typeof(PythonDesignerLoader), loader);
		}
		
		[Test]
		public void CodeDomProviderIsPython()
		{
//			Assert.IsInstanceOfType(typeof(PythonProvider), generator.CodeDomProvider);
		}
	}
}
