﻿using System;
using System.Text;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        public static bool PERFOM_LONG_UI_CHECKS = true;

        protected ApplicationManager app;
        
        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int maximumStringLenght)
        {
            int l = Convert.ToInt32(rnd.NextDouble()*maximumStringLenght);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(65 + Convert.ToInt32(rnd.NextDouble()*90)));
            }
            return builder.ToString();
        }
    }
}
