﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using ICSharpCode.SharpDevelop.Gui;

namespace ICSharpCode.XmlEditor
{
	public class CopyXmlTreeNode : XmlTreeNodeClipboardCommand
	{
		protected override bool GetEnabled(IClipboardHandler editable)
		{
			return editable.EnableCopy;
		}
		
		protected override void Run(IClipboardHandler editable)
		{
			editable.Copy();
		}
	}
}
