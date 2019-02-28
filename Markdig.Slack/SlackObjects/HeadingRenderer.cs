using Markdig.Renderers;
using Markdig.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack.SlackObjects
{
	public class HeadingRenderer : SlackObjectRenderer<HeadingBlock>
	{
		protected override void Write(SlackRenderer renderer, HeadingBlock obj)
		{
			renderer.Write("*");
			renderer.WriteLeafInline(obj);
			renderer.Write("*");

			renderer.EnsureLine();
		}
	}
}
