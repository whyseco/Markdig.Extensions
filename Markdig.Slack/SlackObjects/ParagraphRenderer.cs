using Markdig.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack.SlackObjects
{
	public class ParagraphRenderer : SlackObjects.SlackObjectRenderer<ParagraphBlock>
	{
		protected override void Write(SlackRenderer renderer, ParagraphBlock obj)
		{
			renderer.WriteLeafInline(obj);
			renderer.FinishBlock();
		}
	}
}
