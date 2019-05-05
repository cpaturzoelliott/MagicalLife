﻿using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Sound;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.GUI.Save;
using MagicalLifeGUIWindows.Properties;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.GUI.In
{
    public class SaveButton : MonoButton
    {
        public SaveButton() : base(TextureLoader.GUIMenuButton, GetDisplayArea(), true, Resources.Save)
        {
            this.ClickEvent += this.SaveButton_ClickEvent;
        }

        private void SaveButton_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            this.Save();
        }

        private static Rectangle GetDisplayArea()
        {
            int x = InGameEscapeMenuLayout.ButtonX;
            int y = InGameEscapeMenuLayout.SaveButtonY;
            int width = InGameEscapeMenuLayout.ButtonWidth;
            int height = InGameEscapeMenuLayout.ButtonHeight;

            return new Rectangle(x, y, width, height);
        }

        private void Save()
        {
            FMODUtil.RaiseEvent(SoundsTable.UIClick);
            SaveGameMenu.Initialize();
            InGameEscapeMenu.menu.PopupChild(SaveGameMenu.menu);
        }
    }
}