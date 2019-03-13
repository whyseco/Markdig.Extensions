using Markdig.Slack;
using System;
using System.IO;
using Xunit;

namespace Markdig.Tests
{
	public class SlackRendererTests
	{
		[Fact]
		public void WhenMarkdownContainsHeadingThenSlackRenderIsOk()
		{
			var stringWriter = new StringWriter();
			Markdown.Convert("# Header 1\nTest\n## Header 2\nOk", new SlackRenderer(stringWriter));
			stringWriter.Flush();
			var slackText = stringWriter.ToString();
			Assert.Equal("*Header 1*\nTest\n*Header 2*\nOk", slackText);
		}

		[Fact]
		public void WhenMarkdownContainsAutoLinkThenSlackRenderIsOk()
		{
			var stringWriter = new StringWriter();
			Markdown.Convert("Lien https://app.whyse.co Texte", new SlackRenderer(stringWriter), new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());
			stringWriter.Flush();
			var slackText = stringWriter.ToString();
			Assert.Equal("Lien <https://app.whyse.co|https://app.whyse.co> Texte", slackText);
		}

		[Fact]
		public void WhenMarkdownContainsLinkThenSlackRenderIsOk()
		{
			var stringWriter = new StringWriter();
			Markdown.Convert("Lien [Whyse App](https://app.whyse.co) Texte", new SlackRenderer(stringWriter));
			stringWriter.Flush();
			var slackText = stringWriter.ToString();
			Assert.Equal("Lien <https://app.whyse.co|Whyse App> Texte", slackText);
		}

		[Fact]
		public void WhenMarkdownContainsCodeInlineThenSlackRenderIsOk()
		{
			var stringWriter = new StringWriter();
			Markdown.Convert("Code `my Code` Texte", new SlackRenderer(stringWriter));
			stringWriter.Flush();
			var slackText = stringWriter.ToString();
			Assert.Equal("Code `my Code` Texte", slackText);
		}

		[Fact]
		public void WhenMarkdownContainsEmphasisThenSlackRenderIsOk()
		{
			var stringWriter = new StringWriter();
			Markdown.Convert("Code *italic* _italic_ __bold__ **bold** ~~strike~~ Texte", new SlackRenderer(stringWriter), new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());
			stringWriter.Flush();
			var slackText = stringWriter.ToString();
			Assert.Equal("Code _italic_ _italic_ *bold* *bold* ~strike~ Texte", slackText);
		}

		[Fact]
		public void WhenMarkdownContainsListThenSlackRenderIsOk()
		{
			var stringWriter = new StringWriter();
			Markdown.Convert("Code\n* Item 1\n* Item 2\n- Item 3\n- Item 4\n\nTexte", new SlackRenderer(stringWriter));
			stringWriter.Flush();
			var slackText = stringWriter.ToString();
			Assert.Equal("Code\n- Item 1\n- Item 2\n- Item 3\n- Item 4\nTexte", slackText);
		}

		[Fact]
		public void WhenMarkdownContainsNumberedListThenSlackRenderIsOk()
		{
			var stringWriter = new StringWriter();
			Markdown.Convert("Code\n1. Item 1\n2. Item 2\n3. Item 3\n4. Item 4\n\nTexte", new SlackRenderer(stringWriter));
			stringWriter.Flush();
			var slackText = stringWriter.ToString();
			Assert.Equal("Code\n1. Item 1\n2. Item 2\n3. Item 3\n4. Item 4\nTexte", slackText);
		}

		[Fact]
		public void WhenMarkdownContainsQuoteBlockThenSlackRenderIsOk()
		{
			var stringWriter = new StringWriter();
			Markdown.Convert("Code\n> Quote 1\n> Quote 2\n\nTexte", new SlackRenderer(stringWriter));
			stringWriter.Flush();
			var slackText = stringWriter.ToString();
			Assert.Equal("Code\n>Quote 1\n>Quote 2\nTexte", slackText);
		}

		[Fact]
		public void WhenMarkdownContainsThematicBreakerThenSlackRenderIsOk()
		{
			var stringWriter = new StringWriter();
			Markdown.Convert("Code\n\n---\n\nTexte", new SlackRenderer(stringWriter));
			stringWriter.Flush();
			var slackText = stringWriter.ToString();
			Assert.Equal("Code\n --- \nTexte", slackText);
		}

		[Fact]
		public void WhenMarkdownContainsOnlyBoldThenSlackRenderIsOk()
		{
			var stringWriter = new StringWriter();
			Markdown.Convert("**bold**", new SlackRenderer(stringWriter), new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());
			stringWriter.Flush();
			var slackText = stringWriter.ToString();
			Assert.Equal("*bold*", slackText);
		}
	}
}
