﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [TestFixture]
    class tests
    {
        [TestCase]
        public void fight()
        {
            MainWindow test = new MainWindow();
            test.plusarmorkni();
        }
    }
}
