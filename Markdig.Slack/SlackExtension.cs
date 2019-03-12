using System;
using System.Collections.Generic;
using System.Text;
using Markdig.Parsers.Inlines;
using Markdig.Renderers;
using Markdig.Renderers.Normalize;
using Markdig.Syntax.Inlines;

namespace Markdig.Slack
{
	public class EmphasisInlineRenderer : NormalizeObjectRenderer<EmphasisInline>
	{
		private string GetTag(EmphasisInline emphasisInline)
		{
			var c = emphasisInline.DelimiterChar;
			switch (c)
			{
				case '~':
					return "~~";
				case '*':
					return "**";
				case '_':
					return "_";
			}

			return null;
		}

		protected override void Write(NormalizeRenderer renderer, EmphasisInline obj)
		{
			var emphasisText = GetTag(obj);
			renderer.Write(emphasisText);
			renderer.WriteChildren(obj);
			renderer.Write(emphasisText);
		}
	}

	public class SlackExtension : IMarkdownExtension
	{
		public void Setup(MarkdownPipelineBuilder pipeline)
		{
			var parser = pipeline.InlineParsers.FindExact<EmphasisInlineParser>();
			if (parser != null)
			{
				parser.EmphasisDescriptors.Clear();
				parser.EmphasisDescriptors.Add(new EmphasisDescriptor('~', 1, 1, false));
				parser.EmphasisDescriptors.Add(new EmphasisDescriptor('*', 1, 1, false));
				parser.EmphasisDescriptors.Add(new EmphasisDescriptor('_', 1, 1, false));
			}
			pipeline.InlineParsers.Replace<LinkInlineParser>(new Parser.Inlines.LinkInlineParser());
			var lbParser = pipeline.InlineParsers.FindExact<LineBreakInlineParser>();
			if (lbParser != null)
				lbParser.EnableSoftAsHard = true;
		}

		public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
		{
			if (renderer is HtmlRenderer htmlRenderer)
			{
				// Extend the rendering here.
				var emphasisRenderer = htmlRenderer.ObjectRenderers.FindExact<Renderers.Html.Inlines.EmphasisInlineRenderer>();
				if (emphasisRenderer != null)
				{
					var previousTag = emphasisRenderer.GetTag;
					emphasisRenderer.GetTag = inline => GetTag(inline) ?? previousTag(inline);
				}
			}
			if (renderer is NormalizeRenderer normalizeRenderer)
			{
				normalizeRenderer.ObjectRenderers.Replace<Renderers.Normalize.Inlines.EmphasisInlineRenderer>(new EmphasisInlineRenderer());
			}
		}

		private string GetTag(EmphasisInline emphasisInline)
		{
			var c = emphasisInline.DelimiterChar;
			switch (c)
			{
				case '~':
					return "del";
				case '*':
					return "strong";
				case '_':
					return "i";
			}

			return null;
		}
	}
}
