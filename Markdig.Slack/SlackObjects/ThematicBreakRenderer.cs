using Markdig.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack.SlackObjects
{
	public class ThematicBreakRenderer : SlackObjectRenderer<ThematicBreakBlock>
	{
		protected override void Write(SlackRenderer renderer, ThematicBreakBlock obj)
		{
			renderer.Write(" --- ");
			renderer.EnsureLine();
		}
	}
}
