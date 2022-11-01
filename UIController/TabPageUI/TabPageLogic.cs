﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UIController.ClientUI;

namespace UIController.TabPageUI
{
    public class TabPageLogic
    {
        public ClientWindowLogic Parent;

        public TabPageLogic(ClientWindowLogic parent)
        {
            Parent = parent;
        }

        public virtual void OnExposedToControl(Control ctrl)
        {

        }
    }
}
