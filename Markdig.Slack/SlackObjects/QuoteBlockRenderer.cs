using Markdig.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack.SlackObjects
{
	public class QuoteBlockRenderer : SlackObjects.SlackObjectRenderer<QuoteBlock>
	{
		protected override void Write(SlackRenderer renderer, QuoteBlock quoteBlock)
		{
			renderer.EnsureLine();
			renderer.PushIndent(">");
			renderer.WriteChildren(quoteBlock);
			renderer.PopIndent();
			renderer.EnsureLine();
		}
	}
}
