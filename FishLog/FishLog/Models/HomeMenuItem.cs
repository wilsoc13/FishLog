﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FishLog.Models
{
    public enum MenuItemType
    {
        Home,
        Log,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
