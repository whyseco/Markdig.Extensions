using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack.SlackObjects.Inlines
{
	public class DelimiterInlineRenderer : SlackObjectRenderer<DelimiterInline>
	{
		protected override void Write(SlackRenderer renderer, DelimiterInline obj)
		{
			renderer.Write(obj.ToLiteral());
			renderer.WriteChildren(obj);
		}
	}
}
