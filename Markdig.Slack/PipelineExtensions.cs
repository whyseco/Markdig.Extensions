using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack
{
	public static class PipelineExtensions
	{
		public static MarkdownPipelineBuilder UseAuthorizedExtensions(this MarkdownPipelineBuilder pipeline)
		{
			return pipeline
				.UseAbbreviations()
				.UseAutoIdentifiers()
				.UseCitations()
				.UseDefinitionLists()
				.UseEmphasisExtras()
				.UseFigures()
				.UseFooters()
				.UseFootnotes()
				.UseGridTables()
				.UseMathematics()
				.UseMediaLinks()
				.UsePipeTables()
				.UseListExtras()
				.UseTaskLists()
				.UseDiagrams()
				.UseAutoLinks()
				.UseGenericAttributes(); // Must be last as it is one parser that is modifying other parsers
		}
	}
}
