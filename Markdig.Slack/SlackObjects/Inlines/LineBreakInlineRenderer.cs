using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack.SlackObjects.Inlines
{
	public class LineBreakInlineRenderer : SlackObjectRenderer<LineBreakInline>
	{
		protected override void Write(SlackRenderer renderer, LineBreakInline obj)
		{
			renderer.EnsureLine();
		}
	}
}
