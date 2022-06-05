using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace miniit.MERGE
{
    interface IColorableByItem
    {
        abstract void ColorImage(ItemInfo itemInfo);
    }
}
