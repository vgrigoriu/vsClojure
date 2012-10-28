﻿using Clojure.Code.Parsing;
using Microsoft.VisualStudio.Text.Tagging;

namespace Clojure.VisualStudio.Editor.Tagger
{
    public class ClojureTokenTag : ITag
    {
        private readonly Token _token;

		public Token Token
        {
            get { return _token; }
        }

		public ClojureTokenTag(Token token)
        {
            _token = token;
        }
    }
}