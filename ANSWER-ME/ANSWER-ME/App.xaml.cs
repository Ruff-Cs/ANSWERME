﻿using ANSWER_ME.Data;
using ANSWER_ME.Models;
using ANSWER_ME.Views;

namespace ANSWER_ME
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Current.UserAppTheme = AppTheme.Light;

            MainPage = new AppShell();
            Routing.RegisterRoute(nameof(TriviaView), typeof(TriviaView));
            Routing.RegisterRoute(nameof(AchivementView), typeof(AchivementView));
            Routing.RegisterRoute(nameof(HistoryView), typeof(HistoryView));
            Routing.RegisterRoute(nameof(FormView), typeof(FormView));

            Database.Init();
        }
    }
}