using Markdig.Helpers;
using Markdig.Parsers;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack.Parser.Inlines
{
	public class LinkInlineParser : InlineParser
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LinkInlineParser"/> class.
		/// </summary>
		public LinkInlineParser()
		{
			OpeningCharacters = new[] { '<' };
		}

		public override bool Match(InlineProcessor processor, ref StringSlice slice)
		{
			int line;
			int column;
			var startPosition = processor.GetSourcePosition(slice.Start, out line, out column);
			var labelSpan = SourceSpan.Empty;
			var urlBuilder = processor.StringBuilders.Get();
			var labelBuilder = processor.StringBuilders.Get();
			string url = null;
			string label = null;
			bool isMatching = false;

			var startLabel = -1;
			var endLabel = -1;

			slice.NextChar();
			var c = slice.CurrentChar;

			while (c != '\0')
			{
				if (c == '>')
				{
					endLabel = slice.Start;
					isMatching = true;
					break;
				}
				if (c == '|')
				{
					url = urlBuilder.ToString();
					startLabel = slice.Start + 1;
				}
				else
				{
					if (url is null)
						urlBuilder.Append(c);
					else
						labelBuilder.Append(c);
				}
				c = slice.NextChar();
			}
			if (!isMatching)
				return false;
			slice.NextChar();
			if (labelBuilder.Length > 0)
			{
				label = labelBuilder.ToString();
				labelSpan = new SourceSpan(startLabel, endLabel);
			}
			if (url is null)
				url = urlBuilder.ToString();
			if (label is null)
				label = url;

			var linkInline = new LinkInline()
			{
				Url = HtmlHelper.Unescape(url),
				Title = null,
				IsImage = false,
				LabelSpan = label is null ? SourceSpan.Empty : processor.GetSourcePositionFromLocalSpan(labelSpan),
				UrlSpan = new SourceSpan(startPosition, processor.GetSourcePosition(startLabel - 2)),
				TitleSpan = SourceSpan.Empty,
				Span = new SourceSpan(startPosition, processor.GetSourcePosition(slice.Start - 1)),
				Line = line,
				Column = column,
				IsClosed = true
			};
			if (label != null)
				linkInline.AppendChild(new LiteralInline(label));
			processor.Inline = linkInline;
			processor.StringBuilders.Release(urlBuilder);
			processor.StringBuilders.Release(labelBuilder);

			return true;
		}
	}
}
