using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack.SlackObjects.Inlines
{
	public class LiteralInlineRenderer : SlackObjectRenderer<LiteralInline>
	{
		protected override void Write(SlackRenderer renderer, LiteralInline obj)
		{
			renderer.Write(ref obj.Content);
		}
	}
}
