﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

using Discord_UWP.Managers;
using Discord_UWP.LocalModels;
using Discord_UWP.SharedModels;

namespace Discord_UWP.Flyouts
{
    partial class FlyoutCreator
    {
        public static MenuFlyout MakeGuildMenu(LocalModels.Guild guild)
        {
            MenuFlyout menu = new MenuFlyout();
            menu.MenuFlyoutPresenterStyle = (Style)App.Current.Resources["MenuFlyoutPresenterStyle1"];
            MenuFlyoutItem editServer = new MenuFlyoutItem()
            {
                Text = App.GetString("/Flyouts/EditServer"),
                //Text = "Edit Server",
                Tag = guild.Raw.Id,
                Icon = new SymbolIcon(Symbol.Edit),
                Margin = new Thickness(-26, 0, 0, 0)
            };
            editServer.Click += FlyoutManager.EditServer;
            menu.Items.Add(editServer);
            MenuFlyoutSeparator sep1 = new MenuFlyoutSeparator();
            menu.Items.Add(sep1);
            ToggleMenuFlyoutItem mute = new ToggleMenuFlyoutItem()
            {
                Text = App.GetString("/Flyouts/MuteServer"),
                //Text = "Mute Server",
                Icon = new SymbolIcon(Symbol.Mute),
                Tag = guild.Raw.Id,
                Margin = new Thickness(-26, 0, 0, 0)
            };
            mute.IsChecked = LocalState.GuildSettings.ContainsKey(guild.Raw.Id) ? LocalState.GuildSettings[guild.Raw.Id].raw.Muted : false;
            mute.Click += FlyoutManager.MuteServer;
            menu.Items.Add(mute);
            MenuFlyoutItem markasread = new MenuFlyoutItem()
            {
                Text = App.GetString("/Flyouts/MarkAsRead"),
                //Text = "Mark as Read",
                Tag = guild.Raw.Id,
                Icon = new SymbolIcon(Symbol.View),
                Margin = new Thickness(-26, 0, 0, 0),
                //IsEnabled = (ServerList.Items.FirstOrDefault(x => (x as SimpleGuild).Id == guild.RawGuild.Id) as SimpleGuild).IsUnread
            };
            markasread.Click += FlyoutManager.MarkGuildasRead;
            menu.Items.Add(markasread);
            if (guild.Raw.OwnerId == LocalState.CurrentUser.Id)
            {
                MenuFlyoutItem deleteServer = new MenuFlyoutItem()
                {
                    Text = App.GetString("/Flyouts/DeleteServer"),
                    //Text = "Delete Server",
                    Tag = guild.Raw.Id,
                    Foreground = new SolidColorBrush(Color.FromArgb(255, 240, 71, 71)),
                    Icon = new SymbolIcon(Symbol.Delete),
                    Margin = new Thickness(-26, 0, 0, 0)
                };
                deleteServer.Click += FlyoutManager.DeleteServer;
                menu.Items.Add(deleteServer);
            }
            else
            {
                MenuFlyoutItem leaveServer = new MenuFlyoutItem()
                {
                    Text = App.GetString("/Flyouts/LeaveServer"),
                    //Text = "Leave Server",
                    Tag = guild.Raw.Id,
                    Foreground = new SolidColorBrush(Color.FromArgb(255, 240, 71, 71)),
                    Icon = new SymbolIcon(Symbol.Remove),
                    Margin = new Thickness(-26, 0, 0, 0)
                };
                leaveServer.Click += FlyoutManager.LeaveServer;
                menu.Items.Add(leaveServer);
            }
            return menu;
        }
    }
}