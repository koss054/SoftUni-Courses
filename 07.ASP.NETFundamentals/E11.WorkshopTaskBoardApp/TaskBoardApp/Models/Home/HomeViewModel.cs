﻿namespace TaskBoardApp.Models.Home
{
    public class HomeViewModel
    {
        public int AllTasksCount { get; init; }

        public virtual List<HomeBoardModel> BoardsWithTasksCount { get; init; }

        public int UserTasksCount { get; init; }
    }
}
