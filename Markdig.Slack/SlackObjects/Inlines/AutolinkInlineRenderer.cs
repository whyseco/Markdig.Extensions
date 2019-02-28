using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack.SlackObjects.Inlines
{
	public class AutolinkInlineRenderer : SlackObjectRenderer<AutolinkInline>
	{
		protected override void Write(SlackRenderer renderer, AutolinkInline obj)
		{
			renderer.Write("<");
			renderer.Write(obj.Url);
			renderer.Write(">");
		}
	}
}
