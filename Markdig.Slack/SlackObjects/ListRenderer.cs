using Markdig.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdig.Slack.SlackObjects
{
	public class ListRenderer : SlackObjects.SlackObjectRenderer<ListBlock>
	{
		private string GenerateBullet(char bulletType, int nb)
		{
			nb = nb + 1;
			switch (bulletType)
			{
				case '1':
					return nb + ". ";
				case 'i':
					return new String('i', nb) + ". ";
				case 'I':
					return new String('I', nb) + ". ";
				default:
					return "- ";
			}
		}
		protected override void Write(SlackRenderer renderer, ListBlock listBlock)
		{
			int i = 0;
			foreach (var item in listBlock)
			{
				var listItem = (ListItemBlock)item;

				renderer.Write(this.GenerateBullet(listBlock.BulletType, i));
				renderer.WriteChildren(listItem);
				renderer.EnsureLine();
				i++;
			}
		}
	}
}
