﻿using EarthMagicItems.Ammo.Arrows;
using EarthWithMagicAPI.API.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthMagicItems.Ammo.Bolts.Normal
{
    public class _2Bolt : GenericAmmo
    {
        public _2Bolt()
            : base(new Die(3, 5, 0), "+2 Bolt", AmmoUtil.StandardBolt(new Die(1, 6, 2)), "EarthMagicDocumentation.ASCII_Art.Items.Ammo.CrossbowBolt.txt",
            "EarthMagicDocumentation.Items.Ammo.Bolts.+2Bolt.md", .15)
        {
        }
    }
}