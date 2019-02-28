using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack.SlackObjects.Inlines
{
	public class HtmlEntityInlineRenderer : SlackObjectRenderer<HtmlEntityInline>
	{
		protected override void Write(SlackRenderer renderer, HtmlEntityInline obj)
		{
			renderer.Write(obj.Transcoded);
		}
	}
}
