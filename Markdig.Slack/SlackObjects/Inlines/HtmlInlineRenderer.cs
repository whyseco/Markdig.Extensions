using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack.SlackObjects.Inlines
{
	public class HtmlInlineRenderer : SlackObjectRenderer<HtmlInline>
	{
		protected override void Write(SlackRenderer renderer, HtmlInline obj)
		{
			renderer.Write(obj.Tag);
		}
	}
}
