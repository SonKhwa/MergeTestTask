// Copyright (c) 2015 - 2021 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

//.........................
//.....Generated Class.....
//.........................
//.......Do not edit.......
//.........................

using System.Collections.Generic;
// ReSharper disable All
namespace Doozy.Runtime.UIManager.Components
{
    public partial class UIButton
    {
        public static IEnumerable<UIButton> GetButtons(UIButtonId.GUIButtons id) => GetButtons(nameof(UIButtonId.GUIButtons), id.ToString());
        public static bool SelectButton(UIButtonId.GUIButtons id) => SelectButton(nameof(UIButtonId.GUIButtons), id.ToString());

        public static IEnumerable<UIButton> GetButtons(UIButtonId.MenuButton id) => GetButtons(nameof(UIButtonId.MenuButton), id.ToString());
        public static bool SelectButton(UIButtonId.MenuButton id) => SelectButton(nameof(UIButtonId.MenuButton), id.ToString());
    }
}

namespace Doozy.Runtime.UIManager
{
    public partial class UIButtonId
    {
        public enum GUIButtons
        {
            Pause
        }

        public enum MenuButton
        {
            Exit,
            Play,
            Settings
        }    
    }
}