using UnityEngine;
using UnityWeld.Binding;

namespace DiUi
{
    [Binding]
    public class DiUiInventoryItemViewModel
    {
        [Binding]
        public int AmountText
        {
            get;
            private set;
        }

        [Binding]
        public Sprite ItemIcon
        {
            get;
            private set;
        }

        public DiUiInventoryItemViewModel(Sprite Icon, int Amount)
        {
            AmountText = Amount;
            ItemIcon = Icon;
        }
    }
}
