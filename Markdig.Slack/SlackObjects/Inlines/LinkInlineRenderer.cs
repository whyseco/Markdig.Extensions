using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Markdig.Slack.SlackObjects.Inlines
{
	public class LinkInlineRenderer : SlackObjectRenderer<LinkInline>
	{
		protected override void Write(SlackRenderer renderer, LinkInline obj)
		{
			renderer.Write("<");
			renderer.Write(obj.Url);
			if (obj.Any())
			{
				renderer.Write("|");
				renderer.WriteChildren(obj);
			}
			renderer.Write(">");
		}
	}
}
