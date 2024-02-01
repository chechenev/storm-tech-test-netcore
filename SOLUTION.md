## Notes

| 2 | When todo items are displayed in browser in the details page, they are listed in an arbitrary order. Change `Views/TodoList/Detail.cshtml` so that items are listed by order of importance: `High`, `Medium`, `Low` |

I made changes in `Views/TodoList/Detail.cshtml`, when at the same time I could have done it in the `Todo/Controllers/TodoListController.cs` Controller. I made the changes in the View for two reasons:
1. It was specifiacily mentioned in the task
2. We might want to reuse "default" ordering in different places of the app

