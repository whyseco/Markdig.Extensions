using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack.SlackObjects.Inlines
{
	public class EmphasisInlineRenderer : SlackObjectRenderer<EmphasisInline>
	{
		public string GetDefaultTag(EmphasisInline obj)
		{
			if (obj.DelimiterChar == '*' || obj.DelimiterChar == '_')
			{
				return obj.DelimiterCount == 2 ? "*" : "_";
			}
			if (obj.DelimiterChar == '~' && obj.DelimiterCount == 2)
			{
				return "~";
			}
			return null;
		}

		protected override void Write(SlackRenderer renderer, EmphasisInline em)
		{
			var tag = GetDefaultTag(em);
			if (tag != null) renderer.Write(tag);
			renderer.WriteChildren(em);
			if (tag != null) renderer.Write(tag);
		}
	}
}
