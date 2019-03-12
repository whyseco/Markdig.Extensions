using Markdig.Renderers.Normalize;
using Markdig.Slack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Markdig.Tests
{
	public class SlackParserTests
	{
		[Fact]
		public void WhenSlackContainsEmphasisThenMarkdownRenderIsOk()
		{
			var stringWriter = new StringWriter();
			Markdown.Convert("Code *bold* _italic_ ~strike~ Texte", new NormalizeRenderer(stringWriter), 
				new MarkdownPipelineBuilder().Use<SlackExtension>().Build());
			stringWriter.Flush();
			var slackText = stringWriter.ToString();
			Assert.Equal("Code **bold** _italic_ ~~strike~~ Texte", slackText);
		}

		[Fact]
		public void WhenSlackContainsLinkThenMarkdownRenderIsOk()
		{
			var stringWriter = new StringWriter();
			Markdown.Convert("Code <https://whyse.co|Whyse> Texte", new NormalizeRenderer(stringWriter),
				new MarkdownPipelineBuilder().Use<SlackExtension>().Build());
			stringWriter.Flush();
			var slackText = stringWriter.ToString();
			Assert.Equal("Code [Whyse](https://whyse.co) Texte", slackText);
		}

		[Fact]
		public void WhenSlackContainsCarriageReturnThenMarkdownRenderIsOk()
		{
			var stringWriter = new StringWriter();
			Markdown.Convert("Code\nTexte", new NormalizeRenderer(stringWriter),
				new MarkdownPipelineBuilder().Use<SlackExtension>().Build());
			stringWriter.Flush();
			var slackText = stringWriter.ToString();
			Assert.Equal("Code  \nTexte", slackText);
		}
	}
}
