using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack.SlackObjects.Inlines
{
	public class CodeInlineRenderer : SlackObjectRenderer<CodeInline>
	{
		protected override void Write(SlackRenderer renderer, CodeInline obj)
		{
			renderer.Write("`");
			renderer.Write(obj.Content);
			renderer.Write("`");
		}
	}
}
