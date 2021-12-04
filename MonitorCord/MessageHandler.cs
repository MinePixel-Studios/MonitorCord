using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorCord
{
    class MessageHandler
    {
        public MessageHandler()
        {

        }

        private Discord.EmbedBuilder MessageCreator(Server server)
        {
            //
            //  creating embedbuilder
            //

            Discord.EmbedBuilder embedBuilder = new Discord.EmbedBuilder();

            //
            //  author builder
            //

            Discord.EmbedAuthorBuilder embedAuthorBuilder = new Discord.EmbedAuthorBuilder();
            embedAuthorBuilder.Name = server.Messagesendernameconfig;
            embedAuthorBuilder.IconUrl = server.Messagesenderprofilpictureconfig;
            embedAuthorBuilder.Build();
            embedBuilder.Author = embedAuthorBuilder;



            embedBuilder.Color = Discord.Color.DarkRed;

            //
            //  servername field
            //

            Discord.EmbedFieldBuilder embedFieldBuilderName = new Discord.EmbedFieldBuilder();
            embedFieldBuilderName.IsInline = false;
            embedFieldBuilderName.Name = server.Servernameconfig;
            embedFieldBuilderName.Value = server.Name;
            embedBuilder.AddField(embedFieldBuilderName);

            //
            //  serverstatus field
            //

            Discord.EmbedFieldBuilder embedFieldBuilderStatus = new Discord.EmbedFieldBuilder();
            embedFieldBuilderStatus.IsInline = false;
            embedFieldBuilderStatus.Name = server.Serverstatusconfig;
            embedFieldBuilderStatus.Value = server.Status;
            embedBuilder.AddField(embedFieldBuilderStatus);

            //
            //  embed thumbnail
            //

            embedBuilder.ThumbnailUrl = "https://avatars.githubusercontent.com/u/65872875?v=4";

            //
            //  embed footer
            //

            Discord.EmbedFooterBuilder embedFooterBuilder = new Discord.EmbedFooterBuilder();
            embedFooterBuilder.Text = "Monitoring";
            embedFooterBuilder.IconUrl = "https://avatars.githubusercontent.com/u/65872875?v=4";
            embedBuilder.Footer = embedFooterBuilder;

            //
            //  returning embed
            //

            return embedBuilder;
        }
        public async Task MessageSenderAsync(Server server)
        {
            IEnumerable<Discord.Embed> embeds = new[] { MessageCreator(server).Build() };

            Discord.Webhook.DiscordWebhookClient discordWebhookClient = new Discord.Webhook.DiscordWebhookClient(server.Webhook);

            string headline = "**Service currently offline** :no_entry:";

            await discordWebhookClient.SendMessageAsync(headline, false, embeds, server.Messagesendernameconfig, server.Messagesenderprofilpictureconfig);
                
        }
    }
}
