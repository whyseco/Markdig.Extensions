using Markdig.Renderers;
using Markdig.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack.SlackObjects
{
	public abstract class SlackObjectRenderer<TObject> : MarkdownObjectRenderer<SlackRenderer, TObject> where TObject : MarkdownObject
	{
	}
}
