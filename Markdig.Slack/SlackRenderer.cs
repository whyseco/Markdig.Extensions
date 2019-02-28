using System;
using System.IO;
using Markdig.Slack.SlackObjects;
using Markdig.Slack.SlackObjects.Inlines;
using Markdig.Syntax;

namespace Markdig.Slack
{
	public class SlackRenderer : Markdig.Renderers.TextRendererBase<SlackRenderer>
	{
		public SlackRenderer(TextWriter writer) : base(writer)
		{
			ObjectRenderers.Add(new HeadingRenderer());
			ObjectRenderers.Add(new HtmlBlockRenderer());
			ObjectRenderers.Add(new ListRenderer());
			ObjectRenderers.Add(new ParagraphRenderer());
			ObjectRenderers.Add(new QuoteBlockRenderer());
			ObjectRenderers.Add(new ThematicBreakRenderer());

			ObjectRenderers.Add(new AutolinkInlineRenderer());
			ObjectRenderers.Add(new CodeInlineRenderer());
			ObjectRenderers.Add(new DelimiterInlineRenderer());
			ObjectRenderers.Add(new EmphasisInlineRenderer());
			ObjectRenderers.Add(new HtmlEntityInlineRenderer());
			ObjectRenderers.Add(new HtmlInlineRenderer());
			ObjectRenderers.Add(new LineBreakInlineRenderer());
			ObjectRenderers.Add(new LinkInlineRenderer());
			ObjectRenderers.Add(new LiteralInlineRenderer());
		}

		public override object Render(MarkdownObject markdownObject)
		{
			return base.Render(markdownObject);
		}

		public void FinishBlock()
		{
			if (!IsLastInContainer)
			{
				WriteLine();
			}
		}
	}
}
