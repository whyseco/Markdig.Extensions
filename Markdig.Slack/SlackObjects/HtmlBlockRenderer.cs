using Markdig.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack.SlackObjects
{
	public class HtmlBlockRenderer : SlackObjectRenderer<HtmlBlock>
	{
		protected override void Write(SlackRenderer renderer, HtmlBlock obj)
		{
			renderer.WriteLeafInline(obj);
		}
	}
}
