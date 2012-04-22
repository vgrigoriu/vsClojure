﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using Clojure.Code.State;
using Clojure.Parsing;
using ClojureExtension.Utilities;
using Microsoft.ClojureExtension.Editor;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Utilities;

namespace ClojureExtension.Editor.Intellisense
{
	[Export(typeof (ICompletionSourceProvider))]
	[ContentType("Clojure")]
	[Name("ClojureCompletion")]
	public class HippieCompletionSourceProvider : ICompletionSourceProvider
	{
		public ICompletionSource TryCreateCompletionSource(ITextBuffer textBuffer)
		{
			Entity<LinkedList<Token>> tokenizedBuffer = TokenizedBufferBuilder.TokenizedBuffers[textBuffer];
			return new HippieCompletionSource(tokenizedBuffer);
		}
	}
}