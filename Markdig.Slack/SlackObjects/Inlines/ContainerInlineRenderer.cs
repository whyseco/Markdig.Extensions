using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack.SlackObjects.Inlines
{
	public class ContainerInlineRenderer : SlackObjectRenderer<ContainerInline>
	{
		protected override void Write(SlackRenderer renderer, ContainerInline obj)
		{
			renderer.WriteChildren(obj);
		}
	}
}
